using System;

public static class ThreeSpheresArrays
{
	public static void Execute(float a1, float a2, float a3, float b1, float b2, float b3, float c1, float c2, float c3, float d14, float d24, float d34, float[] DualPP4, float[] PP4, float[] S1, float[] S2, float[] S3, float[] x1, float[] x4a, float[] x4b)
	{
		float[] x2 = new float[32];
		float[] x3 = new float[32];
		x1[1] = a1;
		x1[2] = a2;
		x1[3] = a3;
		x1[4] = (a1 * a1 + a2 * a2 + a3 * a3) / 2.0f;
		x1[5] = 1.0f;
		x2[4] = (b1 * b1 + b2 * b2 + b3 * b3) / 2.0f;
		x3[4] = (c1 * c1 + c2 * c2 + c3 * c3) / 2.0f;
		S1[1] = x1[1];
		S1[2] = x1[2];
		S1[3] = x1[3];
		S1[4] = x1[4] - (d14 * d14) / 2.0f;
		S1[5] = 1.0f;
		S2[1] = b1;
		S2[2] = b2;
		S2[3] = b3;
		S2[4] = x2[4] - (d24 * d24) / 2.0f;
		S2[5] = 1.0f;
		S3[1] = c1;
		S3[2] = c2;
		S3[3] = c3;
		S3[4] = x3[4] - (d34 * d34) / 2.0f;
		S3[5] = 1.0f;
		PP4[16] = (S1[1] * S2[2] + (-(S1[2] * S2[1]))) * S3[3] + (-((S1[1] * S2[3] + (-(S1[3] * S2[1]))) * S3[2])) + (S1[2] * S2[3] + (-(S1[3] * S2[2]))) * S3[1];
		PP4[17] = (S1[1] * S2[2] + (-(S1[2] * S2[1]))) * S3[4] + (-((S1[1] * S2[4] + (-(S1[4] * S2[1]))) * S3[2])) + (S1[2] * S2[4] + (-(S1[4] * S2[2]))) * S3[1];
		PP4[18] = S1[1] * S2[2] + (-(S1[2] * S2[1])) + (-((S1[1] + (-S2[1])) * S3[2])) + (S1[2] + (-S2[2])) * S3[1];
		PP4[19] = (S1[1] * S2[3] + (-(S1[3] * S2[1]))) * S3[4] + (-((S1[1] * S2[4] + (-(S1[4] * S2[1]))) * S3[3])) + (S1[3] * S2[4] + (-(S1[4] * S2[3]))) * S3[1];
		PP4[20] = S1[1] * S2[3] + (-(S1[3] * S2[1])) + (-((S1[1] + (-S2[1])) * S3[3])) + (S1[3] + (-S2[3])) * S3[1];
		PP4[21] = S1[1] * S2[4] + (-(S1[4] * S2[1])) + (-((S1[1] + (-S2[1])) * S3[4])) + (S1[4] + (-S2[4])) * S3[1];
		PP4[22] = (S1[2] * S2[3] + (-(S1[3] * S2[2]))) * S3[4] + (-((S1[2] * S2[4] + (-(S1[4] * S2[2]))) * S3[3])) + (S1[3] * S2[4] + (-(S1[4] * S2[3]))) * S3[2];
		PP4[23] = S1[2] * S2[3] + (-(S1[3] * S2[2])) + (-((S1[2] + (-S2[2])) * S3[3])) + (S1[3] + (-S2[3])) * S3[2];
		PP4[24] = S1[2] * S2[4] + (-(S1[4] * S2[2])) + (-((S1[2] + (-S2[2])) * S3[4])) + (S1[4] + (-S2[4])) * S3[2];
		PP4[25] = S1[3] * S2[4] + (-(S1[4] * S2[3])) + (-((S1[3] + (-S2[3])) * S3[4])) + (S1[4] + (-S2[4])) * S3[3];
		DualPP4[6] = (-PP4[25]);
		DualPP4[7] = PP4[24];
		DualPP4[8] = (-PP4[22]);
		DualPP4[9] = PP4[23];
		DualPP4[10] = (-PP4[21]);
		DualPP4[11] = PP4[19];
		DualPP4[12] = (-PP4[20]);
		DualPP4[13] = (-PP4[17]);
		DualPP4[14] = PP4[18];
		DualPP4[15] = PP4[16];
		x4a[1] = MathF.Sqrt((-(DualPP4[6] * DualPP4[6])) + (-(DualPP4[7] * DualPP4[7])) + DualPP4[8] * DualPP4[9] + DualPP4[9] * DualPP4[8] + (-(DualPP4[10] * DualPP4[10])) + DualPP4[11] * DualPP4[12] + DualPP4[12] * DualPP4[11] + DualPP4[13] * DualPP4[14] + DualPP4[14] * DualPP4[13] + DualPP4[15] * DualPP4[15]) * DualPP4[9] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]) + (-DualPP4[6]) * DualPP4[12] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]) + (-DualPP4[7]) * DualPP4[14] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]) + (-((-DualPP4[9]) * DualPP4[15] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14])));
		x4a[2] = MathF.Sqrt((-(DualPP4[6] * DualPP4[6])) + (-(DualPP4[7] * DualPP4[7])) + DualPP4[8] * DualPP4[9] + DualPP4[9] * DualPP4[8] + (-(DualPP4[10] * DualPP4[10])) + DualPP4[11] * DualPP4[12] + DualPP4[12] * DualPP4[11] + DualPP4[13] * DualPP4[14] + DualPP4[14] * DualPP4[13] + DualPP4[15] * DualPP4[15]) * DualPP4[12] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]) + (-((-DualPP4[6]) * DualPP4[9] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-DualPP4[10]) * DualPP4[14] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]) + (-((-DualPP4[12]) * DualPP4[15] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14])));
		x4a[3] = MathF.Sqrt((-(DualPP4[6] * DualPP4[6])) + (-(DualPP4[7] * DualPP4[7])) + DualPP4[8] * DualPP4[9] + DualPP4[9] * DualPP4[8] + (-(DualPP4[10] * DualPP4[10])) + DualPP4[11] * DualPP4[12] + DualPP4[12] * DualPP4[11] + DualPP4[13] * DualPP4[14] + DualPP4[14] * DualPP4[13] + DualPP4[15] * DualPP4[15]) * DualPP4[14] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]) + (-((-DualPP4[7]) * DualPP4[9] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-((-DualPP4[10]) * DualPP4[12] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-((-DualPP4[14]) * DualPP4[15] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14])));
		x4a[4] = MathF.Sqrt((-(DualPP4[6] * DualPP4[6])) + (-(DualPP4[7] * DualPP4[7])) + DualPP4[8] * DualPP4[9] + DualPP4[9] * DualPP4[8] + (-(DualPP4[10] * DualPP4[10])) + DualPP4[11] * DualPP4[12] + DualPP4[12] * DualPP4[11] + DualPP4[13] * DualPP4[14] + DualPP4[14] * DualPP4[13] + DualPP4[15] * DualPP4[15]) * DualPP4[15] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]) + (-((-DualPP4[8]) * DualPP4[9] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-((-DualPP4[11]) * DualPP4[12] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-((-DualPP4[13]) * DualPP4[14] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-((-DualPP4[15]) * DualPP4[15] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14])));
		x4a[5] = (-((-DualPP4[9]) * DualPP4[9] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-((-DualPP4[12]) * DualPP4[12] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-((-DualPP4[14]) * DualPP4[14] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14])));
		x4a[16] = (-DualPP4[6]) * DualPP4[14] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]) + (-((-DualPP4[7]) * DualPP4[12] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-DualPP4[10]) * DualPP4[9] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]);
		x4a[17] = (-DualPP4[6]) * DualPP4[15] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]) + (-((-DualPP4[8]) * DualPP4[12] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-DualPP4[11]) * DualPP4[9] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]);
		x4a[18] = (-((-DualPP4[9]) * DualPP4[12] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-DualPP4[12]) * DualPP4[9] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]);
		x4a[19] = (-DualPP4[7]) * DualPP4[15] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]) + (-((-DualPP4[8]) * DualPP4[14] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-DualPP4[13]) * DualPP4[9] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]);
		x4a[20] = (-((-DualPP4[9]) * DualPP4[14] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-DualPP4[14]) * DualPP4[9] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]);
		x4a[21] = (-((-DualPP4[9]) * DualPP4[15] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-DualPP4[15]) * DualPP4[9] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]);
		x4a[22] = (-DualPP4[10]) * DualPP4[15] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]) + (-((-DualPP4[11]) * DualPP4[14] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-DualPP4[13]) * DualPP4[12] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]);
		x4a[23] = (-((-DualPP4[12]) * DualPP4[14] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-DualPP4[14]) * DualPP4[12] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]);
		x4a[24] = (-((-DualPP4[12]) * DualPP4[15] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-DualPP4[15]) * DualPP4[12] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]);
		x4a[25] = (-((-DualPP4[14]) * DualPP4[15] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-DualPP4[15]) * DualPP4[14] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]);
		x4b[1] = (-MathF.Sqrt((-(DualPP4[6] * DualPP4[6])) + (-(DualPP4[7] * DualPP4[7])) + DualPP4[8] * DualPP4[9] + DualPP4[9] * DualPP4[8] + (-(DualPP4[10] * DualPP4[10])) + DualPP4[11] * DualPP4[12] + DualPP4[12] * DualPP4[11] + DualPP4[13] * DualPP4[14] + DualPP4[14] * DualPP4[13] + DualPP4[15] * DualPP4[15])) * DualPP4[9] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]) + (-DualPP4[6]) * DualPP4[12] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]) + (-DualPP4[7]) * DualPP4[14] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]) + (-((-DualPP4[9]) * DualPP4[15] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14])));
		x4b[2] = (-MathF.Sqrt((-(DualPP4[6] * DualPP4[6])) + (-(DualPP4[7] * DualPP4[7])) + DualPP4[8] * DualPP4[9] + DualPP4[9] * DualPP4[8] + (-(DualPP4[10] * DualPP4[10])) + DualPP4[11] * DualPP4[12] + DualPP4[12] * DualPP4[11] + DualPP4[13] * DualPP4[14] + DualPP4[14] * DualPP4[13] + DualPP4[15] * DualPP4[15])) * DualPP4[12] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]) + (-((-DualPP4[6]) * DualPP4[9] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-DualPP4[10]) * DualPP4[14] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]) + (-((-DualPP4[12]) * DualPP4[15] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14])));
		x4b[3] = (-MathF.Sqrt((-(DualPP4[6] * DualPP4[6])) + (-(DualPP4[7] * DualPP4[7])) + DualPP4[8] * DualPP4[9] + DualPP4[9] * DualPP4[8] + (-(DualPP4[10] * DualPP4[10])) + DualPP4[11] * DualPP4[12] + DualPP4[12] * DualPP4[11] + DualPP4[13] * DualPP4[14] + DualPP4[14] * DualPP4[13] + DualPP4[15] * DualPP4[15])) * DualPP4[14] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]) + (-((-DualPP4[7]) * DualPP4[9] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-((-DualPP4[10]) * DualPP4[12] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-((-DualPP4[14]) * DualPP4[15] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14])));
		x4b[4] = (-MathF.Sqrt((-(DualPP4[6] * DualPP4[6])) + (-(DualPP4[7] * DualPP4[7])) + DualPP4[8] * DualPP4[9] + DualPP4[9] * DualPP4[8] + (-(DualPP4[10] * DualPP4[10])) + DualPP4[11] * DualPP4[12] + DualPP4[12] * DualPP4[11] + DualPP4[13] * DualPP4[14] + DualPP4[14] * DualPP4[13] + DualPP4[15] * DualPP4[15])) * DualPP4[15] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]) + (-((-DualPP4[8]) * DualPP4[9] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-((-DualPP4[11]) * DualPP4[12] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-((-DualPP4[13]) * DualPP4[14] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-((-DualPP4[15]) * DualPP4[15] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14])));
		x4b[5] = (-((-DualPP4[9]) * DualPP4[9] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-((-DualPP4[12]) * DualPP4[12] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-((-DualPP4[14]) * DualPP4[14] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14])));
		x4b[16] = (-DualPP4[6]) * DualPP4[14] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]) + (-((-DualPP4[7]) * DualPP4[12] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-DualPP4[10]) * DualPP4[9] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]);
		x4b[17] = (-DualPP4[6]) * DualPP4[15] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]) + (-((-DualPP4[8]) * DualPP4[12] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-DualPP4[11]) * DualPP4[9] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]);
		x4b[18] = (-((-DualPP4[9]) * DualPP4[12] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-DualPP4[12]) * DualPP4[9] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]);
		x4b[19] = (-DualPP4[7]) * DualPP4[15] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]) + (-((-DualPP4[8]) * DualPP4[14] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-DualPP4[13]) * DualPP4[9] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]);
		x4b[20] = (-((-DualPP4[9]) * DualPP4[14] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-DualPP4[14]) * DualPP4[9] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]);
		x4b[21] = (-((-DualPP4[9]) * DualPP4[15] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-DualPP4[15]) * DualPP4[9] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]);
		x4b[22] = (-DualPP4[10]) * DualPP4[15] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]) + (-((-DualPP4[11]) * DualPP4[14] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-DualPP4[13]) * DualPP4[12] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]);
		x4b[23] = (-((-DualPP4[12]) * DualPP4[14] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-DualPP4[14]) * DualPP4[12] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]);
		x4b[24] = (-((-DualPP4[12]) * DualPP4[15] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-DualPP4[15]) * DualPP4[12] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]);
		x4b[25] = (-((-DualPP4[14]) * DualPP4[15] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]))) + (-DualPP4[15]) * DualPP4[14] / (DualPP4[9] * DualPP4[9] + DualPP4[12] * DualPP4[12] + DualPP4[14] * DualPP4[14]);
	}
}
