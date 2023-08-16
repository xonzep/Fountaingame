namespace FountainOfObjects;

public interface ICommand
{
    void Execute(Player player);
}

public class MoveCommand: ICommand
{
    private Direction Direction { get; }
    
    public MoveCommand(Direction direction)
    {
        Direction = direction;
    }
    public void Execute(Player player)
    {
        if(Direction == Direction.Quit)
        {
            Game.QuitRequested = true;
            return;
        }

        if (Direction == Direction.TurnOn && Game.FountainOn)
        {
            return;
        }
        else if (Direction == Direction.TurnOn && !Game.FountainOn)
        {
            HelperUtils.WriteColorLine("You can not do that here.", ConsoleColor.Cyan);
            return;
        }
        

        Location currentLocation = player.Location;
        Location newLocation = Direction switch
        {
            //the With keyword allows the record to be copied over and just update the location.Row or Col while keeping
            //the opposite intact.
            Direction.North => currentLocation with { Row = currentLocation.Row -1 },
            Direction.South => currentLocation with { Row = currentLocation.Row +1 },
            Direction.East => currentLocation with { Col = currentLocation.Col +1 },
            Direction.West => currentLocation with { Col = currentLocation.Col -1 },
            _ => throw new InvalidOperationException("That is not an option.")
        };

        if (player.IsOnMap(newLocation))
        {
            player.Location = newLocation;
            
        }
        else
        {
            HelperUtils.WriteColorLine("There is a wall there and you cannot move forward.", ConsoleColor.Red);
        }
    }
}