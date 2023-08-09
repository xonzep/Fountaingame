namespace FountainOfObjects;


public class World
{
    private Dictionary<(int, int), Room> _roomMap = new();

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
        for (int row = 0; row < gridSize; row++)
        {
            for (int col = 0; col < gridSize; col++)
            {
                _roomMap.Add((row, col), new Room(col, row, RoomTypes.Empty));
            }
        }

        foreach (KeyValuePair<(int, int), Room> roomEntry in _roomMap)
        {
            (int col, int row) = roomEntry.Key;
            Room room = roomEntry.Value;

            if (room.RoomTypes is RoomTypes.Entrance or RoomTypes.Fountain)
            {
                continue;
            }
        }
    }

    public void SetWorldSize()
    {

        switch (UserChooseWorldSize())
        {
            case WorldSize.Small:
                AddRooms(4);

                foreach (KeyValuePair<(int, int), Room> kvp in _roomMap)
                {
                    Console.WriteLine($"{kvp.Key}, {kvp.Value}");
                }

                break;

            case WorldSize.Medium:
                AddRooms(6);
                break;

            case WorldSize.Large:
                AddRooms(9);
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

public enum WorldSize
{
    Small,
    Medium,
    Large
}

