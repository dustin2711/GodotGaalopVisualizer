using System.Collections.Generic;
using Godot;

public static class Geometry
{
    public static List<Vector2> CreateSpiral(float startingRadius, float endingRadius, int roundCount, int pointCountPerRound)
    {
        List<Vector2> points = new();

        int totalPointCount = roundCount * pointCountPerRound;
        float angleStep = 2 * Mathf.Pi / pointCountPerRound;

        float currentRadius = startingRadius;
        float radiusIncrement = (endingRadius - startingRadius) / totalPointCount;

        for (int roundIndex = 0; roundIndex < roundCount; roundIndex++)
        {
            float angle = 0;

            for (int index = 0; index < pointCountPerRound; index++)
            {
                float x = currentRadius * Mathf.Cos(angle);
                float y = currentRadius * Mathf.Sin(angle);

                points.Add(new Vector2(x, y));

                // Increase angle and radius for next step
                angle += angleStep;
                currentRadius += radiusIncrement;
            }
        }

        return points;
    }

}