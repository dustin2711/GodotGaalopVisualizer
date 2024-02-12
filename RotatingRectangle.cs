using System;

public static class RotatingRectangle
{
	public static float Execute(float TIME)
	{
		float sinus_1 = MathF.Sin(TIME / 2.0f);
		float M_1 = MathF.Cos(TIME / 2.0f);
		float p5_e12 = (-sinus_1) * (-sinus_1) + M_1 * M_1;
		
		return p5_e12;
	}
}
