using System.Data;

namespace FountainOfObjects;

public class World
{
   //the (int, int) is our KEY which is col and rows. The Room is our VALUE.
   private Dictionary<(int, int), Room> _roomMap = new Dictionary<(int, int), Room>();
    
   
   private WorldSize UserChooseWorldSize()
   {
      while (true)
      {
          Console.WriteLine("What size world would you like? Options are: 'small', 'medium', or 'large'.");
          string userInput = Console.ReadLine().ToLower();

         switch (userInput)
         {
            case "small":
               return WorldSize.Small;
            case "medium":
               return WorldSize.Medium;
            case "large":
               return WorldSize.Large;
            default:
               Console.WriteLine("Invalid input. Please enter 'small', 'medium', or 'large'.");
               break;
         }

      }
   }
   
   private void AddRooms(int gridSize)
   {
       for (int row = 0; row < gridSize; row++)
       {
          for (int col = 0; col < gridSize; col++)
          {
             Room room = new Room(row, col);
             _roomMap.Add((row, col), room);
          }
       }
   }
   
   public void SetWorldSize()
   {
      switch (UserChooseWorldSize())
      {
         case WorldSize.Small:
            AddRooms(4);
            break;
         
         case WorldSize.Medium:
            AddRooms(6);
            break;
         
         case WorldSize.Large:
            AddRooms(9);
            break;
         
         default:
            throw new ArgumentOutOfRangeException();
      }
   }
    

   private enum WorldSize
   {
      Small,
      Medium,
      Large
   }
   
}