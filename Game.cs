namespace FountainOfObjects;

public static class Game
{
    public static readonly World World;
    private static readonly Player Player;
    private static readonly Sense Sense;
    public static bool QuitRequested { get;  set; }
    public static bool FountainOn { get; set; }
    public static bool SenseCalled { get; set; }
    public static bool InFountainRoom { get; }

    static Game()
    {
        World = new World();
        Location start = new(0, 0);
        //shoving the world map here is not the greatest.
        Player = new Player(start, true, World);
        Sense = new Sense(World, Player);
    }
    public static void Run()
    {
        World.SetWorldSize();
        GameLoop();
        
        
    }

    private static void GameLoop()
    {
        DateTime timeStart = DateTime.Now;
        GameUtils.HelpIntro();
        Thread.Sleep(1500);
        Console.Clear();
        HelperUtils.WriteColorLine("You have 5 arrows to shoot.", ConsoleColor.Red);
        while (!World.GameFinished && !QuitRequested)
        {
            HelperUtils.WriteColorLine(World.ReturnRoom(Player.Location).Description, ConsoleColor.Yellow);
            Direction input = Player.ReturnUserDirection();
            MoveCommand moveCommand = new(input);
            moveCommand.Execute(Player);
            World.CheckWinState(Player);
            World.TurnOn(input);
           
            

            
            if (QuitRequested || !Player.IsAlive)
            {
                DateTime timeEnd = DateTime.Now;
                HelperUtils.WriteColorLine(GameUtils.TimeCheck(timeStart, timeEnd), ConsoleColor.Green);
                Thread.Sleep(1000);
                break;
            }
            //There's a better way to do this, I'm sure. But for now, this will work.
            if (SenseCalled)
            {
                Sense.SenseNearBy();
                SenseCalled = false;
            }
        }
    }
}