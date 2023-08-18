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

        if (Direction == Direction.Sense)
        {
            Game.SenseCalled = true;
            return;
        }

        if (Direction == Direction.TurnOn && Game.FountainOn)
        {
            HelperUtils.WriteColorLine("The fountain springs to life! Objects flow like water.", ConsoleColor.Cyan);
            return;
        }
        
        if (Direction == Direction.TurnOn && !Game.FountainOn)
        {
            HelperUtils.WriteColorLine("You can not do that here.", ConsoleColor.Cyan);
            return;
        }
        

        Location currentLocation = player.Location;
        Location newLocation = GameUtils.GetLocationInDirection(currentLocation, Direction);
       

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