namespace FountainOfObjects;

public static class HelperUtils
{
    private static readonly Random Random = new();
    //Create new line with color.
    public static void WriteColorLine(string? text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    //Write on single line with color.
    public static void WriteColor(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }
    
    
    //Generate random numbers.
    public static double GenerateRandomPercent()
    {
        return Random.NextDouble();
    }

    public static int GetRandomNumber(int maxValue)
    {
        return Random.Next(maxValue);
    }
}