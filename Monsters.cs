namespace FountainOfObjects;

//I moved the player but now I need to move the Maelstrom room away.
public abstract class Monsters
{
   public static void MaelstromAttack(Player player, World world)
   {
      Location? maelstromCurrent = GameUtils.FindRoomInMap(world, RoomTypes.Maelstrom);
      
      //Move Maelstrom.
      if (player.Location == maelstromCurrent)
      {
         Location maelstromMoveLocation;
         if(player.IsOnMap(maelstromMoveLocation = new Location(maelstromCurrent.Row + 1, maelstromCurrent.Col + 2)))
         {
             if( world.ReturnRoom(maelstromMoveLocation).RoomTypes == RoomTypes.Empty)
             {
                Room room = world.ReturnRoom(maelstromMoveLocation);
                room.RoomTypes = RoomTypes.Maelstrom;
                room.UpdateDescription();
             }
         }
         else
         {
            //if the room doesn't exist.
             world.AddRoomsByPercentageWithLimit(RoomTypes.Maelstrom, 100, 1);
         }
      }
       //Move player.
      int playerLocRow = player.Location.Row - 1;
      int playerLocCol = player.Location.Col - 2;
      
      if (player.IsOnMap(player.Location = new Location(playerLocRow, playerLocCol)))
      {
         HelperUtils.WriteColorLine("You hit the wall rooms away and you can no longer hear the maelstrom.", ConsoleColor.Magenta);
      }
      else
      {
         HelperUtils.WriteColorLine("You were thrown from the room and into the wall behind you. The impact crushes your ribs and you die.", ConsoleColor.Red);
         player.PlayerDeath();
      }
      
   }
}