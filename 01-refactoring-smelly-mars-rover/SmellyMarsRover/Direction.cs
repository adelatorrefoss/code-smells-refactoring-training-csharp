using System;

namespace SmellyMarsRover;

public record Direction(string direction)
{
    private const string NORTH = "N";
    private const string SOUTH = "S";
    private const string EAST = "E";
    private const string WEST = "W";

    public static Direction Create(string directionEncoding)
    {
        if (directionEncoding.Equals(NORTH)) return new North(); 
        return new Direction(directionEncoding);
    }

    private record North() : Direction(NORTH)
    {
        public override Direction RotateRoverLeft()
        {
            return Create(WEST);
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

    public virtual Direction RotateRoverLeft()
    {
        if (IsFacingNorth())
        {
            throw new NotImplementedException();
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
