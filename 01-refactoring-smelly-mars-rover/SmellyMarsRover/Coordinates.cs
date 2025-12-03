namespace SmellyMarsRover;

public record Coordinates(int X, int Y)
{
    public Coordinates DisplaceAlongYAxis(int displacement)
    {
        return new Coordinates(this.X, this.Y + displacement);
    }

    public Coordinates DisplaceAlongXAxis(int displacement)
    {
        return new Coordinates(this.X + displacement, this.Y);
    }
}
