using System;

public static class RotatingRectangleArrays
{
	public static void Execute(float TIME, float[] p5, float[] p6, float[] p7, float[] p8)
	{
		float[] M = new float[8];
		float[] sinus = new float[8];
		sinus[0] = MathF.Sin(TIME / 2.0f);
		M[0] = MathF.Cos(TIME / 2.0f);
		p5[0] = (-sinus[0]) * M[0] + (-(M[0] * (-sinus[0])));
		p5[4] = (M[0] + (-sinus[0])) * M[0] + (-(((-M[0]) + (-sinus[0])) * (-sinus[0])));
		p5[5] = (M[0] + (-sinus[0])) * (-sinus[0]) + ((-M[0]) + (-sinus[0])) * M[0];
		p5[6] = (-sinus[0]) * (-sinus[0]) + M[0] * M[0];
		p6[0] = (-sinus[0]) * M[0] + (-(M[0] * (-sinus[0])));
		p6[4] = ((-M[0]) + (-sinus[0])) * M[0] + (-(((-M[0]) + sinus[0]) * (-sinus[0])));
		p6[5] = ((-M[0]) + (-sinus[0])) * (-sinus[0]) + ((-M[0]) + sinus[0]) * M[0];
		p6[6] = (-sinus[0]) * (-sinus[0]) + M[0] * M[0];
		p7[0] = (-sinus[0]) * M[0] + (-(M[0] * (-sinus[0])));
		p7[5] = ((-M[0]) + sinus[0]) * (-sinus[0]) + (M[0] + sinus[0]) * M[0];
		p7[6] = (-sinus[0]) * (-sinus[0]) + M[0] * M[0];
		p8[0] = (-sinus[0]) * M[0] + (-(M[0] * (-sinus[0])));
		p8[5] = (M[0] + sinus[0]) * (-sinus[0]) + (M[0] + (-sinus[0])) * M[0];
		p8[6] = (-sinus[0]) * (-sinus[0]) + M[0] * M[0];

		p7[4] = ((-M[0]) + sinus[0]) * M[0] + (-((M[0] + sinus[0]) * (-sinus[0])));
		p8[4] = (M[0] + sinus[0]) * M[0] + (-((M[0] + (-sinus[0])) * (-sinus[0])));
	}
}
