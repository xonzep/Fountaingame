namespace FountainOfObjects;

public class HelperUtils
{
    private Random random = new Random();

    private static int GetRandomNumber(Random random, int maxValue)
    {
        return random.Next(maxValue);
    }
    public int ReturnRandom(int gridSize)
    {
        int RandomCol =  GetRandomNumber(random, gridSize);
        return RandomCol;
    }

   
}