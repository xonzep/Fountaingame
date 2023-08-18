namespace FountainOfObjects;

public abstract class GameUtils
{
    public static Location GetLocationInDirection(Location currentLocation, Direction direction)
    {
        return direction switch
        {
            //User for movement and for Sensing around the player.
            //the With keyword allows the record to be copied over and just update the location.Row or Col while keeping
            //the opposite intact.
            Direction.North => currentLocation with { Row = currentLocation.Row -1 },
            Direction.South => currentLocation with { Row = currentLocation.Row +1 },
            Direction.East => currentLocation with { Col = currentLocation.Col +1 },
            Direction.West => currentLocation with { Col = currentLocation.Col -1 },
            _ => throw new InvalidOperationException("That is not an option.")
        };
    }
    
}