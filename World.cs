namespace FountainOfObjects;



public class World
{
   private readonly string _userInput = InputUtils.GetStringToLower("What size world would you like? Options are: Small, Medium, and Large", "That is not an option.");
    
   //the (int, int) is our KEY which is col and rows. The Room is our VALUE.
   private Dictionary<(int, int), Room> _roomMap = new Dictionary<(int, int), Room>();

   private WorldSize PickWorldSize()
   {
      return _userInput switch
      {
         "small" => WorldSize.Small,
         "medium" => WorldSize.Medium,
         "large" => WorldSize.Large,
         _ => WorldSize.Small
      };
   }
   
   private void AddRooms(int roomAmount)
   {
      int centerRow = roomAmount - 1;
      int centerCol = roomAmount / 2;
      
      for (int row = 0; row < roomAmount; row++)
      {
         for (int col = -centerCol; col <= centerCol; col++)
         {
            int adjustedRow = centerRow - row;
            (int adjustedRow, int col) coordinates = (adjustedRow, col);
            Room room = new(row, col);
            _roomMap.Add(coordinates, room);
         }
      }
   }
   
   private void SetWorldSize()
   {
      switch (PickWorldSize())
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