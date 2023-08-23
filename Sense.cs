namespace FountainOfObjects;

public class Sense 
{
    private readonly World _world;
    private readonly Player _player;
    
    
    public Sense(World world, Player player)
    {
        _world = world;
        _player = player;
    }
    
    private string? SenseDescription(Location location, Direction direction)
    {
        //This makes it easier to add sense description based on room types. 
        
        RoomTypes? roomTypes = _world.ReturnRoom(location).RoomTypes;
        
        
        Dictionary<RoomTypes, string> specialRoomSensed = new()
        {           //key                   //Value
            { RoomTypes.Pit,  $"You feel a draft of air from {direction}, and it sends a deathly chill down your spine."},
            { RoomTypes.Fountain,  $"You hear dripping to the {direction}" },
            { RoomTypes.Entrance, $"In the {direction}, you can see the faint glow of the outside." },
            { RoomTypes.Empty, $"In the {direction} you sense an {roomTypes} room"}
            
        };

        return specialRoomSensed.TryGetValue(roomTypes.Value, out string? description)
            ? description: null;
    }

    
    public void SenseNearBy()
    {
        Direction[] directionsAroundPlayer = { Direction.North, Direction.NorthEast, Direction.NorthWest, Direction.East, Direction.South, Direction.SouthEast, Direction.SouthWest, Direction.West };
        foreach (Direction direction in directionsAroundPlayer)
        {
            Location locationToCheck = GameUtils.GetLocationInDirection(_player.Location, direction);
            
            if (!_player.IsOnMap(locationToCheck))
            {
                HelperUtils.WriteColorLine($"You can go no farther, there is a wall to the {direction}", ConsoleColor.Red);
                continue;
                
            }
            
            string? description = SenseDescription(locationToCheck, direction);
            
            HelperUtils.WriteColorLine(description, ConsoleColor.Magenta);
        }
    }
}
