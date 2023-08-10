namespace FountainOfObjects;

public static class HelperUtils
{
    //Create new line with color.
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
    public static double RandomPercent()
    {
        Random random = new();
        return random.NextDouble();
    }

    private static int GetRandomNumber(Random random, int maxValue)
    {
        return random.Next(maxValue);
    }
}