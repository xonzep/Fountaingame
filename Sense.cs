namespace FountainOfObjects;
/*I want to remove a few of the descriptions from the Direction portion as that is not the best place for them
 So for this I want to have Fountain description and Entrance description as well as a 'you are close' description here
 so it makes sense to have a sense class.
 */

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
        Direction[] directionAroundPlayer = { Direction.North, Direction.East, Direction.South, Direction.West };

        foreach (Direction direction in directionAroundPlayer)
        {
            Location locationToCheck = GameUtils.GetLocationInDirection(_player.Location, direction);
            
            if(_player.IsOnMap(locationToCheck) && _world.ReturnRoom(locationToCheck).RoomTypes == RoomTypes.Fountain)
            {
                
            }
        }

    }

    
}
