using System;

public struct GridSize : IEquatable<GridSize>
{
    public int x;
    public int y;

    public GridSize(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public bool Equals(GridSize other)
    {
        return other.x == x && other.y == y;
    }

    //Assuming we will never go bigger/lower than 1024 in Y dimension
    public override int GetHashCode()
    {
        return (x << 10) + y;
    }
}