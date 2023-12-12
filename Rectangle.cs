using Godot;
using System;
using System.Linq;

public partial class Rectangle : Node2D
{
	Polygon2D poly = new();

	public override void _Ready()
	{
		AddChild(poly);
		// DrawText(new Vector2(100, 100), "1111111");
		// DrawText(new Vector2(-100, 100), "22222222");
		// DrawText(new Vector2(100, -100), "33333333");
		// DrawText(new Vector2(-100, -100), "44444444444");
	}

	public void DrawText(Vector2 position, string text)
	{
		SystemFont font = new();
		font.FontNames = new string[] { "Arial" };
		// parent.DrawString(font, position, text);

		Label label = new();
		label.Text = text;
		label.Position = position;
		AddChild(label);
	}

	double time;

	public override void _Process(double delta)
	{
		time += delta;

		float[] p5 = new float[8];
		float[] p6 = new float[8];
		float[] p7 = new float[8];
		float[] p8 = new float[8];
		
		RotatingRectangle.Execute(0.1f * (float)time, p5, p6, p7, p8);

		GD.Print(p5.ToVector2());

		DrawLine(new Vector2[] { 100 * p5.ToVector2(), 100 * p6.ToVector2(), 100 * p7.ToVector2(), 100 * p8.ToVector2()});//, 92 * p5.ToVector2()} );
//		DrawNewPoint(offset + 100 * p5.ToVector2());
//		DrawNewPoint(offset + 100 * p6.ToVector2());
//		DrawNewPoint(offset + 100 * p7.ToVector2());
//		DrawNewPoint(offset + 100 * p8.ToVector2());
	}
	
	private void DrawLine(Vector2[] points, string text = "", Color? color = null)
	{
		poly.Polygon = points;
//		poly.Polygon = new LineBuilder(this, points.ToList(), 10).CreatePoints();
		poly.Offset = new Vector2(200, 200); 
		poly.Color = color ?? new Color("Black");
	}

//	private void DrawNewPoint(Vector2 position, string text = "", Color? color = null)
//	{
//		const float radius = 6;
//
//		Polygon2D poly = new();
//		poly.Polygon = new Vector2[]
//		{
//			new(0, radius),
//			new(radius, 0),
//			new(0, -radius),
//			new(-radius, 0),
//		};
//
//		poly.Offset = position;
//		poly.Color = color ?? new Color("Black");
//		AddChild(poly);
//	}

}
