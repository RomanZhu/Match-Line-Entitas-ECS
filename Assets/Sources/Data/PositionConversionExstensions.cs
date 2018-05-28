using UnityEngine;

public static class PositionConversionExstensions
{
    public static Vector3 ToVector3(this GridPosition position)
    {
        var result = new Vector3(position.x, position.y);
        if (position.x % 2 == 0)
            result.y -= 0.5f;
        return result;
    }

    public static GridPosition ToGridPosition(this Vector3 position)
    {
        var x = Mathf.RoundToInt(position.x);

        if (x % 2 == 0)
            position.y += 0.5f;
        var y = Mathf.RoundToInt(position.y);

        var result = new GridPosition(x, y);
        return result;
    }
}