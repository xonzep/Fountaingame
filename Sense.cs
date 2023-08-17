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
