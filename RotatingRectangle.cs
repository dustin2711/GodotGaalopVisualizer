using System;

public static class RotatingRectangle
{
	public static (Godot.Vector2, Godot.Vector2, Godot.Vector2, Godot.Vector2) Execute(float TIME)
	{
		float sinus_1 = MathF.Sin(TIME / 2.0f);
		float M_1 = MathF.Cos(TIME / 2.0f);
		float p5_1 = (-sinus_1) * M_1 + (-(M_1 * (-sinus_1)));
		float p5_e01 = (M_1 + (-sinus_1)) * M_1 + (-(((-M_1) + (-sinus_1)) * (-sinus_1)));
		float p5_e02 = (M_1 + (-sinus_1)) * (-sinus_1) + ((-M_1) + (-sinus_1)) * M_1;
		float p5_e12 = (-sinus_1) * (-sinus_1) + M_1 * M_1;
		float p6_1 = (-sinus_1) * M_1 + (-(M_1 * (-sinus_1)));
		float p6_e01 = ((-M_1) + (-sinus_1)) * M_1 + (-(((-M_1) + sinus_1) * (-sinus_1)));
		float p6_e02 = ((-M_1) + (-sinus_1)) * (-sinus_1) + ((-M_1) + sinus_1) * M_1;
		float p6_e12 = (-sinus_1) * (-sinus_1) + M_1 * M_1;
		float p7_1 = (-sinus_1) * M_1 + (-(M_1 * (-sinus_1)));
		float p7_e01 = ((-M_1) + sinus_1) * M_1 + (-((M_1 + sinus_1) * (-sinus_1)));
		float p7_e02 = ((-M_1) + sinus_1) * (-sinus_1) + (M_1 + sinus_1) * M_1;
		float p7_e12 = (-sinus_1) * (-sinus_1) + M_1 * M_1;
		float p8_1 = (-sinus_1) * M_1 + (-(M_1 * (-sinus_1)));
		float p8_e01 = (M_1 + sinus_1) * M_1 + (-((M_1 + (-sinus_1)) * (-sinus_1)));
		float p8_e02 = (M_1 + sinus_1) * (-sinus_1) + (M_1 + (-sinus_1)) * M_1;
		float p8_e12 = (-sinus_1) * (-sinus_1) + M_1 * M_1;
		
		// Normalizing outputs:
		
		float p5_magnitude = MathF.Sqrt(p5_1 * p5_1 + p5_e01 * p5_e01 + p5_e12 * p5_e12 + p5_e02 * p5_e02);
		p5_1 = p5_1 / p5_magnitude;
		p5_e01 = p5_e01 / p5_magnitude;
		p5_e12 = p5_e12 / p5_magnitude;
		p5_e02 = p5_e02 / p5_magnitude;
		
		float p6_magnitude = MathF.Sqrt(p6_e01 * p6_e01 + p6_e12 * p6_e12 + p6_e02 * p6_e02 + p6_1 * p6_1);
		p6_e01 = p6_e01 / p6_magnitude;
		p6_e12 = p6_e12 / p6_magnitude;
		p6_e02 = p6_e02 / p6_magnitude;
		p6_1 = p6_1 / p6_magnitude;
		
		float p7_magnitude = MathF.Sqrt(p7_1 * p7_1 + p7_e01 * p7_e01 + p7_e12 * p7_e12 + p7_e02 * p7_e02);
		p7_1 = p7_1 / p7_magnitude;
		p7_e01 = p7_e01 / p7_magnitude;
		p7_e12 = p7_e12 / p7_magnitude;
		p7_e02 = p7_e02 / p7_magnitude;
		
		float p8_magnitude = MathF.Sqrt(p8_1 * p8_1 + p8_e01 * p8_e01 + p8_e12 * p8_e12 + p8_e02 * p8_e02);
		p8_1 = p8_1 / p8_magnitude;
		p8_e01 = p8_e01 / p8_magnitude;
		p8_e12 = p8_e12 / p8_magnitude;
		p8_e02 = p8_e02 / p8_magnitude;
		
		return (new Godot.Vector2(p5_e01, p5_e02), new Godot.Vector2(p6_e01, p6_e02), new Godot.Vector2(p7_e01, p7_e02), new Godot.Vector2(p8_e01, p8_e02));
	}
}
