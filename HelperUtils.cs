namespace FountainOfObjects;

public static class HelperUtils
{
    static Random random = new();
    //Create new line with color.
    public static void WriteColorLine(string text, ConsoleColor color)
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
        return random.NextDouble();
    }

    private static int GetRandomNumber(int maxValue)
    {
        return random.Next(maxValue);
    }
}