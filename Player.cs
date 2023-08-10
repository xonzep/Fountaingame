namespace FountainOfObjects;

public class Player
{
    private Location _location;
    private int _health;
    private Dictionary<(int, int), RoomTypes> _roomMap;

    private Player(Location location, Dictionary<(int, int), RoomTypes> roomMap, int health)
    {
        _location = location;
        _health = health;
        _roomMap = roomMap;
    }

}

//North is UP, South is DOWN, East is RIGHT, West is LEFT
enum Nav
{
    North,
    South,
    East,
    West
}