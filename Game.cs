namespace FountainOfObjects;

public static class Game
{
    private static World _world;
    private static Player _player;
    

    static Game()
    {
        _world = new World();
        Location start = new(0, 0);
        //shoving the world map here is not the greatest. TODO: Resolve this so that it's not passed directly.
        _player = new Player(start, 10, true, _world);
        
    }
    public static void Run()
    {
        _world.SetWorldSize();
        
        while (true)
        {
            MoveCommand moveCommand = new(Player.UserInput());   
            HelperUtils.WriteColorLine(_world.GetRoomLocDesc(_player), ConsoleColor.Magenta);
            moveCommand.Execute(_player);
            Console.WriteLine(_player.Location);

        }
        
        
    }

    
}