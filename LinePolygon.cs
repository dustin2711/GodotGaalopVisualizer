using Godot;
using System;
using System.Diagnostics;
using System.Collections.Generic;

public partial class LinePolygon : Node2D
{
	Polygon2D poly = new()
	{
		Color = new Color("Orange")
	};

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AddChild(poly);

	}

	public override void _Process(double delta)
	{
		var points = new List<Vector2>()
		{
			new Vector2(0, 0),
			new Vector2(100, 100),
			new Vector2(200, 150),
			new Vector2(300, 180),
			new Vector2(400, 190),
			new Vector2(500, 195),
			new Vector2(600, 197),
		};
		poly.Polygon = new LineBuilder(this, points).CreatePoints();
	}
}
