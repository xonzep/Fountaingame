namespace FountainOfObjects;

public static class Game
{
    private static readonly World World;
    private static readonly Player Player;
    

    static Game()
    {
        World = new World();
        Location start = new(0, 0);
        //shoving the world map here is not the greatest. TODO: Resolve this so that it's not passed directly.
        Player = new Player(start, 10, true, World);
        
    }
    public static void Run()
    {
        World.SetWorldSize();
        //Console.WriteLine("Test " + World.RoomMap[(2,3)].RoomTypes);
        
        while (true)
        {
            HelperUtils.WriteColorLine(World.GetRoomLocDesc(Player), ConsoleColor.Magenta);
            MoveCommand moveCommand = new(Player.UserInput());  
            moveCommand.Execute(Player);

        }
        
        
    }

    
}