namespace FountainOfObjects;

public abstract class GameUtils
{
    public static Location GetLocationInDirection(Location currentLocation, Direction direction)
    {
        return direction switch
        {
            //Used for movement and for Sensing around the player.
            //the With keyword allows the record to be copied over and just update the location.Row or .Col while keeping
            //the opposite intact. We need to be able to check all eight directions.
            Direction.North => currentLocation with { Row = currentLocation.Row -1 },
            Direction.NorthEast => new Location(currentLocation.Row -1, currentLocation.Col +1),
            Direction.NorthWest => new Location(currentLocation.Row -1, currentLocation.Col -1),
            Direction.South => currentLocation with { Row = currentLocation.Row +1 },
            Direction.SouthEast => new Location(currentLocation.Row +1, currentLocation.Col +1),
            Direction.SouthWest => new Location(currentLocation.Row +1, currentLocation.Col -1),
            Direction.East => currentLocation with { Col = currentLocation.Col +1 },
            Direction.West => currentLocation with { Col = currentLocation.Col -1 },
            
            _ => throw new InvalidOperationException("That is not an option.")
        };
    }

    public static void HelpIntro()
    {
        HelperUtils.WriteColorLine("You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search  of the Fountain of Objects.", ConsoleColor.DarkYellow);
        HelperUtils.WriteColorLine("Light is visible only in the entrance, and no other light is seen anywhere in the caverns.", ConsoleColor.DarkYellow);
        HelperUtils.WriteColorLine("You must navigate the Caverns with your other senses.", ConsoleColor.DarkYellow);
        HelperUtils.WriteColorLine("Look out for pits. You  will feel a breeze if a pit is in an adjacent room. If you enter a room with a pit, you will die.", ConsoleColor.DarkYellow);
        HelperUtils.WriteColorLine("Maelstroms are  violent forces of sentient wind. Entering a room with one could transport you to any other location  in the caverns. You will be able to hear their growling and groaning in nearby rooms.", ConsoleColor.DarkYellow);
        HelperUtils.WriteColorLine("Amaroks roam the  caverns. Encountering one is certain death, but you can smell their rotten stench in nearby rooms.", ConsoleColor.DarkYellow);
        HelperUtils.WriteColorLine("You carry with  you a bow and a quiver of arrows. You can use them to shoot monsters in the caverns but be warned:  you have a limited supply.", ConsoleColor.DarkYellow);
        HelperUtils.WriteColorLine("Find the Fountain of Objects, activate it, and return to the entrance.", ConsoleColor.DarkYellow);
        
    }

    public static void HelpText()
    {
        HelperUtils.WriteColorLine("Move [Direction]: You can move in any of the four directions, North, South, East, and West.", ConsoleColor.DarkMagenta);
        HelperUtils.WriteColorLine("Turn On: If you are in the Fountain Room you can turn it on with this command.", ConsoleColor.DarkMagenta);
        HelperUtils.WriteColorLine("Shoot [Direction]: You start with five arrows and can shoot in any of the four directions. If there is a creature there, it will be killed.", ConsoleColor.DarkMagenta);
        HelperUtils.WriteColorLine("Quit: Quits the game.", ConsoleColor.DarkMagenta);
    }

    //This returns the room type in the map. This is different than ReturnRoom which returns the RoomType of a known location.
    public static Location? FindRoomInMap(World world, RoomTypes roomTypes)
    {
        Location? roomLocation = null;
        foreach (KeyValuePair<(int, int), Room> entry in world._roomMap)
        {
            if (entry.Value.RoomTypes == roomTypes)
            {
                int row = entry.Key.Item1;
                int col = entry.Key.Item2;

                roomLocation = new Location(row, col);

            }
        }

        return roomLocation;
    }
    
}