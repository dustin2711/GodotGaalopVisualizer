using System;

public static class TriangleInterpolationArraysMaxima
{
	public static void Execute(float ax, float ay, float az, float bx, float by, float bz, float cx, float cy, float cz, float t, float[] AI, float[] At, float[] BI, float[] Bt, float[] CI, float[] Ct)
	{
		float[] B2 = new float[16];
		float[] C2 = new float[16];
		float[] C3 = new float[16];
		float[] L1 = new float[16];
		float[] L2 = new float[16];
		float[] macro_Motor_abstemp1 = new float[16];
		float[] macro_Motor_abstemp2 = new float[16];
		float[] macro_Motor_temp = new float[16];
		float[] macro_Motor_temp1 = new float[16];
		float[] macro_Motor_temp2 = new float[16];
		float[] P1 = new float[16];
		float[] P2 = new float[16];
		float[] V = new float[16];
		float[] VA = new float[16];
		float[] VB = new float[16];
		float[] VC = new float[16];
		At[11] = 0.5646044625f * ax - 0.8253494889062499f * az;
		At[12] = 0.9999899889062499f * ay + 0.399867025f;
		At[13] = (-(0.5646044625f * az)) - 0.8253494889062499f * ax;
		At[14] = 0.9999899889062499f;
		Bt[11] = 0.5646044625f * bx - 0.8253494889062499f * bz;
		Bt[12] = 0.9999899889062499f * by + 0.399867025f;
		Bt[13] = (-(0.5646044625f * bz)) - 0.8253494889062499f * bx;
		Bt[14] = 0.9999899889062499f;
		Ct[11] = 0.5646044625f * cx - 0.8253494889062499f * cz;
		Ct[12] = 0.9999899889062499f * cy + 0.399867025f;
		Ct[13] = (-(0.5646044625f * cz)) - 0.8253494889062499f * cx;
		Ct[14] = 0.9999899889062499f;
		macro_Motor_temp[5] = 0.9999899889062499f * ax + At[13];
		macro_Motor_temp[6] = 0.9999899889062499f * ay - At[12];
		macro_Motor_temp[7] = 0.9999899889062499f * az + At[11];
		VA[5] = 0.5000025027859653f * macro_Motor_temp[5];
		VA[6] = 0.5000025027859653f * macro_Motor_temp[6];
		VA[7] = 0.5000025027859653f * macro_Motor_temp[7];
		B2[11] = 2.0f * VA[7] - bz;
		B2[12] = by - 2.0f * VA[6];
		B2[13] = 2.0f * VA[5] - bx;
		C2[11] = 2.0f * VA[7] - cz;
		C2[12] = cy - 2.0f * VA[6];
		C2[13] = 2.0f * VA[5] - cx;
		L1[5] = At[11] * Bt[12] - At[12] * Bt[11];
		L1[6] = At[11] * Bt[13] - At[13] * Bt[11];
		L1[7] = At[12] * Bt[13] - At[13] * Bt[12];
		L1[8] = 0.9999899889062499f * At[11] - 0.9999899889062499f * Bt[11];
		L1[9] = 0.9999899889062499f * At[12] - 0.9999899889062499f * Bt[12];
		L1[10] = 0.9999899889062499f * At[13] - 0.9999899889062499f * Bt[13];
		L2[5] = At[11] * B2[12] - At[12] * B2[11];
		L2[6] = At[11] * B2[13] - At[13] * B2[11];
		L2[7] = At[12] * B2[13] - At[13] * B2[12];
		L2[8] = At[11] - 0.9999899889062499f * B2[11];
		L2[9] = At[12] - 0.9999899889062499f * B2[12];
		L2[10] = At[13] - 0.9999899889062499f * B2[13];
		macro_Motor_temp1[0] = (MathF.Pow(L2[9], 8.0f) + L1[9] * MathF.Pow(L2[9], 7.0f) + (4.0f * L2[8] * L2[8] + L1[8] * L2[8] + 4.0f * L2[10] * L2[10] + L1[10] * L2[10]) * MathF.Pow(L2[9], 6.0f) + (3.0f * L1[9] * L2[8] * L2[8] + 3.0f * L1[9] * L2[10] * L2[10]) * MathF.Pow(L2[9], 5.0f) + (6.0f * MathF.Pow(L2[8], 4.0f) + 3.0f * L1[8] * L2[8] * L2[8] * L2[8] + (12.0f * L2[10] * L2[10] + 3.0f * L1[10] * L2[10]) * L2[8] * L2[8] + 3.0f * L1[8] * L2[10] * L2[10] * L2[8] + 6.0f * MathF.Pow(L2[10], 4.0f) + 3.0f * L1[10] * L2[10] * L2[10] * L2[10]) * MathF.Pow(L2[9], 4.0f) + (3.0f * L1[9] * MathF.Pow(L2[8], 4.0f) + 6.0f * L1[9] * L2[10] * L2[10] * L2[8] * L2[8] + 3.0f * L1[9] * MathF.Pow(L2[10], 4.0f)) * L2[9] * L2[9] * L2[9] + (4.0f * MathF.Pow(L2[8], 6.0f) + 3.0f * L1[8] * MathF.Pow(L2[8], 5.0f) + (12.0f * L2[10] * L2[10] + 3.0f * L1[10] * L2[10]) * MathF.Pow(L2[8], 4.0f) + 6.0f * L1[8] * L2[10] * L2[10] * L2[8] * L2[8] * L2[8] + (12.0f * MathF.Pow(L2[10], 4.0f) + 6.0f * L1[10] * L2[10] * L2[10] * L2[10]) * L2[8] * L2[8] + 3.0f * L1[8] * MathF.Pow(L2[10], 4.0f) * L2[8] + 4.0f * MathF.Pow(L2[10], 6.0f) + 3.0f * L1[10] * MathF.Pow(L2[10], 5.0f)) * L2[9] * L2[9] + (L1[9] * MathF.Pow(L2[8], 6.0f) + 3.0f * L1[9] * L2[10] * L2[10] * MathF.Pow(L2[8], 4.0f) + 3.0f * L1[9] * MathF.Pow(L2[10], 4.0f) * L2[8] * L2[8] + L1[9] * MathF.Pow(L2[10], 6.0f)) * L2[9] + MathF.Pow(L2[8], 8.0f) + L1[8] * MathF.Pow(L2[8], 7.0f) + (4.0f * L2[10] * L2[10] + L1[10] * L2[10]) * MathF.Pow(L2[8], 6.0f) + 3.0f * L1[8] * L2[10] * L2[10] * MathF.Pow(L2[8], 5.0f) + (6.0f * MathF.Pow(L2[10], 4.0f) + 3.0f * L1[10] * L2[10] * L2[10] * L2[10]) * MathF.Pow(L2[8], 4.0f) + 3.0f * L1[8] * MathF.Pow(L2[10], 4.0f) * L2[8] * L2[8] * L2[8] + (4.0f * MathF.Pow(L2[10], 6.0f) + 3.0f * L1[10] * MathF.Pow(L2[10], 5.0f)) * L2[8] * L2[8] + L1[8] * MathF.Pow(L2[10], 6.0f) * L2[8] + MathF.Pow(L2[10], 8.0f) + L1[10] * MathF.Pow(L2[10], 7.0f)) / (MathF.Pow(L2[9], 8.0f) + (4.0f * L2[8] * L2[8] + 4.0f * L2[10] * L2[10]) * MathF.Pow(L2[9], 6.0f) + (6.0f * MathF.Pow(L2[8], 4.0f) + 12.0f * L2[10] * L2[10] * L2[8] * L2[8] + 6.0f * MathF.Pow(L2[10], 4.0f)) * MathF.Pow(L2[9], 4.0f) + (4.0f * MathF.Pow(L2[8], 6.0f) + 12.0f * L2[10] * L2[10] * MathF.Pow(L2[8], 4.0f) + 12.0f * MathF.Pow(L2[10], 4.0f) * L2[8] * L2[8] + 4.0f * MathF.Pow(L2[10], 6.0f)) * L2[9] * L2[9] + MathF.Pow(L2[8], 8.0f) + 4.0f * L2[10] * L2[10] * MathF.Pow(L2[8], 6.0f) + 6.0f * MathF.Pow(L2[10], 4.0f) * MathF.Pow(L2[8], 4.0f) + 4.0f * MathF.Pow(L2[10], 6.0f) * L2[8] * L2[8] + MathF.Pow(L2[10], 8.0f));
		macro_Motor_temp1[5] = (L1[7] * L2[9] + L1[6] * L2[8] - L1[9] * L2[7] - L1[8] * L2[6]) / (L2[9] * L2[9] + L2[8] * L2[8] + L2[10] * L2[10]);
		macro_Motor_temp1[6] = (-((L1[5] * L2[8] + L1[10] * L2[7] + (-(L1[8] * L2[5])) - L1[7] * L2[10]) / (L2[9] * L2[9] + L2[8] * L2[8] + L2[10] * L2[10])));
		macro_Motor_temp1[7] = (-((L1[5] * L2[9] + (-(L1[10] * L2[6])) - L1[9] * L2[5] + L1[6] * L2[10]) / (L2[9] * L2[9] + L2[8] * L2[8] + L2[10] * L2[10])));
		macro_Motor_temp1[8] = (-((L1[10] * L2[9] + (-(L1[9] * L2[10]))) / (L2[9] * L2[9] + L2[8] * L2[8] + L2[10] * L2[10])));
		macro_Motor_temp1[9] = (-(((-(L1[10] * L2[8])) + L1[8] * L2[10]) / (L2[9] * L2[9] + L2[8] * L2[8] + L2[10] * L2[10])));
		macro_Motor_temp1[10] = (L1[8] * L2[9] - L1[9] * L2[8]) / (L2[9] * L2[9] + L2[8] * L2[8] + L2[10] * L2[10]);
		macro_Motor_temp1[15] = (L1[6] * L2[9] - L1[7] * L2[8] - L1[8] * L2[7] + L1[9] * L2[6] - L1[10] * L2[5] - L1[5] * L2[10]) / (L2[9] * L2[9] + L2[8] * L2[8] + L2[10] * L2[10]);
		macro_Motor_abstemp1[0] = MathF.Sqrt(macro_Motor_temp1[9] * macro_Motor_temp1[9] + macro_Motor_temp1[8] * macro_Motor_temp1[8] + macro_Motor_temp1[10] * macro_Motor_temp1[10] + macro_Motor_temp1[0] * macro_Motor_temp1[0]);
		VB[0] = macro_Motor_temp1[0] / macro_Motor_abstemp1[0];
		VB[5] = macro_Motor_temp1[5] / macro_Motor_abstemp1[0];
		VB[6] = macro_Motor_temp1[6] / macro_Motor_abstemp1[0];
		VB[7] = macro_Motor_temp1[7] / macro_Motor_abstemp1[0];
		VB[8] = macro_Motor_temp1[8] / macro_Motor_abstemp1[0];
		VB[9] = macro_Motor_temp1[9] / macro_Motor_abstemp1[0];
		VB[10] = macro_Motor_temp1[10] / macro_Motor_abstemp1[0];
		VB[15] = macro_Motor_temp1[15] / macro_Motor_abstemp1[0];
		C3[11] = (-(C2[11] * VB[9] * VB[9])) + (2.0f * C2[12] * VB[8] - 2.0f * VB[5] - 2.0f * C2[13] * VB[0]) * VB[9] + C2[11] * VB[8] * VB[8] + (2.0f * VB[15] + 2.0f * C2[13] * VB[10]) * VB[8] + 2.0f * VB[0] * VB[7] - 2.0f * VB[10] * VB[6] - C2[11] * VB[10] * VB[10] + 2.0f * C2[12] * VB[0] * VB[10] + C2[11] * VB[0] * VB[0];
		C3[12] = C2[12] * VB[9] * VB[9] + (2.0f * C2[11] * VB[8] + 2.0f * VB[15] + 2.0f * C2[13] * VB[10]) * VB[9] - C2[12] * VB[8] * VB[8] + (2.0f * VB[5] + 2.0f * C2[13] * VB[0]) * VB[8] - 2.0f * VB[10] * VB[7] - 2.0f * VB[0] * VB[6] - C2[12] * VB[10] * VB[10] - 2.0f * C2[11] * VB[0] * VB[10] + C2[12] * VB[0] * VB[0];
		C3[13] = (-(C2[13] * VB[9] * VB[9])) + (2.0f * VB[7] + 2.0f * C2[12] * VB[10] + 2.0f * C2[11] * VB[0]) * VB[9] - C2[13] * VB[8] * VB[8] + (2.0f * VB[6] + 2.0f * C2[11] * VB[10] - 2.0f * C2[12] * VB[0]) * VB[8] + 2.0f * VB[0] * VB[5] + 2.0f * VB[10] * VB[15] + C2[13] * VB[10] * VB[10] + C2[13] * VB[0] * VB[0];
		C3[14] = VB[9] * VB[9] + VB[8] * VB[8] + VB[10] * VB[10] + VB[0] * VB[0];
		P1[1] = (-(Ct[11] * L1[7])) + Ct[12] * L1[6] - Ct[13] * L1[5];
		P1[2] = (-(Ct[11] * L1[9])) + Ct[12] * L1[8] - 0.9999899889062499f * L1[5];
		P1[3] = Ct[13] * L1[8] - 0.9999899889062499f * L1[6] - Ct[11] * L1[10];
		P1[4] = Ct[13] * L1[9] - 0.9999899889062499f * L1[7] - Ct[12] * L1[10];
		P2[1] = (-(C3[11] * L1[7])) + C3[12] * L1[6] - C3[13] * L1[5];
		P2[2] = (-(C3[11] * L1[9])) + C3[12] * L1[8] - C3[14] * L1[5];
		P2[3] = C3[13] * L1[8] - C3[14] * L1[6] - C3[11] * L1[10];
		P2[4] = C3[13] * L1[9] - C3[14] * L1[7] - C3[12] * L1[10];
		macro_Motor_temp2[0] = (MathF.Pow(P2[4], 6.0f) + P1[4] * MathF.Pow(P2[4], 5.0f) + (3.0f * P2[3] * P2[3] + P1[3] * P2[3] + 3.0f * P2[2] * P2[2] + P1[2] * P2[2]) * MathF.Pow(P2[4], 4.0f) + (2.0f * P1[4] * P2[3] * P2[3] + 2.0f * P1[4] * P2[2] * P2[2]) * P2[4] * P2[4] * P2[4] + (3.0f * MathF.Pow(P2[3], 4.0f) + 2.0f * P1[3] * P2[3] * P2[3] * P2[3] + (6.0f * P2[2] * P2[2] + 2.0f * P1[2] * P2[2]) * P2[3] * P2[3] + 2.0f * P1[3] * P2[2] * P2[2] * P2[3] + 3.0f * MathF.Pow(P2[2], 4.0f) + 2.0f * P1[2] * P2[2] * P2[2] * P2[2]) * P2[4] * P2[4] + (P1[4] * MathF.Pow(P2[3], 4.0f) + 2.0f * P1[4] * P2[2] * P2[2] * P2[3] * P2[3] + P1[4] * MathF.Pow(P2[2], 4.0f)) * P2[4] + MathF.Pow(P2[3], 6.0f) + P1[3] * MathF.Pow(P2[3], 5.0f) + (3.0f * P2[2] * P2[2] + P1[2] * P2[2]) * MathF.Pow(P2[3], 4.0f) + 2.0f * P1[3] * P2[2] * P2[2] * P2[3] * P2[3] * P2[3] + (3.0f * MathF.Pow(P2[2], 4.0f) + 2.0f * P1[2] * P2[2] * P2[2] * P2[2]) * P2[3] * P2[3] + P1[3] * MathF.Pow(P2[2], 4.0f) * P2[3] + MathF.Pow(P2[2], 6.0f) + P1[2] * MathF.Pow(P2[2], 5.0f)) / (MathF.Pow(P2[4], 6.0f) + (3.0f * P2[3] * P2[3] + 3.0f * P2[2] * P2[2]) * MathF.Pow(P2[4], 4.0f) + (3.0f * MathF.Pow(P2[3], 4.0f) + 6.0f * P2[2] * P2[2] * P2[3] * P2[3] + 3.0f * MathF.Pow(P2[2], 4.0f)) * P2[4] * P2[4] + MathF.Pow(P2[3], 6.0f) + 3.0f * P2[2] * P2[2] * MathF.Pow(P2[3], 4.0f) + 3.0f * MathF.Pow(P2[2], 4.0f) * P2[3] * P2[3] + MathF.Pow(P2[2], 6.0f));
		macro_Motor_temp2[5] = (P1[1] * P2[2] - P1[2] * P2[1]) / (P2[4] * P2[4] + P2[3] * P2[3] + P2[2] * P2[2]);
		macro_Motor_temp2[6] = (P1[1] * P2[3] - P1[3] * P2[1]) / (P2[4] * P2[4] + P2[3] * P2[3] + P2[2] * P2[2]);
		macro_Motor_temp2[7] = (P1[1] * P2[4] - P1[4] * P2[1]) / (P2[4] * P2[4] + P2[3] * P2[3] + P2[2] * P2[2]);
		macro_Motor_temp2[8] = (P1[2] * P2[3] - P1[3] * P2[2]) / (P2[4] * P2[4] + P2[3] * P2[3] + P2[2] * P2[2]);
		macro_Motor_temp2[9] = (P1[2] * P2[4] - P1[4] * P2[2]) / (P2[4] * P2[4] + P2[3] * P2[3] + P2[2] * P2[2]);
		macro_Motor_temp2[10] = (P1[3] * P2[4] - P1[4] * P2[3]) / (P2[4] * P2[4] + P2[3] * P2[3] + P2[2] * P2[2]);
		macro_Motor_abstemp2[0] = MathF.Sqrt(macro_Motor_temp2[9] * macro_Motor_temp2[9] + macro_Motor_temp2[8] * macro_Motor_temp2[8] + macro_Motor_temp2[10] * macro_Motor_temp2[10] + macro_Motor_temp2[0] * macro_Motor_temp2[0]);
		VC[0] = macro_Motor_temp2[0] / macro_Motor_abstemp2[0];
		VC[5] = macro_Motor_temp2[5] / macro_Motor_abstemp2[0];
		VC[6] = macro_Motor_temp2[6] / macro_Motor_abstemp2[0];
		VC[7] = macro_Motor_temp2[7] / macro_Motor_abstemp2[0];
		VC[8] = macro_Motor_temp2[8] / macro_Motor_abstemp2[0];
		VC[9] = macro_Motor_temp2[9] / macro_Motor_abstemp2[0];
		VC[10] = macro_Motor_temp2[10] / macro_Motor_abstemp2[0];
		V[0] = (-(VB[9] * VC[9])) - VB[8] * VC[8] - VB[10] * VC[10] + VB[0] * VC[0];
		V[5] = ((-(VA[5] * VB[9])) + VB[7] - VA[6] * VB[10] + VA[7] * VB[0]) * VC[9] + ((-(VA[5] * VB[8])) + VB[6] + VA[7] * VB[10] + VA[6] * VB[0]) * VC[8] - VB[9] * VC[7] - VB[8] * VC[6] + VB[0] * VC[5] + (VA[6] * VB[9] - VA[7] * VB[8] - VB[15] - VA[5] * VB[10]) * VC[10] + (VA[7] * VB[9] + VA[6] * VB[8] + VB[5] + VA[5] * VB[0]) * VC[0];
		V[6] = ((-(VA[6] * VB[9])) + VA[7] * VB[8] + VB[15] + VA[5] * VB[10]) * VC[9] + ((-(VA[7] * VB[9])) - VA[6] * VB[8] - VB[5] + (-(VA[5] * VB[0]))) * VC[8] - VB[10] * VC[7] + VB[0] * VC[6] + VB[8] * VC[5] + ((-(VA[5] * VB[9])) + VB[7] - VA[6] * VB[10] + VA[7] * VB[0]) * VC[10] + ((-(VA[5] * VB[8])) + VB[6] + VA[7] * VB[10] + VA[6] * VB[0]) * VC[0];
		V[7] = ((-(VA[7] * VB[9])) - VA[6] * VB[8] - VB[5] + (-(VA[5] * VB[0]))) * VC[9] + (VA[6] * VB[9] - VA[7] * VB[8] - VB[15] - VA[5] * VB[10]) * VC[8] + VB[0] * VC[7] + VB[10] * VC[6] + VB[9] * VC[5] + (VA[5] * VB[8] - VB[6] - VA[7] * VB[10] - VA[6] * VB[0]) * VC[10] + ((-(VA[5] * VB[9])) + VB[7] - VA[6] * VB[10] + VA[7] * VB[0]) * VC[0];
		V[8] = (-(VB[10] * VC[9])) + VB[0] * VC[8] + VB[9] * VC[10] + VB[8] * VC[0];
		V[9] = VB[0] * VC[9] + VB[10] * VC[8] - VB[8] * VC[10] + VB[9] * VC[0];
		V[10] = VB[8] * VC[9] - VB[9] * VC[8] + VB[0] * VC[10] + VB[10] * VC[0];
		V[15] = (VA[5] * VB[8] - VB[6] - VA[7] * VB[10] - VA[6] * VB[0]) * VC[9] + ((-(VA[5] * VB[9])) + VB[7] - VA[6] * VB[10] + VA[7] * VB[0]) * VC[8] + VB[8] * VC[7] - VB[9] * VC[6] + VB[10] * VC[5] + (VA[7] * VB[9] + VA[6] * VB[8] + VB[5] + VA[5] * VB[0]) * VC[10] + ((-(VA[6] * VB[9])) + VA[7] * VB[8] + VB[15] + VA[5] * VB[10]) * VC[0];
		AI[11] = ((V[9] * V[9] - V[8] * V[8] + V[10] * V[10] - V[0] * V[0] + 2.0f * V[0] - 1.0f) * az + (2.0f * V[8] * V[9] + (2.0f * V[0] - 2.0f) * V[10]) * ay + ((2.0f * V[0] - 2.0f) * V[9] - 2.0f * V[10] * V[8]) * ax - 2.0f * V[5] * V[9] + 2.0f * V[15] * V[8] + (2.0f * V[0] - 2.0f) * V[7] - 2.0f * V[10] * V[6]) * t * t + ((2.0f - 2.0f * V[0]) * az + 2.0f * V[10] * ay + 2.0f * V[9] * ax + 2.0f * V[7]) * t - az;
		AI[12] = (((2.0f * V[0] - 2.0f) * V[10] - 2.0f * V[8] * V[9]) * az + (V[9] * V[9] - V[8] * V[8] - V[10] * V[10] + V[0] * V[0] - 2.0f * V[0] + 1.0f) * ay + ((2.0f - 2.0f * V[0]) * V[8] - 2.0f * V[10] * V[9]) * ax + 2.0f * V[15] * V[9] + 2.0f * V[5] * V[8] - 2.0f * V[10] * V[7] + (2.0f - 2.0f * V[0]) * V[6]) * t * t + (2.0f * V[10] * az + (2.0f * V[0] - 2.0f) * ay - 2.0f * V[8] * ax - 2.0f * V[6]) * t + ay;
		AI[13] = (((2.0f - 2.0f * V[0]) * V[9] - 2.0f * V[10] * V[8]) * az + (2.0f * V[10] * V[9] + (2.0f - 2.0f * V[0]) * V[8]) * ay + (V[9] * V[9] + V[8] * V[8] - V[10] * V[10] - V[0] * V[0] + 2.0f * V[0] - 1.0f) * ax + 2.0f * V[7] * V[9] + 2.0f * V[6] * V[8] + (2.0f * V[0] - 2.0f) * V[5] + 2.0f * V[10] * V[15]) * t * t + ((-(2.0f * V[9] * az)) - 2.0f * V[8] * ay + (2.0f - 2.0f * V[0]) * ax + 2.0f * V[5]) * t - ax;
		AI[14] = (V[9] * V[9] + V[8] * V[8] + V[10] * V[10] + V[0] * V[0] - 2.0f * V[0] + 1.0f) * t * t + (2.0f * V[0] - 2.0f) * t + 1.0f;
		BI[11] = ((V[9] * V[9] - V[8] * V[8] + V[10] * V[10] - V[0] * V[0] + 2.0f * V[0] - 1.0f) * bz + (2.0f * V[8] * V[9] + (2.0f * V[0] - 2.0f) * V[10]) * by + ((2.0f * V[0] - 2.0f) * V[9] - 2.0f * V[10] * V[8]) * bx - 2.0f * V[5] * V[9] + 2.0f * V[15] * V[8] + (2.0f * V[0] - 2.0f) * V[7] - 2.0f * V[10] * V[6]) * t * t + ((2.0f - 2.0f * V[0]) * bz + 2.0f * V[10] * by + 2.0f * V[9] * bx + 2.0f * V[7]) * t - bz;
		BI[12] = (((2.0f * V[0] - 2.0f) * V[10] - 2.0f * V[8] * V[9]) * bz + (V[9] * V[9] - V[8] * V[8] - V[10] * V[10] + V[0] * V[0] - 2.0f * V[0] + 1.0f) * by + ((2.0f - 2.0f * V[0]) * V[8] - 2.0f * V[10] * V[9]) * bx + 2.0f * V[15] * V[9] + 2.0f * V[5] * V[8] - 2.0f * V[10] * V[7] + (2.0f - 2.0f * V[0]) * V[6]) * t * t + (2.0f * V[10] * bz + (2.0f * V[0] - 2.0f) * by - 2.0f * V[8] * bx - 2.0f * V[6]) * t + by;
		BI[13] = (((2.0f - 2.0f * V[0]) * V[9] - 2.0f * V[10] * V[8]) * bz + (2.0f * V[10] * V[9] + (2.0f - 2.0f * V[0]) * V[8]) * by + (V[9] * V[9] + V[8] * V[8] - V[10] * V[10] - V[0] * V[0] + 2.0f * V[0] - 1.0f) * bx + 2.0f * V[7] * V[9] + 2.0f * V[6] * V[8] + (2.0f * V[0] - 2.0f) * V[5] + 2.0f * V[10] * V[15]) * t * t + ((-(2.0f * V[9] * bz)) - 2.0f * V[8] * by + (2.0f - 2.0f * V[0]) * bx + 2.0f * V[5]) * t - bx;
		BI[14] = (V[9] * V[9] + V[8] * V[8] + V[10] * V[10] + V[0] * V[0] - 2.0f * V[0] + 1.0f) * t * t + (2.0f * V[0] - 2.0f) * t + 1.0f;
		CI[11] = ((V[9] * V[9] - V[8] * V[8] + V[10] * V[10] - V[0] * V[0] + 2.0f * V[0] - 1.0f) * cz + (2.0f * V[8] * V[9] + (2.0f * V[0] - 2.0f) * V[10]) * cy + ((2.0f * V[0] - 2.0f) * V[9] - 2.0f * V[10] * V[8]) * cx - 2.0f * V[5] * V[9] + 2.0f * V[15] * V[8] + (2.0f * V[0] - 2.0f) * V[7] - 2.0f * V[10] * V[6]) * t * t + ((2.0f - 2.0f * V[0]) * cz + 2.0f * V[10] * cy + 2.0f * V[9] * cx + 2.0f * V[7]) * t - cz;
		CI[12] = (((2.0f * V[0] - 2.0f) * V[10] - 2.0f * V[8] * V[9]) * cz + (V[9] * V[9] - V[8] * V[8] - V[10] * V[10] + V[0] * V[0] - 2.0f * V[0] + 1.0f) * cy + ((2.0f - 2.0f * V[0]) * V[8] - 2.0f * V[10] * V[9]) * cx + 2.0f * V[15] * V[9] + 2.0f * V[5] * V[8] - 2.0f * V[10] * V[7] + (2.0f - 2.0f * V[0]) * V[6]) * t * t + (2.0f * V[10] * cz + (2.0f * V[0] - 2.0f) * cy - 2.0f * V[8] * cx - 2.0f * V[6]) * t + cy;
		CI[13] = (((2.0f - 2.0f * V[0]) * V[9] - 2.0f * V[10] * V[8]) * cz + (2.0f * V[10] * V[9] + (2.0f - 2.0f * V[0]) * V[8]) * cy + (V[9] * V[9] + V[8] * V[8] - V[10] * V[10] - V[0] * V[0] + 2.0f * V[0] - 1.0f) * cx + 2.0f * V[7] * V[9] + 2.0f * V[6] * V[8] + (2.0f * V[0] - 2.0f) * V[5] + 2.0f * V[10] * V[15]) * t * t + ((-(2.0f * V[9] * cz)) - 2.0f * V[8] * cy + (2.0f - 2.0f * V[0]) * cx + 2.0f * V[5]) * t - cx;
		CI[14] = (V[9] * V[9] + V[8] * V[8] + V[10] * V[10] + V[0] * V[0] - 2.0f * V[0] + 1.0f) * t * t + (2.0f * V[0] - 2.0f) * t + 1.0f;
	}
}