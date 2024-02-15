using System;

using Godot;
public static class LinePolygon
{
	public static (Vector2, Vector2) Execute(float ax, float ay, float bx, float by, float cx, float cy, float halfWidth)
	{
		float a_e02 = (-ax);
		float b_e02 = (-bx);
		float c_e02 = (-cx);
		float firstLine__e0 = (-a_e02) * by + (-(ay * (-b_e02)));
		float firstLine__e1 = (-(by + (-ay)));
		float firstLine__e2 = (-b_e02) + a_e02;
		float firstLine_e0 = firstLine__e0 * MathF.Sqrt(MathF.Abs(firstLine__e1 * firstLine__e1 + firstLine__e2 * firstLine__e2)) / MathF.Sqrt(MathF.Abs((firstLine__e1 * firstLine__e1 + firstLine__e2 * firstLine__e2) * (firstLine__e1 * firstLine__e1 + firstLine__e2 * firstLine__e2)));
		float firstLine_e1 = firstLine__e1 * MathF.Sqrt(MathF.Abs(firstLine__e1 * firstLine__e1 + firstLine__e2 * firstLine__e2)) / MathF.Sqrt(MathF.Abs((firstLine__e1 * firstLine__e1 + firstLine__e2 * firstLine__e2) * (firstLine__e1 * firstLine__e1 + firstLine__e2 * firstLine__e2)));
		float firstLine_e2 = firstLine__e2 * MathF.Sqrt(MathF.Abs(firstLine__e1 * firstLine__e1 + firstLine__e2 * firstLine__e2)) / MathF.Sqrt(MathF.Abs((firstLine__e1 * firstLine__e1 + firstLine__e2 * firstLine__e2) * (firstLine__e1 * firstLine__e1 + firstLine__e2 * firstLine__e2)));
		float firstLineLeft_e0 = firstLine_e0 - halfWidth;
		float firstLineRight_e0 = firstLine_e0 + halfWidth;
		float secondLine__e0 = (-b_e02) * cy + (-(by * (-c_e02)));
		float secondLine__e1 = (-(cy + (-by)));
		float secondLine__e2 = (-c_e02) + b_e02;
		float secondLine_e0 = secondLine__e0 * MathF.Sqrt(MathF.Abs(secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2)) / MathF.Sqrt(MathF.Abs((secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2) * (secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2)));
		float secondLine_e1 = secondLine__e1 * MathF.Sqrt(MathF.Abs(secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2)) / MathF.Sqrt(MathF.Abs((secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2) * (secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2)));
		float secondLine_e2 = secondLine__e2 * MathF.Sqrt(MathF.Abs(secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2)) / MathF.Sqrt(MathF.Abs((secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2) * (secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2)));
		float secondLineLeft_e0 = secondLine_e0 - halfWidth;
		float secondLineRight_e0 = secondLine_e0 + halfWidth;
		float secondPointLeft_1 = firstLine_e1 * secondLine_e1 + firstLine_e2 * secondLine_e2;
		float secondPointLeft_e01 = firstLineLeft_e0 * secondLine_e1 + (-(firstLine_e1 * secondLineLeft_e0));
		float secondPointLeft_e02 = firstLineLeft_e0 * secondLine_e2 + (-(firstLine_e2 * secondLineLeft_e0));
		float secondPointLeft_e12 = firstLine_e1 * secondLine_e2 + (-(firstLine_e2 * secondLine_e1));
		float secondPointRight_1 = firstLine_e1 * secondLine_e1 + firstLine_e2 * secondLine_e2;
		float secondPointRight_e01 = firstLineRight_e0 * secondLine_e1 + (-(firstLine_e1 * secondLineRight_e0));
		float secondPointRight_e02 = firstLineRight_e0 * secondLine_e2 + (-(firstLine_e2 * secondLineRight_e0));
		float secondPointRight_e12 = firstLine_e1 * secondLine_e2 + (-(firstLine_e2 * secondLine_e1));
		
		return (
			new Vector2(-secondPointLeft_e02 / secondPointLeft_e12, secondPointLeft_e01 / secondPointLeft_e12), 
			new Vector2(-secondPointRight_e02 / secondPointRight_e12, secondPointRight_e01 / secondPointRight_e12)
		);
	}
}
