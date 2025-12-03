namespace SmellyMarsRover;

public record Direction(string direction)
{
    private const string WEST = "W";
    private const string EAST = "E";
    private const string SOUTH = "S";
    private const string NORTH = "N";

    public static Direction Create(string direction)
    {
        return new Direction(direction);
    }

    public bool IsFacingWest()
    {
        return direction.Equals(WEST);
    }

    public bool IsFacingSouth()
    {
        return direction.Equals(SOUTH);
    }

    public bool IsFacingNorth()
    {
        return direction.Equals(NORTH);
    }

    public Direction RotateRoverLeft()
    {
        if (IsFacingNorth())
        {
            return Create(WEST);
        }

        if (IsFacingSouth())
        {
            return Create(EAST);
        }

        if (IsFacingWest())
        {
            return Create(SOUTH);
        }

        return Create(NORTH);
    }
}
