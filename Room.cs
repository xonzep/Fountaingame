namespace FountainOfObjects;

public class Room
{
    private int Row { get; }
    private int Col { get; }
    private string Description { get; set; }
    

    public Room(int row, int col)
    {
        Row = row;
        Col = col;
        Description = RoomEffects(row, col);
    }

    private static RoomTypes ReturnRoomType(int col, int row)
    {
        World getWorldSize = new();
        
        if(col == 0 && row == 0) return RoomTypes.Entrance;
        
        
    }

    private string RoomEffects(int col, int row)
    {
        switch (ReturnRoomType(col, row))
        {
            case RoomTypes.Entrance:
                Description = "You see light coming from the cave entrance";
                return Description;
            
            case RoomTypes.Fountain:
                return Description;
            
            case RoomTypes.Normal:
                Description = "Does this work?";
                return Description;
            
            case RoomTypes.PastMap:
                 return Description;
            
            default:
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
    

    private bool FountainRoom()
    {
        bool isFountain = false;

        return isFountain;
    }
    

    public override string ToString()
    {
        string info = $"You enter the room at {Row} and {Col}. ";
        
        return info + Description;
    }

    public enum RoomTypes
    {
        Entrance,
        Fountain,
        Normal,
        PastMap
    }
}