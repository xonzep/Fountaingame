namespace FountainOfObjects;


public class World
{
    public readonly Dictionary<(int, int), Room> RoomMap = new();
    public int GridSize;

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
                RoomMap.Add((row, col), new Room(col, row, RoomTypes.Empty));
            }
        }
        //Change empty type rooms to others based on a percentage. We don't need this quite yet.
        //PercentageRoomChange();
        //Set rooms that don't change.
        SetSpecialRooms();
        
    }

    public int GetGridSize()
    {
        return GridSize;
    }
    

    private void PercentageRoomChange()
    {
        foreach (KeyValuePair<(int, int), Room> roomEntry in RoomMap)
        {
            (int col, int row) = roomEntry.Key;
            Room room = roomEntry.Value;

            if (room.RoomTypes is RoomTypes.Entrance or RoomTypes.Fountain)
            {
                continue;
            }
            
            RoomMap[(row, col)] = room;
        }
    }

    private void SetSpecialRooms()
    {
        /*if(RoomMap.TryGetValue((0,0), out Room? entranceRoom))
        {
            
             *There should be a better way to do this, we're getting the return which is RoomTypes.Empty and saving it to
             *entranceRoom. Then we're changing the returned room's roomType to entrance.
             *Then we're calling the Map at 0, 0 and adding the room with the changed RoomType. 
             */
            /*entranceRoom.RoomTypes = RoomTypes.Entrance;
            entranceRoom.Description = entranceRoom.RoomDescription(RoomTypes.Entrance);
            RoomMap[(0, 0)] = entranceRoom;
            
            }*/
            
            /*if (RoomMap.TryGetValue((2, 3), out Room? fountainRoom))
       {
           fountainRoom.RoomTypes = RoomTypes.Fountain;
           RoomMap[(2, 3)] = fountainRoom;
       }
       */
            
            
        //Better way?
            RoomMap[(0, 0)] = new Room(0, 0, RoomTypes.Entrance);
            RoomMap[(2, 3)] = new Room(2, 3, RoomTypes.Fountain);
        

       
    }

    public string GetRoomLocDesc(Player player)
    {
        RoomMap.TryGetValue((player.Location.Col, player.Location.Row), out Room? roomDesc);
        
        return roomDesc!.Description;

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

