namespace FountainOfObjects;

public static class Game
{
    static World _world = new();
    static Location _start = new(0,0 );
    static Player _player = new(_start, _world._roomMap, 10, true);
    
    public static void Run()
    {
        _world.SetWorldSize();
        
        
        while (true)
        {
            MoveCommand moveCommand = new(_player.UserInput());   
            moveCommand.Execute(_player);
            Console.WriteLine(_player.Location);

        }
        
        
    }

    
}