namespace FountainOfObjects;

public static class HelperUtils
{
    //Create new ling with color.
    public static void WriteColorLine(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
    }

    //Write on single line with color.
    public static void WriteColor(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
    }
    
    
    //Generate random numbers.
    private static readonly Random Random = new Random();

    private static int GetRandomNumber(Random random, int maxValue)
    {
        return random.Next(maxValue);
    }
    public static int ReturnRandom(int gridSize)
    {
        int randomCol =  GetRandomNumber(Random, gridSize);
        return randomCol;
    }
}