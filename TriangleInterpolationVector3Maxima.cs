using System;
using System;

public static class TriangleInterpolationVector3Maxima
{
	public static (Godot.Vector3, Godot.Vector3, Godot.Vector3, Godot.Vector3, Godot.Vector3, Godot.Vector3) Execute(float ax, float ay, float az, float bx, float by, float bz, float cx, float cy, float cz, float t)
	{
		float At_e012 = 0.5646044625f * ax - 0.8253494889062499f * az;
		float At_e013 = 0.9999899889062499f * ay + 0.399867025f;
		float At_e023 = (-(0.5646044625f * az)) - 0.8253494889062499f * ax;
		float At_e123 = 0.9999899889062499f;
		float Bt_e012 = 0.5646044625f * bx - 0.8253494889062499f * bz;
		float Bt_e013 = 0.9999899889062499f * by + 0.399867025f;
		float Bt_e023 = (-(0.5646044625f * bz)) - 0.8253494889062499f * bx;
		float Bt_e123 = 0.9999899889062499f;
		float Ct_e012 = 0.5646044625f * cx - 0.8253494889062499f * cz;
		float Ct_e013 = 0.9999899889062499f * cy + 0.399867025f;
		float Ct_e023 = (-(0.5646044625f * cz)) - 0.8253494889062499f * cx;
		float Ct_e123 = 0.9999899889062499f;
		float macro_Motor_temp_e01 = 0.9999899889062499f * ax + At_e023;
		float macro_Motor_temp_e02 = 0.9999899889062499f * ay - At_e013;
		float macro_Motor_temp_e03 = 0.9999899889062499f * az + At_e012;
		float VA_e01 = 0.5000025027859653f * macro_Motor_temp_e01;
		float VA_e02 = 0.5000025027859653f * macro_Motor_temp_e02;
		float VA_e03 = 0.5000025027859653f * macro_Motor_temp_e03;
		float B2_e012 = 2.0f * VA_e03 - bz;
		float B2_e013 = by - 2.0f * VA_e02;
		float B2_e023 = 2.0f * VA_e01 - bx;
		float C2_e012 = 2.0f * VA_e03 - cz;
		float C2_e013 = cy - 2.0f * VA_e02;
		float C2_e023 = 2.0f * VA_e01 - cx;
		float L1_e01 = At_e012 * Bt_e013 - At_e013 * Bt_e012;
		float L1_e02 = At_e012 * Bt_e023 - At_e023 * Bt_e012;
		float L1_e03 = At_e013 * Bt_e023 - At_e023 * Bt_e013;
		float L1_e12 = 0.9999899889062499f * At_e012 - 0.9999899889062499f * Bt_e012;
		float L1_e13 = 0.9999899889062499f * At_e013 - 0.9999899889062499f * Bt_e013;
		float L1_e23 = 0.9999899889062499f * At_e023 - 0.9999899889062499f * Bt_e023;
		float L2_e01 = At_e012 * B2_e013 - At_e013 * B2_e012;
		float L2_e02 = At_e012 * B2_e023 - At_e023 * B2_e012;
		float L2_e03 = At_e013 * B2_e023 - At_e023 * B2_e013;
		float L2_e12 = At_e012 - 0.9999899889062499f * B2_e012;
		float L2_e13 = At_e013 - 0.9999899889062499f * B2_e013;
		float L2_e23 = At_e023 - 0.9999899889062499f * B2_e023;
		float macro_Motor_temp1_1 = (MathF.Pow(L2_e13, 8.0f) + L1_e13 * MathF.Pow(L2_e13, 7.0f) + (4.0f * L2_e12 * L2_e12 + L1_e12 * L2_e12 + 4.0f * L2_e23 * L2_e23 + L1_e23 * L2_e23) * MathF.Pow(L2_e13, 6.0f) + (3.0f * L1_e13 * L2_e12 * L2_e12 + 3.0f * L1_e13 * L2_e23 * L2_e23) * MathF.Pow(L2_e13, 5.0f) + (6.0f * MathF.Pow(L2_e12, 4.0f) + 3.0f * L1_e12 * L2_e12 * L2_e12 * L2_e12 + (12.0f * L2_e23 * L2_e23 + 3.0f * L1_e23 * L2_e23) * L2_e12 * L2_e12 + 3.0f * L1_e12 * L2_e23 * L2_e23 * L2_e12 + 6.0f * MathF.Pow(L2_e23, 4.0f) + 3.0f * L1_e23 * L2_e23 * L2_e23 * L2_e23) * MathF.Pow(L2_e13, 4.0f) + (3.0f * L1_e13 * MathF.Pow(L2_e12, 4.0f) + 6.0f * L1_e13 * L2_e23 * L2_e23 * L2_e12 * L2_e12 + 3.0f * L1_e13 * MathF.Pow(L2_e23, 4.0f)) * L2_e13 * L2_e13 * L2_e13 + (4.0f * MathF.Pow(L2_e12, 6.0f) + 3.0f * L1_e12 * MathF.Pow(L2_e12, 5.0f) + (12.0f * L2_e23 * L2_e23 + 3.0f * L1_e23 * L2_e23) * MathF.Pow(L2_e12, 4.0f) + 6.0f * L1_e12 * L2_e23 * L2_e23 * L2_e12 * L2_e12 * L2_e12 + (12.0f * MathF.Pow(L2_e23, 4.0f) + 6.0f * L1_e23 * L2_e23 * L2_e23 * L2_e23) * L2_e12 * L2_e12 + 3.0f * L1_e12 * MathF.Pow(L2_e23, 4.0f) * L2_e12 + 4.0f * MathF.Pow(L2_e23, 6.0f) + 3.0f * L1_e23 * MathF.Pow(L2_e23, 5.0f)) * L2_e13 * L2_e13 + (L1_e13 * MathF.Pow(L2_e12, 6.0f) + 3.0f * L1_e13 * L2_e23 * L2_e23 * MathF.Pow(L2_e12, 4.0f) + 3.0f * L1_e13 * MathF.Pow(L2_e23, 4.0f) * L2_e12 * L2_e12 + L1_e13 * MathF.Pow(L2_e23, 6.0f)) * L2_e13 + MathF.Pow(L2_e12, 8.0f) + L1_e12 * MathF.Pow(L2_e12, 7.0f) + (4.0f * L2_e23 * L2_e23 + L1_e23 * L2_e23) * MathF.Pow(L2_e12, 6.0f) + 3.0f * L1_e12 * L2_e23 * L2_e23 * MathF.Pow(L2_e12, 5.0f) + (6.0f * MathF.Pow(L2_e23, 4.0f) + 3.0f * L1_e23 * L2_e23 * L2_e23 * L2_e23) * MathF.Pow(L2_e12, 4.0f) + 3.0f * L1_e12 * MathF.Pow(L2_e23, 4.0f) * L2_e12 * L2_e12 * L2_e12 + (4.0f * MathF.Pow(L2_e23, 6.0f) + 3.0f * L1_e23 * MathF.Pow(L2_e23, 5.0f)) * L2_e12 * L2_e12 + L1_e12 * MathF.Pow(L2_e23, 6.0f) * L2_e12 + MathF.Pow(L2_e23, 8.0f) + L1_e23 * MathF.Pow(L2_e23, 7.0f)) / (MathF.Pow(L2_e13, 8.0f) + (4.0f * L2_e12 * L2_e12 + 4.0f * L2_e23 * L2_e23) * MathF.Pow(L2_e13, 6.0f) + (6.0f * MathF.Pow(L2_e12, 4.0f) + 12.0f * L2_e23 * L2_e23 * L2_e12 * L2_e12 + 6.0f * MathF.Pow(L2_e23, 4.0f)) * MathF.Pow(L2_e13, 4.0f) + (4.0f * MathF.Pow(L2_e12, 6.0f) + 12.0f * L2_e23 * L2_e23 * MathF.Pow(L2_e12, 4.0f) + 12.0f * MathF.Pow(L2_e23, 4.0f) * L2_e12 * L2_e12 + 4.0f * MathF.Pow(L2_e23, 6.0f)) * L2_e13 * L2_e13 + MathF.Pow(L2_e12, 8.0f) + 4.0f * L2_e23 * L2_e23 * MathF.Pow(L2_e12, 6.0f) + 6.0f * MathF.Pow(L2_e23, 4.0f) * MathF.Pow(L2_e12, 4.0f) + 4.0f * MathF.Pow(L2_e23, 6.0f) * L2_e12 * L2_e12 + MathF.Pow(L2_e23, 8.0f));
		float macro_Motor_temp1_e01 = (L1_e03 * L2_e13 + L1_e02 * L2_e12 - L1_e13 * L2_e03 - L1_e12 * L2_e02) / (L2_e13 * L2_e13 + L2_e12 * L2_e12 + L2_e23 * L2_e23);
		float macro_Motor_temp1_e02 = (-((L1_e01 * L2_e12 + L1_e23 * L2_e03 + (-(L1_e12 * L2_e01)) - L1_e03 * L2_e23) / (L2_e13 * L2_e13 + L2_e12 * L2_e12 + L2_e23 * L2_e23)));
		float macro_Motor_temp1_e03 = (-((L1_e01 * L2_e13 + (-(L1_e23 * L2_e02)) - L1_e13 * L2_e01 + L1_e02 * L2_e23) / (L2_e13 * L2_e13 + L2_e12 * L2_e12 + L2_e23 * L2_e23)));
		float macro_Motor_temp1_e12 = (-((L1_e23 * L2_e13 + (-(L1_e13 * L2_e23))) / (L2_e13 * L2_e13 + L2_e12 * L2_e12 + L2_e23 * L2_e23)));
		float macro_Motor_temp1_e13 = (-(((-(L1_e23 * L2_e12)) + L1_e12 * L2_e23) / (L2_e13 * L2_e13 + L2_e12 * L2_e12 + L2_e23 * L2_e23)));
		float macro_Motor_temp1_e23 = (L1_e12 * L2_e13 - L1_e13 * L2_e12) / (L2_e13 * L2_e13 + L2_e12 * L2_e12 + L2_e23 * L2_e23);
		float macro_Motor_temp1_e0123 = (L1_e02 * L2_e13 - L1_e03 * L2_e12 - L1_e12 * L2_e03 + L1_e13 * L2_e02 - L1_e23 * L2_e01 - L1_e01 * L2_e23) / (L2_e13 * L2_e13 + L2_e12 * L2_e12 + L2_e23 * L2_e23);
		float macro_Motor_abstemp1_1 = MathF.Sqrt(macro_Motor_temp1_e13 * macro_Motor_temp1_e13 + macro_Motor_temp1_e12 * macro_Motor_temp1_e12 + macro_Motor_temp1_e23 * macro_Motor_temp1_e23 + macro_Motor_temp1_1 * macro_Motor_temp1_1);
		float VB_1 = macro_Motor_temp1_1 / macro_Motor_abstemp1_1;
		float VB_e01 = macro_Motor_temp1_e01 / macro_Motor_abstemp1_1;
		float VB_e02 = macro_Motor_temp1_e02 / macro_Motor_abstemp1_1;
		float VB_e03 = macro_Motor_temp1_e03 / macro_Motor_abstemp1_1;
		float VB_e12 = macro_Motor_temp1_e12 / macro_Motor_abstemp1_1;
		float VB_e13 = macro_Motor_temp1_e13 / macro_Motor_abstemp1_1;
		float VB_e23 = macro_Motor_temp1_e23 / macro_Motor_abstemp1_1;
		float VB_e0123 = macro_Motor_temp1_e0123 / macro_Motor_abstemp1_1;
		float C3_e012 = (-(C2_e012 * VB_e13 * VB_e13)) + (2.0f * C2_e013 * VB_e12 - 2.0f * VB_e01 - 2.0f * C2_e023 * VB_1) * VB_e13 + C2_e012 * VB_e12 * VB_e12 + (2.0f * VB_e0123 + 2.0f * C2_e023 * VB_e23) * VB_e12 + 2.0f * VB_1 * VB_e03 - 2.0f * VB_e23 * VB_e02 - C2_e012 * VB_e23 * VB_e23 + 2.0f * C2_e013 * VB_1 * VB_e23 + C2_e012 * VB_1 * VB_1;
		float C3_e013 = C2_e013 * VB_e13 * VB_e13 + (2.0f * C2_e012 * VB_e12 + 2.0f * VB_e0123 + 2.0f * C2_e023 * VB_e23) * VB_e13 - C2_e013 * VB_e12 * VB_e12 + (2.0f * VB_e01 + 2.0f * C2_e023 * VB_1) * VB_e12 - 2.0f * VB_e23 * VB_e03 - 2.0f * VB_1 * VB_e02 - C2_e013 * VB_e23 * VB_e23 - 2.0f * C2_e012 * VB_1 * VB_e23 + C2_e013 * VB_1 * VB_1;
		float C3_e023 = (-(C2_e023 * VB_e13 * VB_e13)) + (2.0f * VB_e03 + 2.0f * C2_e013 * VB_e23 + 2.0f * C2_e012 * VB_1) * VB_e13 - C2_e023 * VB_e12 * VB_e12 + (2.0f * VB_e02 + 2.0f * C2_e012 * VB_e23 - 2.0f * C2_e013 * VB_1) * VB_e12 + 2.0f * VB_1 * VB_e01 + 2.0f * VB_e23 * VB_e0123 + C2_e023 * VB_e23 * VB_e23 + C2_e023 * VB_1 * VB_1;
		float C3_e123 = VB_e13 * VB_e13 + VB_e12 * VB_e12 + VB_e23 * VB_e23 + VB_1 * VB_1;
		float P1_e0 = (-(Ct_e012 * L1_e03)) + Ct_e013 * L1_e02 - Ct_e023 * L1_e01;
		float P1_e1 = (-(Ct_e012 * L1_e13)) + Ct_e013 * L1_e12 - 0.9999899889062499f * L1_e01;
		float P1_e2 = Ct_e023 * L1_e12 - 0.9999899889062499f * L1_e02 - Ct_e012 * L1_e23;
		float P1_e3 = Ct_e023 * L1_e13 - 0.9999899889062499f * L1_e03 - Ct_e013 * L1_e23;
		float P2_e0 = (-(C3_e012 * L1_e03)) + C3_e013 * L1_e02 - C3_e023 * L1_e01;
		float P2_e1 = (-(C3_e012 * L1_e13)) + C3_e013 * L1_e12 - C3_e123 * L1_e01;
		float P2_e2 = C3_e023 * L1_e12 - C3_e123 * L1_e02 - C3_e012 * L1_e23;
		float P2_e3 = C3_e023 * L1_e13 - C3_e123 * L1_e03 - C3_e013 * L1_e23;
		float macro_Motor_temp2_1 = (MathF.Pow(P2_e3, 6.0f) + P1_e3 * MathF.Pow(P2_e3, 5.0f) + (3.0f * P2_e2 * P2_e2 + P1_e2 * P2_e2 + 3.0f * P2_e1 * P2_e1 + P1_e1 * P2_e1) * MathF.Pow(P2_e3, 4.0f) + (2.0f * P1_e3 * P2_e2 * P2_e2 + 2.0f * P1_e3 * P2_e1 * P2_e1) * P2_e3 * P2_e3 * P2_e3 + (3.0f * MathF.Pow(P2_e2, 4.0f) + 2.0f * P1_e2 * P2_e2 * P2_e2 * P2_e2 + (6.0f * P2_e1 * P2_e1 + 2.0f * P1_e1 * P2_e1) * P2_e2 * P2_e2 + 2.0f * P1_e2 * P2_e1 * P2_e1 * P2_e2 + 3.0f * MathF.Pow(P2_e1, 4.0f) + 2.0f * P1_e1 * P2_e1 * P2_e1 * P2_e1) * P2_e3 * P2_e3 + (P1_e3 * MathF.Pow(P2_e2, 4.0f) + 2.0f * P1_e3 * P2_e1 * P2_e1 * P2_e2 * P2_e2 + P1_e3 * MathF.Pow(P2_e1, 4.0f)) * P2_e3 + MathF.Pow(P2_e2, 6.0f) + P1_e2 * MathF.Pow(P2_e2, 5.0f) + (3.0f * P2_e1 * P2_e1 + P1_e1 * P2_e1) * MathF.Pow(P2_e2, 4.0f) + 2.0f * P1_e2 * P2_e1 * P2_e1 * P2_e2 * P2_e2 * P2_e2 + (3.0f * MathF.Pow(P2_e1, 4.0f) + 2.0f * P1_e1 * P2_e1 * P2_e1 * P2_e1) * P2_e2 * P2_e2 + P1_e2 * MathF.Pow(P2_e1, 4.0f) * P2_e2 + MathF.Pow(P2_e1, 6.0f) + P1_e1 * MathF.Pow(P2_e1, 5.0f)) / (MathF.Pow(P2_e3, 6.0f) + (3.0f * P2_e2 * P2_e2 + 3.0f * P2_e1 * P2_e1) * MathF.Pow(P2_e3, 4.0f) + (3.0f * MathF.Pow(P2_e2, 4.0f) + 6.0f * P2_e1 * P2_e1 * P2_e2 * P2_e2 + 3.0f * MathF.Pow(P2_e1, 4.0f)) * P2_e3 * P2_e3 + MathF.Pow(P2_e2, 6.0f) + 3.0f * P2_e1 * P2_e1 * MathF.Pow(P2_e2, 4.0f) + 3.0f * MathF.Pow(P2_e1, 4.0f) * P2_e2 * P2_e2 + MathF.Pow(P2_e1, 6.0f));
		float macro_Motor_temp2_e01 = (P1_e0 * P2_e1 - P1_e1 * P2_e0) / (P2_e3 * P2_e3 + P2_e2 * P2_e2 + P2_e1 * P2_e1);
		float macro_Motor_temp2_e02 = (P1_e0 * P2_e2 - P1_e2 * P2_e0) / (P2_e3 * P2_e3 + P2_e2 * P2_e2 + P2_e1 * P2_e1);
		float macro_Motor_temp2_e03 = (P1_e0 * P2_e3 - P1_e3 * P2_e0) / (P2_e3 * P2_e3 + P2_e2 * P2_e2 + P2_e1 * P2_e1);
		float macro_Motor_temp2_e12 = (P1_e1 * P2_e2 - P1_e2 * P2_e1) / (P2_e3 * P2_e3 + P2_e2 * P2_e2 + P2_e1 * P2_e1);
		float macro_Motor_temp2_e13 = (P1_e1 * P2_e3 - P1_e3 * P2_e1) / (P2_e3 * P2_e3 + P2_e2 * P2_e2 + P2_e1 * P2_e1);
		float macro_Motor_temp2_e23 = (P1_e2 * P2_e3 - P1_e3 * P2_e2) / (P2_e3 * P2_e3 + P2_e2 * P2_e2 + P2_e1 * P2_e1);
		float macro_Motor_abstemp2_1 = MathF.Sqrt(macro_Motor_temp2_e13 * macro_Motor_temp2_e13 + macro_Motor_temp2_e12 * macro_Motor_temp2_e12 + macro_Motor_temp2_e23 * macro_Motor_temp2_e23 + macro_Motor_temp2_1 * macro_Motor_temp2_1);
		float VC_1 = macro_Motor_temp2_1 / macro_Motor_abstemp2_1;
		float VC_e01 = macro_Motor_temp2_e01 / macro_Motor_abstemp2_1;
		float VC_e02 = macro_Motor_temp2_e02 / macro_Motor_abstemp2_1;
		float VC_e03 = macro_Motor_temp2_e03 / macro_Motor_abstemp2_1;
		float VC_e12 = macro_Motor_temp2_e12 / macro_Motor_abstemp2_1;
		float VC_e13 = macro_Motor_temp2_e13 / macro_Motor_abstemp2_1;
		float VC_e23 = macro_Motor_temp2_e23 / macro_Motor_abstemp2_1;
		float V_1 = (-(VB_e13 * VC_e13)) - VB_e12 * VC_e12 - VB_e23 * VC_e23 + VB_1 * VC_1;
		float V_e01 = ((-(VA_e01 * VB_e13)) + VB_e03 - VA_e02 * VB_e23 + VA_e03 * VB_1) * VC_e13 + ((-(VA_e01 * VB_e12)) + VB_e02 + VA_e03 * VB_e23 + VA_e02 * VB_1) * VC_e12 - VB_e13 * VC_e03 - VB_e12 * VC_e02 + VB_1 * VC_e01 + (VA_e02 * VB_e13 - VA_e03 * VB_e12 - VB_e0123 - VA_e01 * VB_e23) * VC_e23 + (VA_e03 * VB_e13 + VA_e02 * VB_e12 + VB_e01 + VA_e01 * VB_1) * VC_1;
		float V_e02 = ((-(VA_e02 * VB_e13)) + VA_e03 * VB_e12 + VB_e0123 + VA_e01 * VB_e23) * VC_e13 + ((-(VA_e03 * VB_e13)) - VA_e02 * VB_e12 - VB_e01 + (-(VA_e01 * VB_1))) * VC_e12 - VB_e23 * VC_e03 + VB_1 * VC_e02 + VB_e12 * VC_e01 + ((-(VA_e01 * VB_e13)) + VB_e03 - VA_e02 * VB_e23 + VA_e03 * VB_1) * VC_e23 + ((-(VA_e01 * VB_e12)) + VB_e02 + VA_e03 * VB_e23 + VA_e02 * VB_1) * VC_1;
		float V_e03 = ((-(VA_e03 * VB_e13)) - VA_e02 * VB_e12 - VB_e01 + (-(VA_e01 * VB_1))) * VC_e13 + (VA_e02 * VB_e13 - VA_e03 * VB_e12 - VB_e0123 - VA_e01 * VB_e23) * VC_e12 + VB_1 * VC_e03 + VB_e23 * VC_e02 + VB_e13 * VC_e01 + (VA_e01 * VB_e12 - VB_e02 - VA_e03 * VB_e23 - VA_e02 * VB_1) * VC_e23 + ((-(VA_e01 * VB_e13)) + VB_e03 - VA_e02 * VB_e23 + VA_e03 * VB_1) * VC_1;
		float V_e12 = (-(VB_e23 * VC_e13)) + VB_1 * VC_e12 + VB_e13 * VC_e23 + VB_e12 * VC_1;
		float V_e13 = VB_1 * VC_e13 + VB_e23 * VC_e12 - VB_e12 * VC_e23 + VB_e13 * VC_1;
		float V_e23 = VB_e12 * VC_e13 - VB_e13 * VC_e12 + VB_1 * VC_e23 + VB_e23 * VC_1;
		float V_e0123 = (VA_e01 * VB_e12 - VB_e02 - VA_e03 * VB_e23 - VA_e02 * VB_1) * VC_e13 + ((-(VA_e01 * VB_e13)) + VB_e03 - VA_e02 * VB_e23 + VA_e03 * VB_1) * VC_e12 + VB_e12 * VC_e03 - VB_e13 * VC_e02 + VB_e23 * VC_e01 + (VA_e03 * VB_e13 + VA_e02 * VB_e12 + VB_e01 + VA_e01 * VB_1) * VC_e23 + ((-(VA_e02 * VB_e13)) + VA_e03 * VB_e12 + VB_e0123 + VA_e01 * VB_e23) * VC_1;
		float AI_e012 = ((V_e13 * V_e13 - V_e12 * V_e12 + V_e23 * V_e23 - V_1 * V_1 + 2.0f * V_1 - 1.0f) * az + (2.0f * V_e12 * V_e13 + (2.0f * V_1 - 2.0f) * V_e23) * ay + ((2.0f * V_1 - 2.0f) * V_e13 - 2.0f * V_e23 * V_e12) * ax - 2.0f * V_e01 * V_e13 + 2.0f * V_e0123 * V_e12 + (2.0f * V_1 - 2.0f) * V_e03 - 2.0f * V_e23 * V_e02) * t * t + ((2.0f - 2.0f * V_1) * az + 2.0f * V_e23 * ay + 2.0f * V_e13 * ax + 2.0f * V_e03) * t - az;
		float AI_e013 = (((2.0f * V_1 - 2.0f) * V_e23 - 2.0f * V_e12 * V_e13) * az + (V_e13 * V_e13 - V_e12 * V_e12 - V_e23 * V_e23 + V_1 * V_1 - 2.0f * V_1 + 1.0f) * ay + ((2.0f - 2.0f * V_1) * V_e12 - 2.0f * V_e23 * V_e13) * ax + 2.0f * V_e0123 * V_e13 + 2.0f * V_e01 * V_e12 - 2.0f * V_e23 * V_e03 + (2.0f - 2.0f * V_1) * V_e02) * t * t + (2.0f * V_e23 * az + (2.0f * V_1 - 2.0f) * ay - 2.0f * V_e12 * ax - 2.0f * V_e02) * t + ay;
		float AI_e023 = (((2.0f - 2.0f * V_1) * V_e13 - 2.0f * V_e23 * V_e12) * az + (2.0f * V_e23 * V_e13 + (2.0f - 2.0f * V_1) * V_e12) * ay + (V_e13 * V_e13 + V_e12 * V_e12 - V_e23 * V_e23 - V_1 * V_1 + 2.0f * V_1 - 1.0f) * ax + 2.0f * V_e03 * V_e13 + 2.0f * V_e02 * V_e12 + (2.0f * V_1 - 2.0f) * V_e01 + 2.0f * V_e23 * V_e0123) * t * t + ((-(2.0f * V_e13 * az)) - 2.0f * V_e12 * ay + (2.0f - 2.0f * V_1) * ax + 2.0f * V_e01) * t - ax;
		float AI_e123 = (V_e13 * V_e13 + V_e12 * V_e12 + V_e23 * V_e23 + V_1 * V_1 - 2.0f * V_1 + 1.0f) * t * t + (2.0f * V_1 - 2.0f) * t + 1.0f;
		float BI_e012 = ((V_e13 * V_e13 - V_e12 * V_e12 + V_e23 * V_e23 - V_1 * V_1 + 2.0f * V_1 - 1.0f) * bz + (2.0f * V_e12 * V_e13 + (2.0f * V_1 - 2.0f) * V_e23) * by + ((2.0f * V_1 - 2.0f) * V_e13 - 2.0f * V_e23 * V_e12) * bx - 2.0f * V_e01 * V_e13 + 2.0f * V_e0123 * V_e12 + (2.0f * V_1 - 2.0f) * V_e03 - 2.0f * V_e23 * V_e02) * t * t + ((2.0f - 2.0f * V_1) * bz + 2.0f * V_e23 * by + 2.0f * V_e13 * bx + 2.0f * V_e03) * t - bz;
		float BI_e013 = (((2.0f * V_1 - 2.0f) * V_e23 - 2.0f * V_e12 * V_e13) * bz + (V_e13 * V_e13 - V_e12 * V_e12 - V_e23 * V_e23 + V_1 * V_1 - 2.0f * V_1 + 1.0f) * by + ((2.0f - 2.0f * V_1) * V_e12 - 2.0f * V_e23 * V_e13) * bx + 2.0f * V_e0123 * V_e13 + 2.0f * V_e01 * V_e12 - 2.0f * V_e23 * V_e03 + (2.0f - 2.0f * V_1) * V_e02) * t * t + (2.0f * V_e23 * bz + (2.0f * V_1 - 2.0f) * by - 2.0f * V_e12 * bx - 2.0f * V_e02) * t + by;
		float BI_e023 = (((2.0f - 2.0f * V_1) * V_e13 - 2.0f * V_e23 * V_e12) * bz + (2.0f * V_e23 * V_e13 + (2.0f - 2.0f * V_1) * V_e12) * by + (V_e13 * V_e13 + V_e12 * V_e12 - V_e23 * V_e23 - V_1 * V_1 + 2.0f * V_1 - 1.0f) * bx + 2.0f * V_e03 * V_e13 + 2.0f * V_e02 * V_e12 + (2.0f * V_1 - 2.0f) * V_e01 + 2.0f * V_e23 * V_e0123) * t * t + ((-(2.0f * V_e13 * bz)) - 2.0f * V_e12 * by + (2.0f - 2.0f * V_1) * bx + 2.0f * V_e01) * t - bx;
		float BI_e123 = (V_e13 * V_e13 + V_e12 * V_e12 + V_e23 * V_e23 + V_1 * V_1 - 2.0f * V_1 + 1.0f) * t * t + (2.0f * V_1 - 2.0f) * t + 1.0f;
		float CI_e012 = ((V_e13 * V_e13 - V_e12 * V_e12 + V_e23 * V_e23 - V_1 * V_1 + 2.0f * V_1 - 1.0f) * cz + (2.0f * V_e12 * V_e13 + (2.0f * V_1 - 2.0f) * V_e23) * cy + ((2.0f * V_1 - 2.0f) * V_e13 - 2.0f * V_e23 * V_e12) * cx - 2.0f * V_e01 * V_e13 + 2.0f * V_e0123 * V_e12 + (2.0f * V_1 - 2.0f) * V_e03 - 2.0f * V_e23 * V_e02) * t * t + ((2.0f - 2.0f * V_1) * cz + 2.0f * V_e23 * cy + 2.0f * V_e13 * cx + 2.0f * V_e03) * t - cz;
		float CI_e013 = (((2.0f * V_1 - 2.0f) * V_e23 - 2.0f * V_e12 * V_e13) * cz + (V_e13 * V_e13 - V_e12 * V_e12 - V_e23 * V_e23 + V_1 * V_1 - 2.0f * V_1 + 1.0f) * cy + ((2.0f - 2.0f * V_1) * V_e12 - 2.0f * V_e23 * V_e13) * cx + 2.0f * V_e0123 * V_e13 + 2.0f * V_e01 * V_e12 - 2.0f * V_e23 * V_e03 + (2.0f - 2.0f * V_1) * V_e02) * t * t + (2.0f * V_e23 * cz + (2.0f * V_1 - 2.0f) * cy - 2.0f * V_e12 * cx - 2.0f * V_e02) * t + cy;
		float CI_e023 = (((2.0f - 2.0f * V_1) * V_e13 - 2.0f * V_e23 * V_e12) * cz + (2.0f * V_e23 * V_e13 + (2.0f - 2.0f * V_1) * V_e12) * cy + (V_e13 * V_e13 + V_e12 * V_e12 - V_e23 * V_e23 - V_1 * V_1 + 2.0f * V_1 - 1.0f) * cx + 2.0f * V_e03 * V_e13 + 2.0f * V_e02 * V_e12 + (2.0f * V_1 - 2.0f) * V_e01 + 2.0f * V_e23 * V_e0123) * t * t + ((-(2.0f * V_e13 * cz)) - 2.0f * V_e12 * cy + (2.0f - 2.0f * V_1) * cx + 2.0f * V_e01) * t - cx;
		float CI_e123 = (V_e13 * V_e13 + V_e12 * V_e12 + V_e23 * V_e23 + V_1 * V_1 - 2.0f * V_1 + 1.0f) * t * t + (2.0f * V_1 - 2.0f) * t + 1.0f;


		return (
			new Godot.Vector3(AI_e012, AI_e013, AI_e023),
			new Godot.Vector3(At_e012, At_e013, At_e023),
			new Godot.Vector3(BI_e012, BI_e013, BI_e023),
			new Godot.Vector3(Bt_e012, Bt_e013, Bt_e023),
			new Godot.Vector3(CI_e012, CI_e013, CI_e023),
			new Godot.Vector3(Ct_e012, Ct_e013, Ct_e023)
		);
	}
}
