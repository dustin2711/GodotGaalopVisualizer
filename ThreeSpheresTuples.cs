using System;

public static class ThreeSpheres
{
	public static (float DualPP4_e20, float DualPP4_e23, float DualPP4_e2inf, float DualPP4_e13, float DualPP4_e10, float DualPP4_e12, float DualPP4_e3inf, float DualPP4_e1inf, float DualPP4_e30, float DualPP4_einf0, float PP4_e130, float PP4_e13inf, float PP4_e1inf0, float PP4_e2inf0, float PP4_e23inf, float PP4_e3inf0, float PP4_e120, float PP4_e123, float PP4_e230, float PP4_e12inf, float S1_einf, float S1_e1, float S1_e0, float S1_e3, float S1_e2, float S2_einf, float S2_e0, float S2_e2, float S2_e1, float S2_e3, float S3_e0, float S3_e1, float S3_e2, float S3_e3, float S3_einf, float x1_e1, float x1_e2, float x1_e0, float x1_e3, float x1_einf, float x4a_e3, float x4a_e2, float x4a_e1, float x4a_e0, float x4a_e12inf, float x4a_e230, float x4a_e13inf, float x4a_e120, float x4a_e123, float x4a_e2inf0, float x4a_e3inf0, float x4a_e23inf, float x4a_e130, float x4a_e1inf0, float x4a_einf, float x4b_e12inf, float x4b_e1inf0, float x4b_einf, float x4b_e130, float x4b_e3inf0, float x4b_e123, float x4b_e120, float x4b_e2inf0, float x4b_e23inf, float x4b_e13inf, float x4b_e0, float x4b_e1, float x4b_e2, float x4b_e230, float x4b_e3) Execute(float a1, float a2, float a3, float b1, float b2, float b3, float c1, float c2, float c3, float d14, float d24, float d34)
	{
		float x1_e1 = a1;
		float x1_e2 = a2;
		float x1_e3 = a3;
		float x1_einf = (a1 * a1 + a2 * a2 + a3 * a3) / 2.0f;
		float x1_e0 = 1.0f;
		float x2_einf = (b1 * b1 + b2 * b2 + b3 * b3) / 2.0f;
		float x3_einf = (c1 * c1 + c2 * c2 + c3 * c3) / 2.0f;
		float S1_e1 = x1_e1;
		float S1_e2 = x1_e2;
		float S1_e3 = x1_e3;
		float S1_einf = x1_einf - (d14 * d14) / 2.0f;
		float S1_e0 = 1.0f;
		float S2_e1 = b1;
		float S2_e2 = b2;
		float S2_e3 = b3;
		float S2_einf = x2_einf - (d24 * d24) / 2.0f;
		float S2_e0 = 1.0f;
		float S3_e1 = c1;
		float S3_e2 = c2;
		float S3_e3 = c3;
		float S3_einf = x3_einf - (d34 * d34) / 2.0f;
		float S3_e0 = 1.0f;
		float PP4_e123 = (S1_e1 * S2_e2 + (-(S1_e2 * S2_e1))) * S3_e3 + (-((S1_e1 * S2_e3 + (-(S1_e3 * S2_e1))) * S3_e2)) + (S1_e2 * S2_e3 + (-(S1_e3 * S2_e2))) * S3_e1;
		float PP4_e12inf = (S1_e1 * S2_e2 + (-(S1_e2 * S2_e1))) * S3_einf + (-((S1_e1 * S2_einf + (-(S1_einf * S2_e1))) * S3_e2)) + (S1_e2 * S2_einf + (-(S1_einf * S2_e2))) * S3_e1;
		float PP4_e120 = S1_e1 * S2_e2 + (-(S1_e2 * S2_e1)) + (-((S1_e1 + (-S2_e1)) * S3_e2)) + (S1_e2 + (-S2_e2)) * S3_e1;
		float PP4_e13inf = (S1_e1 * S2_e3 + (-(S1_e3 * S2_e1))) * S3_einf + (-((S1_e1 * S2_einf + (-(S1_einf * S2_e1))) * S3_e3)) + (S1_e3 * S2_einf + (-(S1_einf * S2_e3))) * S3_e1;
		float PP4_e130 = S1_e1 * S2_e3 + (-(S1_e3 * S2_e1)) + (-((S1_e1 + (-S2_e1)) * S3_e3)) + (S1_e3 + (-S2_e3)) * S3_e1;
		float PP4_e1inf0 = S1_e1 * S2_einf + (-(S1_einf * S2_e1)) + (-((S1_e1 + (-S2_e1)) * S3_einf)) + (S1_einf + (-S2_einf)) * S3_e1;
		float PP4_e23inf = (S1_e2 * S2_e3 + (-(S1_e3 * S2_e2))) * S3_einf + (-((S1_e2 * S2_einf + (-(S1_einf * S2_e2))) * S3_e3)) + (S1_e3 * S2_einf + (-(S1_einf * S2_e3))) * S3_e2;
		float PP4_e230 = S1_e2 * S2_e3 + (-(S1_e3 * S2_e2)) + (-((S1_e2 + (-S2_e2)) * S3_e3)) + (S1_e3 + (-S2_e3)) * S3_e2;
		float PP4_e2inf0 = S1_e2 * S2_einf + (-(S1_einf * S2_e2)) + (-((S1_e2 + (-S2_e2)) * S3_einf)) + (S1_einf + (-S2_einf)) * S3_e2;
		float PP4_e3inf0 = S1_e3 * S2_einf + (-(S1_einf * S2_e3)) + (-((S1_e3 + (-S2_e3)) * S3_einf)) + (S1_einf + (-S2_einf)) * S3_e3;
		float DualPP4_e12 = (-PP4_e3inf0);
		float DualPP4_e13 = PP4_e2inf0;
		float DualPP4_e1inf = (-PP4_e23inf);
		float DualPP4_e10 = PP4_e230;
		float DualPP4_e23 = (-PP4_e1inf0);
		float DualPP4_e2inf = PP4_e13inf;
		float DualPP4_e20 = (-PP4_e130);
		float DualPP4_e3inf = (-PP4_e12inf);
		float DualPP4_e30 = PP4_e120;
		float DualPP4_einf0 = PP4_e123;
		float x4a_e1 = MathF.Sqrt((-(DualPP4_e12 * DualPP4_e12)) + (-(DualPP4_e13 * DualPP4_e13)) + DualPP4_e1inf * DualPP4_e10 + DualPP4_e10 * DualPP4_e1inf + (-(DualPP4_e23 * DualPP4_e23)) + DualPP4_e2inf * DualPP4_e20 + DualPP4_e20 * DualPP4_e2inf + DualPP4_e3inf * DualPP4_e30 + DualPP4_e30 * DualPP4_e3inf + DualPP4_einf0 * DualPP4_einf0) * DualPP4_e10 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30) + (-DualPP4_e12) * DualPP4_e20 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30) + (-DualPP4_e13) * DualPP4_e30 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30) + (-((-DualPP4_e10) * DualPP4_einf0 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30)));
		float x4a_e2 = MathF.Sqrt((-(DualPP4_e12 * DualPP4_e12)) + (-(DualPP4_e13 * DualPP4_e13)) + DualPP4_e1inf * DualPP4_e10 + DualPP4_e10 * DualPP4_e1inf + (-(DualPP4_e23 * DualPP4_e23)) + DualPP4_e2inf * DualPP4_e20 + DualPP4_e20 * DualPP4_e2inf + DualPP4_e3inf * DualPP4_e30 + DualPP4_e30 * DualPP4_e3inf + DualPP4_einf0 * DualPP4_einf0) * DualPP4_e20 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30) + (-((-DualPP4_e12) * DualPP4_e10 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-DualPP4_e23) * DualPP4_e30 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30) + (-((-DualPP4_e20) * DualPP4_einf0 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30)));
		float x4a_e3 = MathF.Sqrt((-(DualPP4_e12 * DualPP4_e12)) + (-(DualPP4_e13 * DualPP4_e13)) + DualPP4_e1inf * DualPP4_e10 + DualPP4_e10 * DualPP4_e1inf + (-(DualPP4_e23 * DualPP4_e23)) + DualPP4_e2inf * DualPP4_e20 + DualPP4_e20 * DualPP4_e2inf + DualPP4_e3inf * DualPP4_e30 + DualPP4_e30 * DualPP4_e3inf + DualPP4_einf0 * DualPP4_einf0) * DualPP4_e30 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30) + (-((-DualPP4_e13) * DualPP4_e10 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-((-DualPP4_e23) * DualPP4_e20 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-((-DualPP4_e30) * DualPP4_einf0 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30)));
		float x4a_einf = MathF.Sqrt((-(DualPP4_e12 * DualPP4_e12)) + (-(DualPP4_e13 * DualPP4_e13)) + DualPP4_e1inf * DualPP4_e10 + DualPP4_e10 * DualPP4_e1inf + (-(DualPP4_e23 * DualPP4_e23)) + DualPP4_e2inf * DualPP4_e20 + DualPP4_e20 * DualPP4_e2inf + DualPP4_e3inf * DualPP4_e30 + DualPP4_e30 * DualPP4_e3inf + DualPP4_einf0 * DualPP4_einf0) * DualPP4_einf0 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30) + (-((-DualPP4_e1inf) * DualPP4_e10 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-((-DualPP4_e2inf) * DualPP4_e20 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-((-DualPP4_e3inf) * DualPP4_e30 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-((-DualPP4_einf0) * DualPP4_einf0 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30)));
		float x4a_e0 = (-((-DualPP4_e10) * DualPP4_e10 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-((-DualPP4_e20) * DualPP4_e20 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-((-DualPP4_e30) * DualPP4_e30 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30)));
		float x4a_e123 = (-DualPP4_e12) * DualPP4_e30 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30) + (-((-DualPP4_e13) * DualPP4_e20 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-DualPP4_e23) * DualPP4_e10 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30);
		float x4a_e12inf = (-DualPP4_e12) * DualPP4_einf0 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30) + (-((-DualPP4_e1inf) * DualPP4_e20 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-DualPP4_e2inf) * DualPP4_e10 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30);
		float x4a_e120 = (-((-DualPP4_e10) * DualPP4_e20 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-DualPP4_e20) * DualPP4_e10 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30);
		float x4a_e13inf = (-DualPP4_e13) * DualPP4_einf0 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30) + (-((-DualPP4_e1inf) * DualPP4_e30 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-DualPP4_e3inf) * DualPP4_e10 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30);
		float x4a_e130 = (-((-DualPP4_e10) * DualPP4_e30 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-DualPP4_e30) * DualPP4_e10 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30);
		float x4a_e1inf0 = (-((-DualPP4_e10) * DualPP4_einf0 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-DualPP4_einf0) * DualPP4_e10 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30);
		float x4a_e23inf = (-DualPP4_e23) * DualPP4_einf0 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30) + (-((-DualPP4_e2inf) * DualPP4_e30 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-DualPP4_e3inf) * DualPP4_e20 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30);
		float x4a_e230 = (-((-DualPP4_e20) * DualPP4_e30 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-DualPP4_e30) * DualPP4_e20 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30);
		float x4a_e2inf0 = (-((-DualPP4_e20) * DualPP4_einf0 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-DualPP4_einf0) * DualPP4_e20 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30);
		float x4a_e3inf0 = (-((-DualPP4_e30) * DualPP4_einf0 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-DualPP4_einf0) * DualPP4_e30 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30);
		float x4b_e1 = (-MathF.Sqrt((-(DualPP4_e12 * DualPP4_e12)) + (-(DualPP4_e13 * DualPP4_e13)) + DualPP4_e1inf * DualPP4_e10 + DualPP4_e10 * DualPP4_e1inf + (-(DualPP4_e23 * DualPP4_e23)) + DualPP4_e2inf * DualPP4_e20 + DualPP4_e20 * DualPP4_e2inf + DualPP4_e3inf * DualPP4_e30 + DualPP4_e30 * DualPP4_e3inf + DualPP4_einf0 * DualPP4_einf0)) * DualPP4_e10 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30) + (-DualPP4_e12) * DualPP4_e20 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30) + (-DualPP4_e13) * DualPP4_e30 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30) + (-((-DualPP4_e10) * DualPP4_einf0 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30)));
		float x4b_e2 = (-MathF.Sqrt((-(DualPP4_e12 * DualPP4_e12)) + (-(DualPP4_e13 * DualPP4_e13)) + DualPP4_e1inf * DualPP4_e10 + DualPP4_e10 * DualPP4_e1inf + (-(DualPP4_e23 * DualPP4_e23)) + DualPP4_e2inf * DualPP4_e20 + DualPP4_e20 * DualPP4_e2inf + DualPP4_e3inf * DualPP4_e30 + DualPP4_e30 * DualPP4_e3inf + DualPP4_einf0 * DualPP4_einf0)) * DualPP4_e20 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30) + (-((-DualPP4_e12) * DualPP4_e10 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-DualPP4_e23) * DualPP4_e30 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30) + (-((-DualPP4_e20) * DualPP4_einf0 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30)));
		float x4b_e3 = (-MathF.Sqrt((-(DualPP4_e12 * DualPP4_e12)) + (-(DualPP4_e13 * DualPP4_e13)) + DualPP4_e1inf * DualPP4_e10 + DualPP4_e10 * DualPP4_e1inf + (-(DualPP4_e23 * DualPP4_e23)) + DualPP4_e2inf * DualPP4_e20 + DualPP4_e20 * DualPP4_e2inf + DualPP4_e3inf * DualPP4_e30 + DualPP4_e30 * DualPP4_e3inf + DualPP4_einf0 * DualPP4_einf0)) * DualPP4_e30 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30) + (-((-DualPP4_e13) * DualPP4_e10 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-((-DualPP4_e23) * DualPP4_e20 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-((-DualPP4_e30) * DualPP4_einf0 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30)));
		float x4b_einf = (-MathF.Sqrt((-(DualPP4_e12 * DualPP4_e12)) + (-(DualPP4_e13 * DualPP4_e13)) + DualPP4_e1inf * DualPP4_e10 + DualPP4_e10 * DualPP4_e1inf + (-(DualPP4_e23 * DualPP4_e23)) + DualPP4_e2inf * DualPP4_e20 + DualPP4_e20 * DualPP4_e2inf + DualPP4_e3inf * DualPP4_e30 + DualPP4_e30 * DualPP4_e3inf + DualPP4_einf0 * DualPP4_einf0)) * DualPP4_einf0 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30) + (-((-DualPP4_e1inf) * DualPP4_e10 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-((-DualPP4_e2inf) * DualPP4_e20 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-((-DualPP4_e3inf) * DualPP4_e30 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-((-DualPP4_einf0) * DualPP4_einf0 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30)));
		float x4b_e0 = (-((-DualPP4_e10) * DualPP4_e10 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-((-DualPP4_e20) * DualPP4_e20 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-((-DualPP4_e30) * DualPP4_e30 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30)));
		float x4b_e123 = (-DualPP4_e12) * DualPP4_e30 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30) + (-((-DualPP4_e13) * DualPP4_e20 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-DualPP4_e23) * DualPP4_e10 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30);
		float x4b_e12inf = (-DualPP4_e12) * DualPP4_einf0 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30) + (-((-DualPP4_e1inf) * DualPP4_e20 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-DualPP4_e2inf) * DualPP4_e10 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30);
		float x4b_e120 = (-((-DualPP4_e10) * DualPP4_e20 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-DualPP4_e20) * DualPP4_e10 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30);
		float x4b_e13inf = (-DualPP4_e13) * DualPP4_einf0 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30) + (-((-DualPP4_e1inf) * DualPP4_e30 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-DualPP4_e3inf) * DualPP4_e10 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30);
		float x4b_e130 = (-((-DualPP4_e10) * DualPP4_e30 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-DualPP4_e30) * DualPP4_e10 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30);
		float x4b_e1inf0 = (-((-DualPP4_e10) * DualPP4_einf0 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-DualPP4_einf0) * DualPP4_e10 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30);
		float x4b_e23inf = (-DualPP4_e23) * DualPP4_einf0 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30) + (-((-DualPP4_e2inf) * DualPP4_e30 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-DualPP4_e3inf) * DualPP4_e20 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30);
		float x4b_e230 = (-((-DualPP4_e20) * DualPP4_e30 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-DualPP4_e30) * DualPP4_e20 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30);
		float x4b_e2inf0 = (-((-DualPP4_e20) * DualPP4_einf0 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-DualPP4_einf0) * DualPP4_e20 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30);
		float x4b_e3inf0 = (-((-DualPP4_e30) * DualPP4_einf0 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30))) + (-DualPP4_einf0) * DualPP4_e30 / (DualPP4_e10 * DualPP4_e10 + DualPP4_e20 * DualPP4_e20 + DualPP4_e30 * DualPP4_e30);
		
		
		return (
			DualPP4_e20, DualPP4_e23, DualPP4_e2inf, DualPP4_e13, DualPP4_e10, DualPP4_e12, DualPP4_e3inf, DualPP4_e1inf, DualPP4_e30, DualPP4_einf0, 
			PP4_e130, PP4_e13inf, PP4_e1inf0, PP4_e2inf0, PP4_e23inf, PP4_e3inf0, PP4_e120, PP4_e123, PP4_e230, PP4_e12inf, 
			S1_einf, S1_e1, S1_e0, S1_e3, S1_e2, 
			S2_einf, S2_e0, S2_e2, S2_e1, S2_e3, 
			S3_e0, S3_e1, S3_e2, S3_e3, S3_einf, 
			x1_e1, x1_e2, x1_e0, x1_e3, x1_einf, 
			x4a_e3, x4a_e2, x4a_e1, x4a_e0, x4a_e12inf, x4a_e230, x4a_e13inf, x4a_e120, x4a_e123, x4a_e2inf0, x4a_e3inf0, x4a_e23inf, x4a_e130, x4a_e1inf0, x4a_einf, 
			x4b_e12inf, x4b_e1inf0, x4b_einf, x4b_e130, x4b_e3inf0, x4b_e123, x4b_e120, x4b_e2inf0, x4b_e23inf, x4b_e13inf, x4b_e0, x4b_e1, x4b_e2, x4b_e230, x4b_e3
		);
	}
}
