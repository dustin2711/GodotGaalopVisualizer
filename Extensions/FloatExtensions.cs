using System;
using Godot;

public static class FloatExtensions
{
    public static string ToString(this float value, int maxDecimalPlaces)
    {
        if (float.IsNaN(value))
        {
            return "NaN";
        }

        int precision = 0;
        while (value * Mathf.Pow(10, precision) != Mathf.Round(value * Mathf.Pow(10, precision)))
        {
            precision++;
        }
        return value.ToString("0." + new string('0', precision.Clamp(0, maxDecimalPlaces)));
    }

    public static int ToInt(this float value)
    {
        return Convert.ToInt32(value);
    }

    /// <summary>
    ///   E.g. round to 0.001.
    /// </summary>
    public static float Round(this float value, float roundTo)
    {
        return (float)(Mathf.Round(value / roundTo) * roundTo);
    }

    /// <summary>
    ///   Multiplies the angle with ~0.0175
    /// </summary>
    public static float ToRadian(this float value)
    {
        return value * Mathf.Pi / 180;
    }

    /// <summary>
    ///   Multiplies the angle with ~57.3
    /// </summary>
    public static float ToDegrees(this float value)
    {
        return value * 180 / Mathf.Pi;
    }

    /// <summary>
    ///   Makes sure that this float is inbetween 0 and 2*Pi.
    /// </summary>
    public static float NormalizeAngle(this float angle)
    {
        float normalized = angle % (2 * Mathf.Pi);

        if (normalized < 0)
        {
            normalized += 2 * Mathf.Pi;
        }

        // Debug.Assert(normalized >= 0);

        return normalized;
    }

    public static float Pow(this float value, float exponent)
    {
        return Mathf.Pow(value, exponent);
    }

    public static float Sqrt(this float value)
    {
        return Mathf.Sqrt(value);
    }

    public static float Root(this float value, float root)
    {
        return Mathf.Pow(value, 1.0f / root);
    }

    public static bool IsNan(this float value)
    {
        return float.IsNaN(value);
    }
    public static float Abs(this float value)
    {
        return Mathf.Abs(value);
    }

    public static bool IsAbout(this float value, float otherValue, float epsilon = 0.000001f)
    {
        return Mathf.Abs(value - otherValue) < epsilon;
    }
}