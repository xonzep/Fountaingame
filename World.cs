namespace FountainOfObjects;


public class World
{
    public readonly Dictionary<(int, int), Room> _roomMap = new();
    public int GridSize { get; private set; }
    public bool GameFinished;
    private WorldSize _currentWorldSize;

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
        //Set entrance
        SetEntrance();
        AddRoomsForSize(_currentWorldSize);
    }

    private void AddRoomsForSize(WorldSize option)
    {
        switch (option)
        {
            case WorldSize.Small:
                _roomMap[(2, 3)] = new Room(RoomTypes.Fountain);
                AddRoomsByPercentageWithLimit(RoomTypes.Pit, 0.6, 1);
                AddRoomsByPercentageWithLimit(RoomTypes.Maelstrom, 0.3, 1);
                AddRoomsByPercentageWithLimit(RoomTypes.Amaroks, 0.8, 1);
                break;
            case WorldSize.Medium:
                _roomMap[(3, 4)] = new Room(RoomTypes.Fountain);
                AddRoomsByPercentageWithLimit(RoomTypes.Pit, 0.6, 2);
                AddRoomsByPercentageWithLimit(RoomTypes.Maelstrom, 0.3, 1);
                AddRoomsByPercentageWithLimit(RoomTypes.Amaroks, 0.8, 2);
                break;
            case WorldSize.Large:
                _roomMap[(4, 5)] = new Room(RoomTypes.Fountain);
                AddRoomsByPercentageWithLimit(RoomTypes.Pit, 0.6, 4);
                AddRoomsByPercentageWithLimit(RoomTypes.Maelstrom, 0.3, 2);
                AddRoomsByPercentageWithLimit(RoomTypes.Amaroks, 0.8, 3);
                break;
        }
    }

    public void AddRoomsByPercentageWithLimit(RoomTypes roomType, double percentage, int maxRoomsOfType)
    {
        for (int roomsAdded = 0; roomsAdded < maxRoomsOfType;)
        {
            double randomPercent = HelperUtils.GenerateRandomPercent();
            if (randomPercent < percentage)
            {
                KeyValuePair<(int, int), Room> randomRoomEntry = _roomMap.ElementAt(HelperUtils.GetRandomNumber(_roomMap.Count));
                if (randomRoomEntry.Value.RoomTypes == RoomTypes.Empty)
                {
                    randomRoomEntry.Value.RoomTypes = roomType;
                    randomRoomEntry.Value.UpdateDescription();
                    roomsAdded++;
                }
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
                Game.FountainOn = true;
                _roomMap[(2, 3)] = new Room(RoomTypes.FountainOn);
            }
        
            if (turnOn == Direction.TurnOn && Game.InFountainRoom && Game.FountainOn)
            {
                HelperUtils.WriteColorLine("The Fountain is already turned on and flowing.", ConsoleColor.Cyan);
            }
    }

    public Room ReturnRoom(Location location)
    {
        _roomMap.TryGetValue((location.Row, location.Col), out Room? room);
        return room!;
    }
    

    public void CheckWinState(Player player)
    {
        Room room = ReturnRoom(player.Location);
        switch (room.RoomTypes)
        {
            case RoomTypes.Entrance when Game.FountainOn:
                HelperUtils.WriteColorLine(
                    "The Fountain is running. You have done what you've come to do. You leave with a lighter heart.",
                    ConsoleColor.DarkYellow);
                Thread.Sleep(5000);
                GameFinished = true;
                break;
            case RoomTypes.Entrance when (!Game.FountainOn && !Game.QuitRequested):
                HelperUtils.WriteColorLine("There is something you need to do before leaving.", ConsoleColor.Cyan);
                break;
            case RoomTypes.Pit:
                player.PlayerDeath();
                break;
            case RoomTypes.Maelstrom:
                Monsters.MaelstromAttack(player, Game.World);
                break;
            case RoomTypes.Amaroks:
                player.PlayerDeath();
                break;
        }
    }
    
    public void SetWorldSize()
    {
        switch (UserChooseWorldSize())
        {
            case WorldSize.Small:
                _currentWorldSize = WorldSize.Small;
                AddRooms(4);
                //Set fountain for world size.
                
                break;

            case WorldSize.Medium:
                _currentWorldSize = WorldSize.Medium;
                AddRooms(6);
                
                break;

            case WorldSize.Large:
                _currentWorldSize = WorldSize.Large;
                AddRooms(8);
                
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
public record Location(int Row, int Col);

