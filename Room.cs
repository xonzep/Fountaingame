
namespace FountainOfObjects;

public class Room
{
    private int Row { get; }
    private int Col { get; }
    private RoomTypes RTypes { get; set; }
    

    public Room(int row, int col, RoomTypes rTypes)
    {
        Row = row;
        Col = col;
        RTypes = rTypes;
    }

   

    private string RoomDescription(int col, int row)
    {
        RoomTypes roomType = World.ReturnRoomType(col, row);
        
        //Apparently we can use a dictionary to return our description instead of a switch statement.
        Dictionary<RoomTypes, string> typeDescriptions = new Dictionary<RoomTypes, string>
        {
            { RoomTypes.Entrance, "You see light coming from the cave entrance" },
            { RoomTypes.Fountain, "The sound of flowing water fills the room" },
            { RoomTypes.Normal, "A quiet and ordinary room" },
            { RoomTypes.PastMap, "There is a wall here." }
        };
        
        if (typeDescriptions.TryGetValue(roomType, out string? description))
        {
            return description;
        }
    
        throw new ArgumentOutOfRangeException();
    }


    private bool FountainRoom()
    {
        bool isFountain = false;

        return isFountain;
    }
    

    public override string ToString()
    {
        string info = $"You enter the room at {Row} and {Col}. ";
        
        return info + RoomDescription(Row, Col);
    }

    public enum RoomTypes
    {
        Entrance,
        Fountain,
        Normal,
        PastMap
    }
}