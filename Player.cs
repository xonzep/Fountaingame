
namespace FountainOfObjects;

public class Player
{
    public Location Location { get; set; }

    public int arrowAmount = 5;
    
    private readonly World _world;
    public bool IsAlive { get; private set; }


    //Constructor takes in the room map, and the players location most importantly.
    public Player(Location location, bool isAlive,World world)
    {
        Location = location;
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
                
                case "shoot north":
                    return Direction.North;
                
                case "shoot south":
                    return Direction.South;
                
                case "shoot east":
                    return Direction.East;
                
                case "shoot west":
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
       HelperUtils.WriteColorLine("What do you want to do? Options are 'North', 'South', 'East', 'West', 'Shoot [Direction]' 'Turn On', 'Quit' ", ConsoleColor.Green);
       string? userInput = Console.ReadLine()?.ToLower();
       return userInput;
       
   }

   public void PlayerDeath()
   {
       HelperUtils.WriteColorLine(_world.ReturnRoom(Location).Description, ConsoleColor.DarkRed);
       HelperUtils.WriteColorLine("Game Over", ConsoleColor.Red);
       IsAlive = false;
   }

   public void ShootArrow(Direction direction)
   {
       //Player can shoot an arrow in the four directions. So we take in direction which is returned from the input
       //fire an arrow and change the room type to RoomType.empty if not fountain or entrance. Then decrease amount of arrows.
       
       Location locationToShoot = GameUtils.GetLocationInDirection(Location, direction);
       if (arrowAmount > 0)
       {
           RoomTypes checkRoom = _world.ReturnRoom(locationToShoot).RoomTypes;
           if (IsOnMap(locationToShoot) && checkRoom == RoomTypes.Amaroks || checkRoom == RoomTypes.Maelstrom)
           {
               arrowAmount--;
               HelperUtils.WriteColorLine($"Your arrow sails into the room and you hear the death sounds of a creature. It is now safe to go {direction}.", ConsoleColor.Magenta);
               Room room = _world.ReturnRoom(locationToShoot);
               room.RoomTypes = RoomTypes.Empty;
               room.UpdateDescription();
               
           }
           else
           {
               arrowAmount--;
               HelperUtils.WriteColorLine("Your arrow bounces off the wall and breaks. It can't be repaired.",
                   ConsoleColor.Red);
               
           }
       }


   }


}

//North is UP, South is DOWN, East is RIGHT, West is LEFT
public enum Direction
{
    North,
    NorthEast,
    NorthWest,
    South,
    SouthEast,
    SouthWest,
    East,
    West,
    Quit,
    TurnOn,
    Sense
}

