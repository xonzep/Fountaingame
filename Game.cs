namespace FountainOfObjects;

public static class Game
{
    private static readonly World World;
    private static readonly Player Player;
    public static bool QuitRequested { get;  set; }
    public static bool InFountainRoom { get; set; }
    public static bool FountainOn { get; set; }
    public static Sense Sense;

    static Game()
    {
        World = new World();
        Location start = new(0, 0);
        //shoving the world map here is not the greatest.
        Player = new Player(start, 10, true, World);
        Sense = new Sense(World, Player);
    }
    public static void Run()
    {
        World.SetWorldSize();
        //Remove this, it prints the current state of the Bool for testing.
        Console.WriteLine(World.GameFinished);
        //Console.WriteLine("Test " + World.RoomMap[(2,3)].RoomTypes);
        GameLoop();
        
        
    }

    private static void GameLoop()
    {
        while (!World.GameFinished && !QuitRequested)
        {
            HelperUtils.WriteColorLine(World.ReturnRoom(Player.Location).Description, ConsoleColor.Magenta);
            Direction input = Player.UserInputSelection();
            MoveCommand moveCommand = new(input);
            moveCommand.Execute(Player);
            World.CheckWinState(Player);
            World.TurnOn(input);
            Sense.SenseNearBy();

            
            if (QuitRequested)
            {
                break;
            }
        }
    }
}