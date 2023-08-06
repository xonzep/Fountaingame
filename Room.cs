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
        Description = RoomEffects();
    }

    private static RoomTypes ReturnRoomType(int col, int row)
    {
        if (col == 0 && row == 0) return RoomTypes.Entrance;
        
        //if (col == col  && row == row / 2) return RoomTypes.Fountain;

        return RoomTypes.Normal;
    }

    private string RoomEffects()
    {
        switch (ReturnRoomType(Col, Row))
        {
            case RoomTypes.Entrance:
                Description = "You see light coming from the cave entrance";
                return Description;
            
            case RoomTypes.Fountain:
                return Description;
            
            case RoomTypes.Normal:
                return Description;
            
            case RoomTypes.PastMap:
                 return Description;
            
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    

    private bool FountainRoom()
    {
        bool isFountain = false;

        return isFountain;
    }
    

    public override string ToString()
    {
        string info = $"You enter the room at {Row} and {Col}. /n";
        
        return info + Description;
    }

    private enum RoomTypes
    {
        Entrance,
        Fountain,
        Normal,
        PastMap
    }
}