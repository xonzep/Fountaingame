
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
    
    //This handles our user input. It continues to ask until it relives a valid input. Might be better to pull this out
    //to it's own class, but meh.
    public Direction ReturnUserDirection()
    {
        
        while(true)
        {
            string? userInput = GetUserInput();
            switch (userInput)
            {
                case "move north":
                case "north":
                    return Direction.North;

                case "move south":
                case "south":
                    return Direction.South;

                case "move east":
                case "east":
                    return Direction.East;

                case "move west":
                case "west":
                    return Direction.West;
                
                case "turn on fountain":
                case "turn on":
                    return Direction.TurnOn;
                
                case "sense the area":
                case "sense":
                    return Direction.Sense;
                
                case "quit":
                case "exit":
                    return Direction.Quit;
                    
                default:
                    HelperUtils.WriteColorLine("That is not an option. Please choose a direction.", ConsoleColor.Red);
                    break;
            }

        }
        
        
    }
   
   private string? GetUserInput()
   {
       HelperUtils.WriteColorLine("What do you want to do? Options are 'North', 'South', 'East', 'West', 'Turn On', 'Quit' ", ConsoleColor.Green);
       string? userInput = Console.ReadLine()?.ToLower();
       return userInput;
       
   }

   public void PlayerDeath()
   {
       HelperUtils.WriteColorLine(_world.ReturnRoom(Location).Description, ConsoleColor.DarkRed);
       HelperUtils.WriteColorLine("Game Over", ConsoleColor.Red);
       IsAlive = false;
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
    TurnOn,
    Sense
}

