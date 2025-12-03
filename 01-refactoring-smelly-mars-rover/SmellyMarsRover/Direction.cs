namespace SmellyMarsRover;

public record Direction(string direction)
{
    public bool IsFacingWest()
    {
        return direction.Equals("W");
    }

    public bool IsFacingSouth()
    {
        return direction.Equals("S");
    }

    public bool IsFacingNorth()
    {
        return direction.Equals("N");
    }
}