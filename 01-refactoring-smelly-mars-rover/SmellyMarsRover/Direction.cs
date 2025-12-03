namespace SmellyMarsRover;

public record Direction(string direction)
{
    public static Direction Create(string direction)
    {
        return new Direction(direction);
    }

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

    public Direction RotateRoverLeft()
    {
        if (IsFacingNorth())
        {
            return Create("W");
        }

        if (IsFacingSouth())
        {
            return Create("E");
        }

        if (IsFacingWest())
        {
            return Create("S");
        }

        return Create("N");
    }
}
