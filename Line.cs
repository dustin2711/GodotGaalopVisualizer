using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Line : Node2D
{
	private static List<Vector2> CreateSpiral(float diameter, int roundCount, int pointCountPerRound)
	{
		List<Vector2> points = new();

		int totalPointCount = roundCount * pointCountPerRound;
		float angleStep = 2 * Mathf.Pi / pointCountPerRound;

		float radius = diameter / 2f;
		float currentRadius = 0;
		float radiusIncrement = radius / totalPointCount;

		for (int roundIndex = 0; roundIndex < roundCount; roundIndex++)
		{
			for (int pointIndex = 0; pointIndex < pointCountPerRound; pointIndex++)
			{
				float angle = pointIndex * angleStep;

				float x = currentRadius * Mathf.Cos(angle);
				float y = currentRadius * Mathf.Sin(angle);

				points.Add(new Vector2(x, y));

				// Increase radius for the next point
				currentRadius += radiusIncrement;
			}
		}

		return points;
	}

	private Vector2[] Points = CreateSpiral(400, 4, 32).ToArray();

	// private Vector2[] Points = new Vector2[]
	// {
	// 	new(100, 100),
	// 	new(300, 100),
	// 	new(300, 300),
	// 	new(500, 300),
	// 	new(500, 500),
	// };

	private Vector2 PointA => Points[0];

	private Vector2 PointB => Points[1];

	private Vector2 PointC => Points[2];

	private Vector2 PointD => Points[3];

	private float halfWidth = 10f;

	private Polygon2D poly = new();

	Line2D line = new();

	private float time;

	public override void _Input(InputEvent @event)
	{
		// Place or rotate preview structure
		if (@event is InputEventMouseButton mouseEvent
			&& !mouseEvent.Pressed)
		{
			if (mouseEvent.ButtonIndex is MouseButton.WheelDown or MouseButton.WheelUp)
			{
				bool scrollingUp = mouseEvent.ButtonIndex == MouseButton.WheelUp;
				halfWidth += scrollingUp ? 3 : -3;
			}
		}
	}

	public override void _Ready()
	{
		AddChild(poly);
		AddChild(line);
	}

	public override void _Process(double delta)
	{
		time += 0.1f * (float)delta;

		Vector2[] points;

		points = GetPointsUsingGaalop();
		// GD.Print("Array: " + points.JoinString());
		// points = GetPointsUsingTuples();
		// GD.Print("Tuples: " + points.JoinString());
		// points = GetPointsUsingVector2();
		// GD.Print("Vector2: " + points.JoinString());

		// Add offset and widen
		// points = points.Select(p => new Vector2(100, 100) + 200 * p).ToArray();
		GD.Print("Transformed: " + points.JoinString());


		DrawLinePolygon(points);
	}

	private Vector2[] GetPointsUsingGaalop()
	{
		float firstLine__e0;
		float firstLine__e1;
		float firstLine__e2;
		float firstLineLength;
		float firstLine_e0;
		float firstLine_e1 = 0;
		float firstLine_e2 = 0;
		float firstLineLeft_e0 = 0;
		float firstLineRight_e0 = 0;

		// List<Vector2> leftPoints = new();
		// List<Vector2> rightPoints = new();

		// Number of loops
		int count = Points.Count() - 2;

		Vector2[] points = new Vector2[2 * count];

		for (int index = 0; index < count; index++)
		{
			Vector2 lastPoint = Points[index];
			Vector2 point = Points[index + 1];
			Vector2 nextPoint = Points[index + 2];

			float ax = lastPoint.X;
			float ay = lastPoint.Y;
			float bx = point.X;
			float by = point.Y;
			float cx = nextPoint.X;
			float cy = nextPoint.Y;

			if (index == 0)
			{
				firstLine__e0 = ax * by - ay * bx;
				firstLine__e1 = -by + ay;
				firstLine__e2 = bx - ax;
				firstLineLength = MathF.Sqrt(firstLine__e1 * firstLine__e1 + firstLine__e2 * firstLine__e2) / (firstLine__e1 * firstLine__e1 + firstLine__e2 * firstLine__e2); // Simplified
				firstLine_e0 = firstLine__e0 * firstLineLength;
				firstLine_e1 = firstLine__e1 * firstLineLength;
				firstLine_e2 = firstLine__e2 * firstLineLength;
				firstLineLeft_e0 = firstLine_e0 - halfWidth;
				firstLineRight_e0 = firstLine_e0 + halfWidth;
			}

			float secondLine__e0 = bx * cy - by * cx;
			float secondLine__e1 = -cy + by;
			float secondLine__e2 = cx - bx;
			float secondLineLength = MathF.Sqrt(secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2) / (secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2);
			float secondLine_e0 = secondLine__e0 * secondLineLength;
			float secondLine_e1 = secondLine__e1 * secondLineLength;
			float secondLine_e2 = secondLine__e2 * secondLineLength;
			float secondLineLeft_e0 = secondLine_e0 - halfWidth;
			float secondLineRight_e0 = secondLine_e0 + halfWidth;
			float secondPointLeft_e01 = firstLineLeft_e0 * secondLine_e1 - firstLine_e1 * secondLineLeft_e0;
			float secondPointLeft_e02 = firstLineLeft_e0 * secondLine_e2 - firstLine_e2 * secondLineLeft_e0;
			float secondPointLeft_e12 = firstLine_e1 * secondLine_e2 - firstLine_e2 * secondLine_e1;
			float secondPointRight_e01 = firstLineRight_e0 * secondLine_e1 - firstLine_e1 * secondLineRight_e0;
			float secondPointRight_e02 = firstLineRight_e0 * secondLine_e2 - firstLine_e2 * secondLineRight_e0;
			float secondPointRight_e12 = firstLine_e1 * secondLine_e2 - firstLine_e2 * secondLine_e1;

			Vector2 left = new(-secondPointLeft_e02 / secondPointLeft_e12, secondPointLeft_e01 / secondPointLeft_e12);
			Vector2 right = new(-secondPointRight_e02 / secondPointRight_e12, secondPointRight_e01 / secondPointRight_e12);

			points[index] = left;
			points[2 * count - 1 - index] = right;

			// leftPoints.Add(left);
			// rightPoints.Add(right);

			firstLine_e1 = secondLine_e1;
			firstLine_e2 = secondLine_e2;
			firstLineLeft_e0 = secondLineLeft_e0;
			firstLineRight_e0 = secondLineRight_e0;
		}

		// rightPoints.Reverse();
		// return leftPoints.Concat(rightPoints).ToArray();

		return points;
	}

	// private Vector2[] GetPointsUsingArrays()
	// {
	// 	float[] aL = new float[8];
	// 	float[] aR = new float[8];
	// 	float[] bL = new float[8];
	// 	float[] bR = new float[8];

	// 	LinePolygon.Execute(PointA.X, PointA.Y, PointB.X, PointB.Y, PointC.X, PointC.Y, LineWidth, aL, aR, bL, bR);

	// 	Vector2 CreatePoint(float[] array)
	// 		=> new(-array[5] / array[6], array[4] / array[6]);

	// 	return new Vector2[]
	// 	{
	// 		CreatePoint(aL),
	// 		CreatePoint(aR),
	// 		CreatePoint(bR),
	// 		CreatePoint(bL),
	// 	};
	// }

	// private Vector2[] GetPointsUsingTuples()
	// {
	// 	(float p5_1, float p5_e01, float p5_e12, float p5_e02,
	// 	 float p6_e01, float p6_e12, float p6_e02, float p6_1,
	// 	 float p7_1, float p7_e01, float p7_e12, float p7_e02,
	// 	 float p8_1, float p8_e01, float p8_e12, float p8_e02) = RotatingRectangleTuples.Execute(time);

	// 	Vector2 CreatePoint(float e02, float e12, float e01)
	// 		=> new(-e02 / e12, e01 / e12);

	// 	return new Vector2[]
	// 	{
	// 		CreatePoint(p5_e02, p5_e12, p5_e01),
	// 		CreatePoint(p6_e02, p6_e12, p6_e01),
	// 		CreatePoint(p7_e02, p7_e12, p7_e01),
	// 		CreatePoint(p8_e02, p8_e12, p8_e01)
	// 	};
	// }

	// private Vector2[] GetPointsUsingVector2()
	// {
	// 	(Vector2 p5, Vector2 p6, Vector2 p7, Vector2 p8) = RotatingRectangleVector2.Execute(time);

	// 	return new Vector2[] { p5, p6, p7, p8 };
	// }

	/*
		Blade-array-conversion:
		[4]: e01
		[5]: e02
		[6]: e12
	*/
	private void DrawLinePolygon(Vector2[] points, Color? color = null)
	{
		line.Points = Points;
		line.DefaultColor = color ?? Colors.White;
		line.Width = 1;
		// line.Closed = true;

		poly.Polygon = points;
		poly.Color = color ?? Colors.Black;
	}
}
