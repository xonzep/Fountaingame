
namespace FountainOfObjects;


/*
 * Room handles it's location(col, row), room type, and description. World just needs the map and then take in the room object.
 */


public class Room
{
    private int _row;
    private int _col;

    private string _description;

    public RoomTypes RoomTypes { get; set; }

    public Room(int col, int row, RoomTypes roomTypes)
    {
        _col = col;
        _row = row;
        RoomTypes = roomTypes;
        _description = RoomDescription();
    }
    
    private string RoomDescription()
    {
        
        //Apparently we can use a dictionary to return our description instead of a switch statement.
        Dictionary<RoomTypes, string> typeDescriptions = new()
        {           //key                   //Value
            { RoomTypes.Entrance, "You see light coming from the cave entrance." },
            { RoomTypes.Fountain, "The sound of flowing water fills the room." },
            { RoomTypes.Empty,    "A quiet and ordinary room." },
            { RoomTypes.PastMap,  "There is a wall here." }
        };
        
        if (typeDescriptions.TryGetValue(RoomTypes, out string? description))
        {
            return description;
        }

        return "You should not see this.";
    }
}

public enum RoomTypes
{
    Empty,
    Entrance,
    Fountain,
    PastMap
}
