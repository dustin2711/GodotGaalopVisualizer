using Godot;
using System;

public enum PolygonCreationType
{
	Legacy,
	LegacyOptimized,
	GaalopFirstTry,
	GaalopOptimized
}

public partial class Line : Node2D
{
	[Export]
	public PolygonCreationType PolygonCreationType = PolygonCreationType.Legacy;

	public static Vector2[] LinePoints = Geometry.CreateSpiral(50, 200, 2, 32).ToArray();

	public static float halfWidth = 10f;

	private Polygon2D poly = new();

	private Line2D line = new();

	public override void _Input(InputEvent @event)
	{
		// Mouse wheel changes line width
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
			PolygonCreationType.Legacy => PolygonFromLineBuilder.Legacy(LinePoints, halfWidth),
			PolygonCreationType.LegacyOptimized => PolygonFromLineBuilder.LegacyOptimized(LinePoints, halfWidth),
			PolygonCreationType.GaalopFirstTry => PolygonFromLineBuilder.GaalopFirstTry(LinePoints, halfWidth),
			PolygonCreationType.GaalopOptimized => PolygonFromLineBuilder.GaalopOptimized(LinePoints, halfWidth),
			_ => throw new Exception()
		};
		GD.Print(PolygonCreationType);
		// points = points.Select(p => new Vector2(100, 100) + 200 * p).ToArray();
		// GD.Print("Points: " + points.JoinString());

		DrawLinePolygon(points);
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
