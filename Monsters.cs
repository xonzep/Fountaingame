namespace FountainOfObjects;

//I moved the player but now I need to move the Maelstrom room away.
public class Monsters
{
   public void MaelstromAttack(Player player, World world)
   {
      bool MaelstromCurrent = world._roomMap.TryGetValue(RoomTypes.Maelstrom,);
      Location MaelstromMoveLocation = new(MaelstromCurrent.Row + 1, MaelstromCurrent.Col + 2);
      if (player.IsOnMap(MaelstromMoveLocation))
      {
         if (world.ReturnRoom(MaelstromMoveLocation).RoomTypes == RoomTypes.Empty)
         {
            world.ReturnRoom(MaelstromMoveLocation).RoomTypes = RoomTypes.Maelstrom;

         }
      }

      HelperUtils.WriteColorLine("The Maelstrom's attack sends you back out of the room and three rooms away!", ConsoleColor.DarkRed);
      int playerLocRow = player.Location.Row - 1;
      int playerLocCol = player.Location.Col - 2;
      player.Location = new Location(playerLocRow, playerLocCol);

      

   }
}