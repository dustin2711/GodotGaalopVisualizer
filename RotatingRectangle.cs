using System;

public static class RotatingRectangle
{
	public static float Execute(float TIME)
	{
		float temp_gcse_1 = TIME / 2.0f;
		float sinus_1 = MathF.Sin(temp_gcse_1);
		float M_1 = MathF.Cos(temp_gcse_1);
		float temp_gcse_2 = (-sinus_1);
		float p5_e12 = temp_gcse_2 * temp_gcse_2 + M_1 * M_1;
		
		return p5_e12;
	}
}
