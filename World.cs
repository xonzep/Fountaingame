namespace FountainOfObjects;


public class World
{
    private readonly Dictionary<(int, int), Room> _roomMap = new();
    public int GridSize { get; private set; }
    public bool GameFinished;

    private static WorldSize UserChooseWorldSize()
    {

        while (true)
        {
            HelperUtils.WriteColorLine("What size world would you like to play? Options are: 'small', 'medium', or 'large'.", ConsoleColor.White);
            string userInput = Console.ReadLine()?.ToLower() ?? string.Empty;

            switch (userInput)
            {
                case "small":
                    return WorldSize.Small;
                case "medium":
                    return WorldSize.Medium;
                case "large":
                    return WorldSize.Large;
                default:
                    HelperUtils.WriteColorLine("Invalid input. Please enter 'small', 'medium', or 'large'.", ConsoleColor.Red);
                    break;
            }

        }
    }

    private void AddRooms(int gridSize)
    {
        GridSize = gridSize;
        //Add all the rooms we need for our map. They are all set as Empty Room Type to start.
        for (int row = 0; row < gridSize; row++)
        {
            for (int col = 0; col < gridSize; col++)
            {
                _roomMap.Add((row, col), new Room(RoomTypes.Empty));
            }
        }
        //Change empty type rooms to others based on a percentage. We don't need this quite yet.
        //PercentageRoomChance();
        //Set rooms that don't change.
        SetEntrance();
        AddRoomsByPercentageWithLimit(RoomTypes.Pit, 0.3f, 1);
        
    }

    private void AddRoomsByPercentageWithLimit(RoomTypes roomType, double percentage, int maxRoomsOfType)
    {
        //This isn't working. It doesn't add pit rooms to the map.
        int roomsAdded = 0;
        Console.WriteLine(roomsAdded);
        
        foreach (KeyValuePair<(int, int), Room> roomEntry in _roomMap)
        {
            double randomPercent = HelperUtils.GenerateRandomPercent();
            if (randomPercent < percentage && roomsAdded < maxRoomsOfType )
            {
                roomEntry.Value.RoomTypes = roomType;
                roomsAdded++;
            }
        }
    }
    
    
    private void SetEntrance()
    {
        _roomMap[(0, 0)] = new Room(RoomTypes.Entrance);
        
    }

    
    public void TurnOn(Direction turnOn)
    {
        
            if ( turnOn == Direction.TurnOn && Game.InFountainRoom)
            {
                _roomMap[(2, 3)] = new Room(RoomTypes.FountainOn);
            }

            Game.FountainOn = true;

            if (turnOn == Direction.TurnOn && Game.InFountainRoom && Game.FountainOn)
            {
                HelperUtils.WriteColorLine("The Fountain is already turned on and flowing.", ConsoleColor.Cyan);
            }
    }

    public Room ReturnRoom(Location location)
    {
        _roomMap.TryGetValue((location.Col, location.Row), out Room? room);
        return room!;
    }
    

    public void CheckWinState(Player player)
    {
        Room room = ReturnRoom(player.Location);
        switch (room.RoomTypes)
        {
            case RoomTypes.Entrance when Game.FountainOn:
                HelperUtils.WriteColorLine("The Fountain is running. You have done what you've come to do. You leave with a lighter heart.", ConsoleColor.DarkYellow);
                Thread.Sleep(5000);
                GameFinished = true;
                break;
            case RoomTypes.Entrance when !Game.FountainOn && !Game.QuitRequested:
                HelperUtils.WriteColorLine("There is something you need to do before leaving.", ConsoleColor.Cyan);
                break;
        }
    }
    
    public void SetWorldSize()
    {
        switch (UserChooseWorldSize())
        {
            case WorldSize.Small:
                AddRooms(4);
                //Set fountain for world size.
                _roomMap[(2, 3)] = new Room(RoomTypes.Fountain);
                break;

            case WorldSize.Medium:
                AddRooms(6);
                _roomMap[(3, 4)] = new Room(RoomTypes.Fountain);
                break;

            case WorldSize.Large:
                AddRooms(8);
                _roomMap[(4, 5)] = new Room(RoomTypes.Fountain);
                break;

            default:
                throw new InvalidOperationException("Invalid World Size Chosen.");
        }
    }
    
    
}

public enum WorldSize
{
    Small,
    Medium,
    Large
}

//The location of objects. Seems better to store it here.
public record Location(int Col, int Row);

