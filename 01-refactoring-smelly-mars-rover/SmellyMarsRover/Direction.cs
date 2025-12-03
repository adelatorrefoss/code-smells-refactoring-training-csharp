namespace SmellyMarsRover;

public abstract record Direction(string direction)
{
    private const string NORTH = "N";
    private const string SOUTH = "S";
    private const string EAST = "E";
    private const string WEST = "W";

    public static Direction Create(string directionEncoding)
    {
        if (directionEncoding.Equals(NORTH)) return new North();
        if (directionEncoding.Equals(SOUTH)) return new South();
        if (directionEncoding.Equals(WEST)) return new West();
        return new East();
    }

    private record North() : Direction(NORTH)
    {
        public override Direction RotateRoverLeft()
        {
            return Create(WEST);
        }
    }

    private record South() : Direction(SOUTH)
    {
        public override Direction RotateRoverLeft()
        {
            return Create(EAST);
        }
    }

    private record East() : Direction(EAST)
    {
        public override Direction RotateRoverLeft()
        {
            return Create(NORTH);
        }
    }

    private record West() : Direction(WEST)
    {
        public override Direction RotateRoverLeft()
        {
            return Create(SOUTH);
        }
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

    public abstract Direction RotateRoverLeft();
}
