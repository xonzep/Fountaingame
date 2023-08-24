
namespace FountainOfObjects;


/*
 * Room handles it's room type, and description. World just needs the map and then take in the room object.
 * I use to have the location row and col taken in, but I don't think it's needs as the map dictionary takes that on.
 */


public class Room
{
    public string? Description { get; private set; }

    public RoomTypes RoomTypes { get; set; }
    
    

    public Room(RoomTypes roomTypes)
    {
        RoomTypes = roomTypes;
        Description = RoomDescription(roomTypes);
    }
    
    private string RoomDescription(RoomTypes roomType)
    {
        
        //Apparently we can use a dictionary to return our description instead of a switch statement.
        //Monsters kill instantly so monsters are just roomtypes.
        Dictionary<RoomTypes, string> typeDescriptions = new()
        {           //key                   //Value
            { RoomTypes.Entrance, "You see light coming from the cave entrance." },
            { RoomTypes.Fountain, "There is a dripping sound here." },
            { RoomTypes.FountainOn, "The sound of flowing water fills the room. The Fountain is on." },
            { RoomTypes.Empty,    "You are in a quiet and ordinary room." },
            { RoomTypes.Pit,  "You fall into a pit and die."},
            {RoomTypes.Maelstrom, "You encounter a monster of wind. It's attack blows you out of the room"},
            { RoomTypes.Amaroks , "You encounter a monster of decay. It attacks you, ripping your body to shreds. You die."}
        };
        
        if (typeDescriptions.TryGetValue(roomType, out string? description))
        {
            
            return description;
        }

        return "You should not see this.";
    }
    
    public void UpdateDescription()
    {
        Description = RoomDescription(RoomTypes);
    }

    
}

public enum RoomTypes
{
    Empty,
    Entrance,
    Fountain,
    FountainOn,
    Pit,
    Maelstrom,
    Amaroks
}
