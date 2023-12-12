using System;
using Godot;

public static class Vector2Extensions
{
    public static float Orientation(this Vector2 vector) => Mathf.Atan2(vector.Y, vector.X);

    public static Vector2 ToVector2MovedInDirection(this Vector2 vector, float distance, float orientation)
    {
        return new Vector2(
            vector.X + Mathf.Cos(orientation) * distance,
            vector.Y + Mathf.Sin(orientation) * distance);
    }

    public static Vector2 MoveInDirection(this Vector2 vector, float distance, float orientation)
    {
        if (distance != 0)
        {
            vector.X += Mathf.Cos(orientation) * distance;
            vector.Y += Mathf.Sin(orientation) * distance;
        }

        return vector;
    }

    public static bool ValueEquals(this Vector2 vector, Vector2 other, float allowedDistance)
{
            return vector.DistanceTo(other) < allowedDistance;

}
        public static bool ValueEquals(this Vector2 vector, Vector2 point2)
    {
        return vector.X == point2.X && vector.Y == point2.Y;
    }

    // public static bool ValueEquals(this Vector2 vector, float x, float y)
    // {
    //     return vector.X == x && vector.Y == y;
    // }

    public static bool ValueEquals(this Vector2 vector, float x, float y, float allowedDistance)
    {
        return vector.DistanceTo(new Vector2(x, y)) < allowedDistance;
    }
    
    public static float DistanceTo(this Vector2 vector, Vector2 other)
    {
        return vector.DistanceTo(other.X, other.Y);
    }

    public static float DistanceTo(this Vector2 vector, float x, float y)
    {
        float xDif = vector.X - x;
        float yDif = vector.Y - y;
        return Mathf.Sqrt(xDif * xDif + yDif * yDif);
    }

        public static Vector2 RotateAroundPoint(this Vector2 vector, Vector2 pivot, float angle)
    {
        if (angle != 0)
        {
            float deltaX = vector.X - pivot.X;
            float deltaY = vector.Y - pivot.Y;
            float cos = Mathf.Cos(angle);
            float sin = Mathf.Sin(angle);
            vector.X = (cos * deltaX) - (sin * deltaY) + pivot.X;
            vector.Y = (sin * deltaX) + (cos * deltaY) + pivot.Y;
        }
        return vector;
    }

       public static float DotProduct(this Vector2 vector, Vector2 other)
   {
       return vector.X * other.X + vector.Y * other.Y;
   }
}
