using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public enum PolygonCreationType
{
	Default,
	GaalopOld,
	GaalopNew
}

public partial class Line : Node2D
{
	[Export]
	public PolygonCreationType PolygonCreationType = PolygonCreationType.Default;

	private Vector2[] LinePoints = Geometry.CreateSpiral(50, 200, 2, 32).ToArray();

	private float halfWidth = 10f;

	private Polygon2D poly = new();

	private Line2D line = new();

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
		Vector2[] points = PolygonCreationType switch
		{
			PolygonCreationType.GaalopNew => GetPointsUsingGaalop(),
			PolygonCreationType.GaalopOld => LineBuilder2.Create(LinePoints, halfWidth, true),
			_ => LineBuilder2.Create(LinePoints, halfWidth, false),
		};
		GD.Print(PolygonCreationType);
		// points = points.Select(p => new Vector2(100, 100) + 200 * p).ToArray();
		// GD.Print("Points: " + points.JoinString());

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

		// Number of loops
		int count = LinePoints.Count() - 2;

		Vector2[] points = new Vector2[2 * count];

		for (int index = 0; index < count; index++)
		{
			Vector2 lastPoint = LinePoints[index];
			Vector2 point = LinePoints[index + 1];
			Vector2 nextPoint = LinePoints[index + 2];

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

			firstLine_e1 = secondLine_e1;
			firstLine_e2 = secondLine_e2;
			firstLineLeft_e0 = secondLineLeft_e0;
			firstLineRight_e0 = secondLineRight_e0;
		}

		return points;
	}

	private void DrawLinePolygon(Vector2[] polygonPoints, Color? color = null)
	{
		// line.Points = LinePoints;
		line.Points = polygonPoints;
		line.DefaultColor = color ?? Colors.White;
		line.Width = 1;
		// line.Closed = true;

		poly.Polygon = polygonPoints;
		poly.Color = color ?? Colors.Black;
	}
}
