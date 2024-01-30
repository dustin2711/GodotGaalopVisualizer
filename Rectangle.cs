using Godot;
using System;
using System.Linq;

public partial class Rectangle : Node2D
{
	private float time;

	private Polygon2D poly = new();

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

	public override void _Process(double delta)
	{
		time += 0.1f * (float)delta;


		// Vector2[] points = DrawRectangleUsingArrays();
		Vector2[] points = DrawRectangleUsingTuples();
		// Vector2[] points = DrawRectangleUsingScalarScript();

		points = points.Select(p => new Vector2(100, 100) + 100 * p).ToArray();

		GD.Print(points.JoinString());

		DrawPolygon(points);
	}

	// private Vector2[] DrawRectangleUsingArrays()
	// {
	// 	float[] p5 = new float[8];
	// 	float[] p6 = new float[8];
	// 	float[] p7 = new float[8];
	// 	float[] p8 = new float[8];

	// 	RotatingRectangle.Execute(time, p5, p6, p7, p8);

	// 	return new Vector2[]
	// 	{
	// 		p5.ToVector2(),
	// 		p5.ToVector2(),
	// 		p5.ToVector2(),
	// 		p5.ToVector2()
	// 	};
	// }

	private Vector2[] DrawRectangleUsingTuples()
	{
		// (float p5_e01, float p5_e12, float p5_e02,
		//  float p6_e01, float p6_e12, float p6_e02,
		//  float p7_e01, float p7_e12, float p7_e02,
		//  float p8_e02, float p8_e01, float p8_e12) = RotatingRectangle.Execute(0 * time);

		(float p5_1, float p5_e01, float p5_e12, float p5_e02,
		 float p6_e01, float p6_e12, float p6_e02, float p6_1,
		 float p7_1, float p7_e01, float p7_e12, float p7_e02,
		 float p8_1, float p8_e01, float p8_e12, float p8_e02) = RotatingRectangle.Execute(time);

		return new Vector2[]
		{
			CreatePoint(p5_e02, p5_e12, p5_e01),
			CreatePoint(p6_e02, p6_e12, p6_e01),
			CreatePoint(p7_e02, p7_e12, p7_e01),
			CreatePoint(p8_e02, p8_e12, p8_e01)
		};
	}

	// private Vector2[] DrawRectangleUsingScalarScript()
	// {
	// 	(Vector2 p5, Vector2 p6, Vector2 p7, Vector2 p8)
	// 		= RotatingRectangle.Execute(0 * time);

	// 	GD.Print(p5);

	// 	return new Vector2[] { p5, p6, p7, p8 };
	// }

	public static Vector2 CreatePoint(float e02, float e12, float e01)
	{
		// [4]: e0 ^ e1
		// [5]: e0 ^ e2
		// [6]: e1 ^ e2
		return new Vector2(-e02 / e12, e01 / e12);
	}

	private void DrawPolygon(Vector2[] points, Color? color = null)
	{
		poly.Polygon = points;
		poly.Offset = new Vector2(200, 200);
		poly.Color = color ?? new Color("Black");
	}
}


// private final String LineClassString
//         = "public class Line" + newline
//         + "{" + newline
//         + "{" + newline
//         + "}" + newline;


/*
Only difference: sign

		float p7_e01 = ((-M_1) + sinus_1) * M_1 + (-((M_1 +   sinus_1)  * (-sinus_1)));
		float p8_e01 = (  M_1  + sinus_1) * M_1 + (-((M_1 + (-sinus_1)) * (-sinus_1)));
*/