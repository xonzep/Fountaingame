namespace FountainOfObjects;
//We now have the world generation working correctly. It takes in a number for the size of the world-
//Then adds a room with a room type. We need to get the entrance and the fountain room added in via the row and col
//Then we need to setup the player and the input for the player and somehow tie the room together with the player.
//I think all we need to do is pass the current row and col of the player to get back information about the room.
//I want to add a away to draw the player to the fountain so as it gets closer they 'hear' sounds.
//Easiest way is if the fountain room - 1 or +1
//But we need a way to assign the rooms via their coordinates. Entrance is always 0 - 0. Fountain in the top row. 
public class World
{
   //the (int, int) is our KEY which is col and rows. The Room is our VALUE.
   private Dictionary<(int, int), Room> _roomMap = new Dictionary<(int, int), Room>();
   private static WorldSize UserChooseWorldSize()
   {
      
      while (true)
      {
          Console.WriteLine("What size world would you like? Options are: 'small', 'medium', or 'large'.");
          string userInput = Console.ReadLine()?.ToLower() ?? string.Empty;

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

   public static Room.RoomTypes ReturnRoomType(int col, int row, int gridSize)
   {
      int randomCol = new HelperUtils().ReturnRandom(gridSize);
      int randomRow = new HelperUtils().ReturnRandom(gridSize);
       
      if(col == 0 && row == 0) return Room.RoomTypes.Entrance;

      foreach (Room.RoomTypes type in Enum.GetValues(typeof(Room.RoomTypes)))
      {
         AddRooms(randomRow, randomCol, type);
         
      }
      
      
      return Room.RoomTypes.Normal;


   }
   private void GenerateRoomTypes(int numRows, int numCols, int numRooms)
   {
      int spacing = Math.Max(numRows, numCols) / numRooms;
      int row = spacing / 2;
      int col = spacing / 2;
   }
   private void AddRooms(int gridSize, Room.RoomTypes rType)
   {
       for (int row = 0; row < gridSize; row++)
       {
          for (int col = 0; col < gridSize; col++)
          {
             Room room = new(row, col, rType);
             _roomMap.Add((row, col), room);
          }
       }
   }
   
   
   public WorldSize ReturnWorldSize = UserChooseWorldSize();
   public void SetWorldSize()
   {
      
      switch (ReturnWorldSize)
      {
         case WorldSize.Small:
            AddRooms(4);

            foreach (KeyValuePair<(int, int), Room> kvp in _roomMap)
            {
               Console.WriteLine($"{kvp.Key}, {kvp.Value}");
            }

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


   public enum WorldSize
   {
      Small,
      Medium,
      Large
   }
   
}