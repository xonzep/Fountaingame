namespace FountainOfObjects;

//I moved the player but now I need to move the Maelstrom room away.
public class Monsters
{
   public static void MaelstromAttack(Player player, World world)
   {
      Location? maelstromCurrent = GameUtils.FindRoomInMap(world, RoomTypes.Maelstrom);

      if (player.Location == maelstromCurrent)
      {
         Location maelstromMoveLocation = new(maelstromCurrent.Row + 1, maelstromCurrent.Col + 2);

         if (player.IsOnMap(maelstromMoveLocation) && world.ReturnRoom(maelstromMoveLocation).RoomTypes == RoomTypes.Empty)
         {
            world.ReturnRoom(maelstromMoveLocation).RoomTypes = RoomTypes.Maelstrom;
         }
      }
      
      HelperUtils.WriteColorLine("The Maelstrom's attack sends you back out of the room and three rooms away! The Maelstrom also gets blown out of the room!", ConsoleColor.DarkRed);
      int playerLocRow = player.Location.Row - 1;
      int playerLocCol = player.Location.Col - 2;
      player.Location = new Location(playerLocRow, playerLocCol);
      
   }
}