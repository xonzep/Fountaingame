
namespace FountainOfObjects;


/*
 * Room handles it's location(col, row), room type, and description. World just needs the map and then take in the room object.
 */


public class Room
{
    private int Row { get; set; }
    private int Col { get; set; }
    
    public string Description { get; set; }

    public RoomTypes RoomTypes { get; set; }

    public Room(int col, int row, RoomTypes roomTypes)
    {
        Col = col;
        Row = row;
        RoomTypes = roomTypes;
        Description = RoomDescription(roomTypes);
    }
    
    public string RoomDescription(RoomTypes roomType)
    {
        
        //Apparently we can use a dictionary to return our description instead of a switch statement.
        Dictionary<RoomTypes, string> typeDescriptions = new()
        {           //key                   //Value
            { RoomTypes.Entrance, "You see light coming from the cave entrance." },
            { RoomTypes.Fountain, "The sound of flowing water fills the room." },
            { RoomTypes.Empty,    "A quiet and ordinary room." }
        };
        
        if (typeDescriptions.TryGetValue(roomType, out string? description))
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
    Fountain
}
