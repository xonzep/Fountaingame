
namespace FountainOfObjects;

public class Player
{
    public Location Location { get; set; }
    public int Health { get; set; }
    
    private readonly World _world;
    public bool IsAlive { get; set; }
    public bool FountainOn { get; set; }
    
    
    //Constructor takes in the room map, and the players location most importantly.
    public Player(Location location, int health, bool isAlive,World world)
    {
        Location = location;
        Health = health;
        IsAlive = isAlive;
        _world = world;
        FountainOn = false;
    }

    public bool IsOnMap(Location location)
    {
       return location.Row >= 0 && location.Row < _world.GridSize &&
              location.Col >= 0 && location.Col < _world.GridSize;
    }
    

    private Direction UserInput(string? userInput)
   {
       
       return userInput switch
       {
           "north" => Direction.North,
           "south" => Direction.South,
           "east" => Direction.East,
           "west" => Direction.West,
           "quit" => Direction.Quit,
           "exit" => Direction.Quit,
           "turn on" => Direction.TurnOn,
           _ => Direction.Quit
       };
   }
   
   public Direction UserInputSelection()
   {
       HelperUtils.WriteColorLine("What do you want to do? Options are 'North', 'South', 'East', 'West', 'Turn On', 'Quit' ", ConsoleColor.Green);
       string? userInput = Console.ReadLine()?.ToLower();
       Direction direction = UserInput(userInput);
       return direction;
       
   }
    

}

//North is UP, South is DOWN, East is RIGHT, West is LEFT
public enum Direction
{
    North,
    South,
    East,
    West,
    Quit,
    TurnOn
}

