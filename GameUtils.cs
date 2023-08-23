namespace FountainOfObjects;

public abstract class GameUtils
{
    public static Location GetLocationInDirection(Location currentLocation, Direction direction)
    {
        return direction switch
        {
            //Used for movement and for Sensing around the player.
            //the With keyword allows the record to be copied over and just update the location.Row or Col while keeping
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

    //This returns the room type in the map. This is different than ReturnRoom which returns the RoomType of a known location.
    public Location? FindRoomInMap(World world, RoomTypes roomTypes)
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