using Godot;
using System;
using System.Linq;

public partial class Rectangle : Node2D
{
	Polygon2D poly = new();

	public override void _Ready()
	{
		AddChild(poly);
		// DrawText(new Vector2(100, 100), "1");
	}

	public void DrawText(Vector2 position, string text)
	{
		SystemFont font = new()
		{
			FontNames = new string[] { "Arial" }
		};
		// parent.DrawString(font, position, text);

		Label label = new()
		{
			Text = text,
			Position = position
		};
		AddChild(label);
	}

	float time;

	public override void _Process(double delta)
	{
		time += (float)delta;

		// DrawRectangleUsingArrayScript();
		DrawRectangleUsingScalarScript();
	}

	private void DrawRectangleUsingArrayScript()
	{
		float[] p5 = new float[8];
		float[] p6 = new float[8];
		float[] p7 = new float[8];
		float[] p8 = new float[8];

		RotatingRectangleArray.Execute(0.1f * time, p5, p6, p7, p8);

		DrawPolygon(new Vector2[]
		{
			100 * p5.ToVector2(),
			100 * p6.ToVector2(),
			100 * p7.ToVector2(),
			100 * p8.ToVector2()
		});
	}

	private void DrawRectangleUsingScalarScript()
	{
		(float p5_1, float p5_e01, float p5_e12, float p5_e02,
		float p6_e01, float p6_e12, float p6_e02, float p6_1,
		float p7_1, float p7_e01, float p7_e12, float p7_e02,
		float p8_1, float p8_e01, float p8_e12, float p8_e02) = RotatingRectangle.Execute(0.1f * time);

		DrawPolygon(new Vector2[]
		{
			100 * CreatePoint(p5_e02, p5_e12, p5_e01),
			100 * CreatePoint(p6_e02, p6_e12, p6_e01),
			100 * CreatePoint(p7_e02, p7_e12, p7_e01),
			100 * CreatePoint(p8_e02, p8_e12, p8_e01)
		});
	}

	public static Vector2 CreatePoint(float e02, float e12, float e01)
	{
		// [4]: e0 ^ e1
		// [5]: e0 ^ e2
		// [6]: e1 ^ e2
		return new Vector2((float)(-e02 / e12), (float)(1f * e01 / e12));
	}

	private void DrawPolygon(Vector2[] points, Color? color = null)
	{
		poly.Polygon = points;
		poly.Offset = new Vector2(200, 200);
		poly.Color = color ?? new Color("Black");
	}
}

public class Line
{
	public float Distance { get; }
	public float NormalX { get; }
	public float NormalY { get; }

	public Line(float e0, float e1, float e2)
	{
		Distance = e0;
		NormalX = e1;
		NormalY = e2;
	}
}

// private final String LineClassString
//         = "public class Line" + newline
//         + "{" + newline
//         + "{" + newline
//         + "}" + newline;