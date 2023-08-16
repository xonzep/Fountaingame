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
            HelperUtils.WriteColorLine("What size world would you like? Options are: 'small', 'medium', or 'large'.", ConsoleColor.White);
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
                _roomMap.Add((row, col), new Room(col, row, RoomTypes.Empty));
            }
        }
        //Change empty type rooms to others based on a percentage. We don't need this quite yet.
        //PercentageRoomChange();
        //Set rooms that don't change.
        SetSpecialRooms();
        
    }
    

    private void PercentageRoomChange()
    {
        foreach (KeyValuePair<(int, int), Room> roomEntry in _roomMap)
        {
            (int col, int row) = roomEntry.Key;
            Room room = roomEntry.Value;

            if (room.RoomTypes is RoomTypes.Entrance or RoomTypes.Fountain)
            {
                continue;
            }
            
            _roomMap[(row, col)] = room;
        }
    }

    private void SetSpecialRooms()
    {
            _roomMap[(0, 0)] = new Room(0, 0, RoomTypes.Entrance);
            _roomMap[(2, 3)] = new Room(2, 3, RoomTypes.Fountain);
    }

    public void TurnOn(Direction turnOn)
    {
        
            if ( turnOn == Direction.TurnOn && Game.InFountainRoom)
            {
                _roomMap[(2, 3)] = new Room(2, 3, RoomTypes.FountainOn);
            }

            Game.FountainOn = true;
    }

    public Room ReturnRoom(Player player)
    {
        _roomMap.TryGetValue((player.Location.Col, player.Location.Row), out Room? room);
        return room!;
    }
    

    public void CheckWinState(Player player)
    {
        Room room = ReturnRoom(player);
        if (room.RoomTypes == RoomTypes.Entrance && Game.FountainOn)
        {
            HelperUtils.WriteColorLine("The Fountain is running. You have done what you've come to do. You leave with a lighter heart.", ConsoleColor.DarkYellow);
            GameFinished = true;
        }
        else if(room.RoomTypes == RoomTypes.Entrance && !Game.FountainOn)
        {
            HelperUtils.WriteColorLine("There is something you need to do before leaving.", ConsoleColor.Cyan);
        }
    }
    
    public void SetWorldSize()
    {
        switch (UserChooseWorldSize())
        {
            case WorldSize.Small:
                AddRooms(4);
                break;

            case WorldSize.Medium:
                AddRooms(6);
                break;

            case WorldSize.Large:
                AddRooms(9);
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

