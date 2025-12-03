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

        public override Direction RotateRight() {
            return Create(EAST);
        }
    }

    private record South() : Direction(SOUTH)
    {
        public override Direction RotateRoverLeft()
        {
            return Create(EAST);
        }

        public override Direction RotateRight() {
            return Create(WEST);
        }
    }

    private record East() : Direction(EAST)
    {
        public override Direction RotateRoverLeft()
        {
            return Create(NORTH);
        }

        public override Direction RotateRight() {
            return Create(SOUTH);
        }
    }

    private record West() : Direction(WEST)
    {
        public override Direction RotateRoverLeft()
        {
            return Create(SOUTH);
        }

        public override Direction RotateRight() {
            return Create(NORTH);
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
    public abstract Direction RotateRight();

    public Coordinates Displace(Coordinates coordinates, int displacement) {
        if (this.IsFacingNorth()) {
            coordinates = coordinates.DisplaceAlongYAxis(displacement);
        }
        else if (this.IsFacingSouth())
        {
            coordinates = coordinates.DisplaceAlongYAxis(-displacement);
        }
        else if (this.IsFacingWest())
        {
            coordinates = coordinates.DisplaceAlongXAxis(-displacement);
        }
        else
        {
            coordinates = coordinates.DisplaceAlongXAxis(displacement);
        }

        return coordinates;
    }
}
