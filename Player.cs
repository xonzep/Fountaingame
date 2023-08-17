
using System.Reflection.Metadata.Ecma335;

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

        Direction switchDirection;
       switch (userInput)
       {
           case "move north":
           case "north":
              switchDirection = Direction.North;
              break;
           case "move south":
           case "south":
               switchDirection = Direction.South;
               break;
           case "move east":
           case "east":
               switchDirection = Direction.East;
               break;
           case "move west":
           case "west":
               switchDirection = Direction.West;
               break;
           default:
               switchDirection = Direction.Unknown;
               break;
           
       }
        

       if (switchDirection == Direction.Unknown)
       {
           HelperUtils.WriteColorLine("That is not an option.", ConsoleColor.Red);
           UserInputSelection();

       }
       return switchDirection;
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
    Unknown,
    North,
    South,
    East,
    West,
    Quit,
    TurnOn,
    Sense
}

