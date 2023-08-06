namespace FountainOfObjects;

public static class InputUtils
{
    public static int GetIntInRange(string prompt, int rangeLow, int rangeHigh)
    {
        Console.WriteLine(prompt);
        string userInput = Console.ReadLine() ?? string.Empty;
        int input = 5;
        bool isInRange = false;

        //try-parse is the var you are checking and then an output var if it passes. So input becomes the number if it passes the parse.
        while (!isInRange)
        {
            if (!int.TryParse(userInput, out input))
            {
                Console.WriteLine(
                    $"That is not a number. Please input a number between {rangeLow} and {rangeHigh}.");
                userInput = Console.ReadLine() ?? string.Empty;
            }
            else if(input > rangeHigh || input < rangeLow)
            {
                Console.WriteLine(
                    $"That number is not in range. Please input a number between {rangeLow} and {rangeHigh}.");
                userInput = Console.ReadLine() ?? string.Empty;
            }
            else
            {
                Console.WriteLine($"Your number is {input}.");
                isInRange = true;
            }
        }
        return input;
    }

    public static string GetStringToLower(string prompt, string error)
    {
        Console.WriteLine(prompt);
        string userInput = Console.ReadLine() ?? string.Empty;

        while (userInput == string.Empty)
        {
            Console.WriteLine(error);
            userInput = Console.ReadLine() ?? string.Empty;
        }

        return userInput.ToLower();
    }
}