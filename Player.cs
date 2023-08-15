
namespace FountainOfObjects;



public class Player
{
    public Location Location { get; set; }
    public int Health { get; set; }
    
    private readonly World _world;
    public bool IsAlive { get; set; }
    
    
    //Constructor takes in the room map, and the players location most importantly.
    public Player(Location location, int health, bool isAlive,World world)
    {
        Location = location;
        Health = health;
        IsAlive = isAlive;
        _world = world;
    }

    public bool IsOnMap(Location location)
    {
       return location.Row >= 0 && location.Row < _world.GridSize &&
              location.Col >= 0 && location.Col < _world.GridSize;
    }

    private static Direction GetDirection(string? userInput)
   {
       return userInput switch
       {
           "north" => Direction.North,
           "south" => Direction.South,
           "east" => Direction.East,
           "west" => Direction.West,
           _ => Direction.NoDirection
       };
   }
   
   public static Direction UserInput()
   {
       HelperUtils.WriteColorLine("What do you want to do?", ConsoleColor.Green);
       string? userInput = Console.ReadLine()?.ToLower();
       Direction direction = GetDirection(userInput);
       return direction;


   }

}

public interface ICommand
{
    void Execute(Player player);
}

//North is UP, South is DOWN, East is RIGHT, West is LEFT
public enum Direction
{
    North,
    South,
    East,
    West,
    NoDirection
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