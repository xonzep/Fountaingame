namespace FountainOfObjects;


public class World
{
    public readonly Dictionary<(int, int), Room> _roomMap = new();

    private static WorldSize UserChooseWorldSize()
    {

        while (true)
        {
            HelperUtils.WriteColorLine("What size world would you like? Options are: 'small', 'medium', or 'large'.", ConsoleColor.White);
            string userInput = Console.ReadLine()?.ToLower() ?? string.Empty;

            switch (userInput)
            {
                case "small":
                    Console.Clear();
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
        if(_roomMap.TryGetValue((0,0), out Room? entranceRoom))
        {
            /*
             *There should be a better way to do this, we're getting the return which is RoomTypes.Empty and saving it to
             *entranceRoom. Then we're changing the returned room's roomType to entrance.
             *Then we're calling the Map at 0, 0 and adding the room with the changed RoomType. 
             */
            entranceRoom.RoomTypes = RoomTypes.Entrance;
            _roomMap[(0, 0)] = entranceRoom;
        }

        if (_roomMap.TryGetValue((2, 3), out Room? fountainRoom))
        {
            fountainRoom.RoomTypes = RoomTypes.Fountain;
            _roomMap[(2, 3)] = fountainRoom;
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

