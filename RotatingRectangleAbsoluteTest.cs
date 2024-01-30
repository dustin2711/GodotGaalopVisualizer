using System;

public static class RotatingRectangleAbsoluteTest
{
	public static (float p5_1, float p5_e01, float p5_e12, float p5_e02, float p6_e01, float p6_e12, float p6_e02, float p6_1, float p7_1, float p7_e01, float p7_e12, float p7_e02, float p8_1, float p8_e01, float p8_e12, float p8_e02) Execute(float TIME)
	{
		float M_1 = MathF.Cos(TIME / 2.0f);
		float M_e12 = MathF.Sin(TIME / 2.0f);
		float p5_1 = (-M_e12) * M_1 + (-(M_1 * (-M_e12)));
		float p5_e01 = (M_1 + (-M_e12)) * M_1 + (-(((-M_1) + (-M_e12)) * (-M_e12)));
		float p5_e02 = (M_1 + (-M_e12)) * (-M_e12) + ((-M_1) + (-M_e12)) * M_1;
		float p5_e12 = (-M_e12) * (-M_e12) + M_1 * M_1;
		float p6_1 = (-M_e12) * M_1 + (-(M_1 * (-M_e12)));
		float p6_e01 = ((-M_1) + (-M_e12)) * M_1 + (-(((-M_1) + M_e12) * (-M_e12)));
		float p6_e02 = ((-M_1) + (-M_e12)) * (-M_e12) + ((-M_1) + M_e12) * M_1;
		float p6_e12 = (-M_e12) * (-M_e12) + M_1 * M_1;
		float p7_1 = (-M_e12) * M_1 + (-(M_1 * (-M_e12)));
		float p7_e01 = ((-M_1) + M_e12) * M_1 + (-((M_1 + M_e12) * (-M_e12)));
		float p7_e02 = ((-M_1) + M_e12) * (-M_e12) + (M_1 + M_e12) * M_1;
		float p7_e12 = (-M_e12) * (-M_e12) + M_1 * M_1;

		// p is p8 but not normalized
		float p_1 = (-M_e12) * M_1 + (-(M_1 * (-M_e12)));
		float p_e01 = (M_1 + M_e12) * M_1 + (-((M_1 + (-M_e12)) * (-M_e12)));
		float p_e02 = (M_1 + M_e12) * (-M_e12) + (M_1 + (-M_e12)) * M_1;
		float p_e12 = (-M_e12) * (-M_e12) + M_1 * M_1;

		// ORIGIN
		// float p8_1 = p_1 * MathF.Sqrt(MathF.Abs(p_1 * p_1 + (-(p_e12 * (-p_e12))))) / MathF.Sqrt(MathF.Abs((p_1 * p_1 + (-(p_e12 * (-p_e12)))) * (p_1 * p_1 + (-(p_e12 * (-p_e12))))));
		// float p8_e01 = p_e01 * MathF.Sqrt(MathF.Abs(p_1 * p_1 + (-(p_e12 * (-p_e12))))) / MathF.Sqrt(MathF.Abs((p_1 * p_1 + (-(p_e12 * (-p_e12)))) * (p_1 * p_1 + (-(p_e12 * (-p_e12))))));
		// float p8_e02 = p_e02 * MathF.Sqrt(MathF.Abs(p_1 * p_1 + (-(p_e12 * (-p_e12))))) / MathF.Sqrt(MathF.Abs((p_1 * p_1 + (-(p_e12 * (-p_e12)))) * (p_1 * p_1 + (-(p_e12 * (-p_e12))))));
		// float p8_e12 = p_e12 * MathF.Sqrt(MathF.Abs(p_1 * p_1 + (-(p_e12 * (-p_e12))))) / MathF.Sqrt(MathF.Abs((p_1 * p_1 + (-(p_e12 * (-p_e12)))) * (p_1 * p_1 + (-(p_e12 * (-p_e12))))));

		// SIMPLIFIED
		// Original
		float absolute = MathF.Sqrt(MathF.Abs(p_1 * p_1 + (-(p_e12 * (-p_e12))))) / MathF.Sqrt(MathF.Abs((p_1 * p_1 + (-(p_e12 * (-p_e12)))) * (p_1 * p_1 + (-(p_e12 * (-p_e12))))));
		// Use variable "squared"
		// float temp = p_1 * p_1 + (-(p_e12 * (-p_e12)));
		float temp = p_1 * p_1 + p_e12 * p_e12;
		float absolute2 = MathF.Sqrt(MathF.Abs(temp)) / MathF.Sqrt(MathF.Abs((temp) * (temp)));
		// Remove Abs() as squared is always positive and set sqrt(squared * squared) = squared
		float absolute3 = MathF.Sqrt(temp) / temp;
		float absolute4 = 1 / MathF.Sqrt(temp);
		// Calculate components
		float p8_1 = p_1 * absolute4;
		float p8_e01 = p_e01 * absolute4;
		float p8_e02 = p_e02 * absolute4;
		float p8_e12 = p_e12 * absolute4;

		return (p5_1, p5_e01, p5_e12, p5_e02, p6_e01, p6_e12, p6_e02, p6_1, p7_1, p7_e01, p7_e12, p7_e02, p8_1, p8_e01, p8_e12, p8_e02);
	}
}
