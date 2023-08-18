namespace FountainOfObjects;

public class Sense 
{
    private World _world;
    private Player _player;
    private RoomTypes RoomTypes { get;}
    
    public Sense(World world, Player player)
    {
        _world = world;
        _player = player;
    }
    
    public string SenseDescription()
    {
        return _world.ReturnRoom(_player.Location).Description;
    }

    
    public void SenseNearBy()
    {
        Direction[] directionsAroundPlayer = { Direction.North, Direction.East, Direction.South, Direction.West };
        string senseDescription;
        foreach (Direction direction in directionsAroundPlayer)
        {
            Location locationToCheck = GameUtils.GetLocationInDirection(_player.Location, direction);
            

            if (!_player.IsOnMap(locationToCheck))
            {
                HelperUtils.WriteColorLine($"There is no room, only a wall to the {direction}", ConsoleColor.Red);
                continue;
                
            }
            
            if(_world.ReturnRoom(locationToCheck).RoomTypes == RoomTypes.Fountain)
            {
                senseDescription = $"You hear dripping to the {direction}";
            }
            else
            {
                senseDescription =
                    $"In the {direction} you sense an {_world.ReturnRoom(locationToCheck).RoomTypes} room";
            }
            
            HelperUtils.WriteColorLine(senseDescription, ConsoleColor.Magenta);
        }

    }

    
}
