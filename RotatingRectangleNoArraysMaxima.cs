using System;

public static class RotatingRectangleNoArraysMaxima
{
	public static (float p5_e01, float p5_e12, float p5_e02, float p6_e01, float p6_e12, float p6_e02, float p7_e01, float p7_e12, float p7_e02, float p8_e02, float p8_e01, float p8_e12) Execute(float TIME)
	{
		float p5_e01 = (-(MathF.Sin(TIME / 2.0f) * MathF.Sin(TIME / 2.0f) - 2.0f * MathF.Cos(TIME / 2.0f) * MathF.Sin(TIME / 2.0f) + MathF.Cos(TIME / 2.0f) * MathF.Cos(TIME / 2.0f)));
		float p5_e02 = MathF.Sin(TIME / 2.0f) * MathF.Sin(TIME / 2.0f) - 2.0f * MathF.Cos(TIME / 2.0f) * MathF.Sin(TIME / 2.0f) - MathF.Cos(TIME / 2.0f) * MathF.Cos(TIME / 2.0f);
		float p5_e12 = MathF.Sin(TIME / 2.0f) * MathF.Sin(TIME / 2.0f) + MathF.Cos(TIME / 2.0f) * MathF.Cos(TIME / 2.0f);
		float p6_e01 = MathF.Sin(TIME / 2.0f) * MathF.Sin(TIME / 2.0f) - 2.0f * MathF.Cos(TIME / 2.0f) * MathF.Sin(TIME / 2.0f) - MathF.Cos(TIME / 2.0f) * MathF.Cos(TIME / 2.0f);
		float p6_e02 = MathF.Sin(TIME / 2.0f) * MathF.Sin(TIME / 2.0f) + 2.0f * MathF.Cos(TIME / 2.0f) * MathF.Sin(TIME / 2.0f) - MathF.Cos(TIME / 2.0f) * MathF.Cos(TIME / 2.0f);
		float p6_e12 = MathF.Sin(TIME / 2.0f) * MathF.Sin(TIME / 2.0f) + MathF.Cos(TIME / 2.0f) * MathF.Cos(TIME / 2.0f);
		float p7_e01 = MathF.Sin(TIME / 2.0f) * MathF.Sin(TIME / 2.0f) + 2.0f * MathF.Cos(TIME / 2.0f) * MathF.Sin(TIME / 2.0f) - MathF.Cos(TIME / 2.0f) * MathF.Cos(TIME / 2.0f);
		float p7_e02 = (-(MathF.Sin(TIME / 2.0f) * MathF.Sin(TIME / 2.0f) + 2.0f * MathF.Cos(TIME / 2.0f) * MathF.Sin(TIME / 2.0f) + MathF.Cos(TIME / 2.0f) * MathF.Cos(TIME / 2.0f)));
		float p7_e12 = MathF.Sin(TIME / 2.0f) * MathF.Sin(TIME / 2.0f) + MathF.Cos(TIME / 2.0f) * MathF.Cos(TIME / 2.0f);
		float p8_e01 = (-(MathF.Sin(TIME / 2.0f) * MathF.Sin(TIME / 2.0f) + 2.0f * MathF.Cos(TIME / 2.0f) * MathF.Sin(TIME / 2.0f) + MathF.Cos(TIME / 2.0f) * MathF.Cos(TIME / 2.0f)));
		float p8_e02 = (-(MathF.Sin(TIME / 2.0f) * MathF.Sin(TIME / 2.0f) - 2.0f * MathF.Cos(TIME / 2.0f) * MathF.Sin(TIME / 2.0f) + MathF.Cos(TIME / 2.0f) * MathF.Cos(TIME / 2.0f)));
		float p8_e12 = MathF.Sin(TIME / 2.0f) * MathF.Sin(TIME / 2.0f) + MathF.Cos(TIME / 2.0f) * MathF.Cos(TIME / 2.0f);

		return (p5_e01, p5_e12, p5_e02, p6_e01, p6_e12, p6_e02, p7_e01, p7_e12, p7_e02, p8_e02, p8_e01, p8_e12);
	}
}
