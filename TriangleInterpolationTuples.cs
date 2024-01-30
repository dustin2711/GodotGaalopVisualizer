using System;
using Godot;

public static class TriangleInterpolationTuples
{
	public static (float AI_e123, float AI_e2, float AI_e3, float AI_e0, float AI_e1, float AI_e023, float AI_e012, float AI_e013, float At_e0, float At_e023, float At_e123, float At_e012, float At_e013, float BI_e012, float BI_e013, float BI_e1, float BI_e2, float BI_e3, float BI_e0, float BI_e023, float BI_e123, float Bt_e023, float Bt_e0, float Bt_e013, float Bt_e012, float Bt_e123, float CI_e023, float CI_e2, float CI_e3, float CI_e0, float CI_e1, float CI_e012, float CI_e013, float CI_e123, float Ct_e123, float Ct_e013, float Ct_e012, float Ct_e0, float Ct_e023) Execute(float ax, float ay, float az, float bx, float by, float bz, float cx, float cy, float cz, float t)
	{
		float A1_e012 = (-az);
		float A1_e023 = (-ax);
		float B1_e012 = (-bz);
		float B1_e023 = (-bx);
		float C1_e012 = (-cz);
		float C1_e023 = (-cx);
		float At_e0 = ((-(0.2955f * ay)) + -0.0591f) * 0.9553375f + -0.0564405f + (-((0.9553375f * ay + 0.191f) * -0.2955f)) + 0.05646044625f;
		float At_e012 = (0.9553375f * A1_e012 + (-(0.2955f * A1_e023))) * 0.9553375f + (0.9553375f * A1_e023 + 0.2955f * A1_e012) * -0.2955f;
		float At_e013 = ((-(0.2955f * ay)) + -0.0591f) * -0.2955f + 0.01746405f + (0.9553375f * ay + 0.191f) * 0.9553375f + 0.18246946249999998f;
		float At_e023 = (-((0.9553375f * A1_e012 + (-(0.2955f * A1_e023))) * -0.2955f)) + (0.9553375f * A1_e023 + 0.2955f * A1_e012) * 0.9553375f;
		float At_e123 = 0.9999899889062499f;
		float Bt_e0 = ((-(0.2955f * by)) + -0.0591f) * 0.9553375f + -0.0564405f + (-((0.9553375f * by + 0.191f) * -0.2955f)) + 0.05646044625f;
		float Bt_e012 = (0.9553375f * B1_e012 + (-(0.2955f * B1_e023))) * 0.9553375f + (0.9553375f * B1_e023 + 0.2955f * B1_e012) * -0.2955f;
		float Bt_e013 = ((-(0.2955f * by)) + -0.0591f) * -0.2955f + 0.01746405f + (0.9553375f * by + 0.191f) * 0.9553375f + 0.18246946249999998f;
		float Bt_e023 = (-((0.9553375f * B1_e012 + (-(0.2955f * B1_e023))) * -0.2955f)) + (0.9553375f * B1_e023 + 0.2955f * B1_e012) * 0.9553375f;
		float Bt_e123 = 0.9999899889062499f;
		float Ct_e0 = ((-(0.2955f * cy)) + -0.0591f) * 0.9553375f + -0.0564405f + (-((0.9553375f * cy + 0.191f) * -0.2955f)) + 0.05646044625f;
		float Ct_e012 = (0.9553375f * C1_e012 + (-(0.2955f * C1_e023))) * 0.9553375f + (0.9553375f * C1_e023 + 0.2955f * C1_e012) * -0.2955f;
		float Ct_e013 = ((-(0.2955f * cy)) + -0.0591f) * -0.2955f + 0.01746405f + (0.9553375f * cy + 0.191f) * 0.9553375f + 0.18246946249999998f;
		float Ct_e023 = (-((0.9553375f * C1_e012 + (-(0.2955f * C1_e023))) * -0.2955f)) + (0.9553375f * C1_e023 + 0.2955f * C1_e012) * 0.9553375f;
		float Ct_e123 = 0.9999899889062499f;
		float macro_Motor_temp_e01 = At_e023 + 0.9999899889062499f * (-A1_e023);
		float macro_Motor_temp_e02 = (-At_e013) + (-(0.9999899889062499f * (-ay)));
		float macro_Motor_temp_e03 = At_e012 + 0.9999899889062499f * (-A1_e012);
		float macro_Motor_temp_e0123 = (-At_e0);
		float VA_e01 = macro_Motor_temp_e01 * 0.5000025027859653f;
		float VA_e02 = macro_Motor_temp_e02 * 0.5000025027859653f;
		float VA_e03 = macro_Motor_temp_e03 * 0.5000025027859653f;
		float VA_e0123 = macro_Motor_temp_e0123 * 0.5000025027859653f;
		float B2_e0 = (-VA_e0123) + VA_e0123;
		float B2_e012 = B1_e012 + VA_e03 + VA_e03;
		float B2_e013 = by + (-VA_e02) + (-VA_e02);
		float B2_e023 = B1_e023 + VA_e01 + VA_e01;
		float C2_e0 = (-VA_e0123) + VA_e0123;
		float C2_e012 = C1_e012 + VA_e03 + VA_e03;
		float C2_e013 = cy + (-VA_e02) + (-VA_e02);
		float C2_e023 = C1_e023 + VA_e01 + VA_e01;
		float L1_1 = 0.9999899889062499f * Bt_e0 + (-(At_e0 * 0.9999899889062499f));
		float L1_e01 = At_e013 * (-Bt_e012) + (-((-At_e012) * Bt_e013));
		float L1_e02 = (-((-At_e023) * (-Bt_e012) + (-((-At_e012) * (-Bt_e023)))));
		float L1_e03 = (-At_e023) * Bt_e013 + (-(At_e013 * (-Bt_e023)));
		float L1_e12 = 0.9999899889062499f * (-Bt_e012) + (-((-At_e012) * 0.9999899889062499f));
		float L1_e13 = (-(0.9999899889062499f * Bt_e013 + (-(At_e013 * 0.9999899889062499f))));
		float L1_e23 = 0.9999899889062499f * (-Bt_e023) + (-((-At_e023) * 0.9999899889062499f));
		float L2_1 = 0.9999899889062499f * B2_e0 + (-At_e0);
		float L2_e01 = At_e013 * (-B2_e012) + (-((-At_e012) * B2_e013));
		float L2_e02 = (-((-At_e023) * (-B2_e012) + (-((-At_e012) * (-B2_e023)))));
		float L2_e03 = (-At_e023) * B2_e013 + (-(At_e013 * (-B2_e023)));
		float L2_e12 = 0.9999899889062499f * (-B2_e012) + At_e012;
		float L2_e13 = (-(0.9999899889062499f * B2_e013 + (-At_e013)));
		float L2_e23 = 0.9999899889062499f * (-B2_e023) + At_e023;
		float macro_Motor_temp1_1 = 1.0f + L1_1 * L2_1 / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))) + (-(L1_e12 * (-L2_e12) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))))) + (-(L1_e13 * (-L2_e13) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))))) + (-(L1_e23 * (-L2_e23) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23))))));
		float macro_Motor_temp1_e01 = L1_1 * (-L2_e01) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))) + L1_e01 * L2_1 / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))) + (-(L1_e02 * (-L2_e12) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))))) + (-(L1_e03 * (-L2_e13) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))))) + L1_e12 * (-L2_e02) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))) + L1_e13 * (-L2_e03) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23))));
		float macro_Motor_temp1_e02 = L1_1 * (-L2_e02) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))) + L1_e01 * (-L2_e12) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))) + L1_e02 * L2_1 / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))) + (-(L1_e03 * (-L2_e23) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))))) + (-(L1_e12 * (-L2_e01) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))))) + L1_e23 * (-L2_e03) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23))));
		float macro_Motor_temp1_e03 = L1_1 * (-L2_e03) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))) + L1_e01 * (-L2_e13) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))) + L1_e02 * (-L2_e23) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))) + L1_e03 * L2_1 / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))) + (-(L1_e13 * (-L2_e01) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))))) + (-(L1_e23 * (-L2_e02) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23))))));
		float macro_Motor_temp1_e12 = L1_1 * (-L2_e12) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))) + L1_e12 * L2_1 / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))) + (-(L1_e13 * (-L2_e23) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))))) + L1_e23 * (-L2_e13) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23))));
		float macro_Motor_temp1_e13 = L1_1 * (-L2_e13) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))) + L1_e12 * (-L2_e23) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))) + L1_e13 * L2_1 / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))) + (-(L1_e23 * (-L2_e12) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23))))));
		float macro_Motor_temp1_e23 = L1_1 * (-L2_e23) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))) + (-(L1_e12 * (-L2_e13) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))))) + L1_e13 * (-L2_e12) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))) + L1_e23 * L2_1 / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23))));
		float macro_Motor_temp1_e0123 = L1_e01 * (-L2_e23) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))) + (-(L1_e02 * (-L2_e13) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))))) + L1_e03 * (-L2_e12) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))) + L1_e12 * (-L2_e03) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))) + (-(L1_e13 * (-L2_e02) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23)))))) + L1_e23 * (-L2_e01) / (L2_1 * L2_1 + (-(L2_e12 * (-L2_e12))) + (-(L2_e13 * (-L2_e13))) + (-(L2_e23 * (-L2_e23))));
		float macro_Motor_abstemp1_1 = MathF.Sqrt(MathF.Abs(macro_Motor_temp1_1 * macro_Motor_temp1_1 + (-(macro_Motor_temp1_e12 * (-macro_Motor_temp1_e12))) + (-(macro_Motor_temp1_e13 * (-macro_Motor_temp1_e13))) + (-(macro_Motor_temp1_e23 * (-macro_Motor_temp1_e23)))));
		float VB_1 = macro_Motor_temp1_1 * macro_Motor_abstemp1_1 / (macro_Motor_abstemp1_1 * macro_Motor_abstemp1_1);
		float VB_e01 = macro_Motor_temp1_e01 * macro_Motor_abstemp1_1 / (macro_Motor_abstemp1_1 * macro_Motor_abstemp1_1);
		float VB_e02 = macro_Motor_temp1_e02 * macro_Motor_abstemp1_1 / (macro_Motor_abstemp1_1 * macro_Motor_abstemp1_1);
		float VB_e03 = macro_Motor_temp1_e03 * macro_Motor_abstemp1_1 / (macro_Motor_abstemp1_1 * macro_Motor_abstemp1_1);
		float VB_e12 = macro_Motor_temp1_e12 * macro_Motor_abstemp1_1 / (macro_Motor_abstemp1_1 * macro_Motor_abstemp1_1);
		float VB_e13 = macro_Motor_temp1_e13 * macro_Motor_abstemp1_1 / (macro_Motor_abstemp1_1 * macro_Motor_abstemp1_1);
		float VB_e23 = macro_Motor_temp1_e23 * macro_Motor_abstemp1_1 / (macro_Motor_abstemp1_1 * macro_Motor_abstemp1_1);
		float VB_e0123 = macro_Motor_temp1_e0123 * macro_Motor_abstemp1_1 / (macro_Motor_abstemp1_1 * macro_Motor_abstemp1_1);
		float C3_e012 = (VB_1 * C2_e0 + (-(VB_e12 * C2_e012)) + (-(VB_e13 * C2_e013)) + (-(VB_e23 * C2_e023)) + (-VB_e0123)) * (-VB_e12) + (-((-VB_e23) * (-VB_e02))) + VB_e13 * (-VB_e01) + (-((-VB_e12) * VB_e0123)) + (VB_1 * C2_e012 + VB_e03 + VB_e12 * C2_e0 + (-(VB_e13 * C2_e023)) + VB_e23 * C2_e013) * VB_1 + (-((VB_1 * C2_e013 + (-VB_e02) + VB_e12 * C2_e023 + VB_e13 * C2_e0 + (-(VB_e23 * C2_e012))) * (-VB_e23))) + (VB_1 * C2_e023 + VB_e01 + (-(VB_e12 * C2_e013)) + VB_e13 * C2_e012 + VB_e23 * C2_e0) * (-VB_e13) + (-(VB_1 * (-VB_e03)));
		float C3_e013 = (VB_1 * C2_e0 + (-(VB_e12 * C2_e012)) + (-(VB_e13 * C2_e013)) + (-(VB_e23 * C2_e023)) + (-VB_e0123)) * (-VB_e13) + (-((-VB_e23) * (-VB_e03))) + VB_e13 * VB_e0123 + (-VB_e12) * (-VB_e01) + (VB_1 * C2_e012 + VB_e03 + VB_e12 * C2_e0 + (-(VB_e13 * C2_e023)) + VB_e23 * C2_e013) * (-VB_e23) + (VB_1 * C2_e013 + (-VB_e02) + VB_e12 * C2_e023 + VB_e13 * C2_e0 + (-(VB_e23 * C2_e012))) * VB_1 + (-((VB_1 * C2_e023 + VB_e01 + (-(VB_e12 * C2_e013)) + VB_e13 * C2_e012 + VB_e23 * C2_e0) * (-VB_e12))) + VB_1 * (-VB_e02);
		float C3_e023 = (VB_1 * C2_e0 + (-(VB_e12 * C2_e012)) + (-(VB_e13 * C2_e013)) + (-(VB_e23 * C2_e023)) + (-VB_e0123)) * (-VB_e23) + (-((-VB_e23) * VB_e0123)) + (-(VB_e13 * (-VB_e03))) + (-VB_e12) * (-VB_e02) + (-((VB_1 * C2_e012 + VB_e03 + VB_e12 * C2_e0 + (-(VB_e13 * C2_e023)) + VB_e23 * C2_e013) * (-VB_e13))) + (VB_1 * C2_e013 + (-VB_e02) + VB_e12 * C2_e023 + VB_e13 * C2_e0 + (-(VB_e23 * C2_e012))) * (-VB_e12) + (VB_1 * C2_e023 + VB_e01 + (-(VB_e12 * C2_e013)) + VB_e13 * C2_e012 + VB_e23 * C2_e0) * VB_1 + (-(VB_1 * (-VB_e01)));
		float C3_e123 = (-VB_e23) * (-VB_e23) + (-(VB_e13 * (-VB_e13))) + (-VB_e12) * (-VB_e12) + VB_1 * VB_1;
		float P1_e0 = L1_e03 * (-Ct_e012) + (-((-L1_e02) * Ct_e013)) + L1_e01 * (-Ct_e023);
		float P1_e1 = (-((-L1_e13) * (-Ct_e012) + (-(L1_e12 * Ct_e013)) + L1_e01 * 0.9999899889062499f));
		float P1_e2 = L1_e23 * (-Ct_e012) + (-(L1_e12 * (-Ct_e023))) + (-L1_e02) * 0.9999899889062499f;
		float P1_e3 = (-(L1_e23 * Ct_e013 + (-((-L1_e13) * (-Ct_e023))) + L1_e03 * 0.9999899889062499f));
		float P2_e0 = L1_e03 * (-C3_e012) + (-((-L1_e02) * C3_e013)) + L1_e01 * (-C3_e023);
		float P2_e1 = (-((-L1_e13) * (-C3_e012) + (-(L1_e12 * C3_e013)) + L1_e01 * C3_e123));
		float P2_e2 = L1_e23 * (-C3_e012) + (-(L1_e12 * (-C3_e023))) + (-L1_e02) * C3_e123;
		float P2_e3 = (-(L1_e23 * C3_e013 + (-((-L1_e13) * (-C3_e023))) + L1_e03 * C3_e123));
		float macro_Motor_temp2_1 = 1.0f + P1_e1 * P2_e1 / (P2_e1 * P2_e1 + P2_e2 * P2_e2 + P2_e3 * P2_e3) + P1_e2 * P2_e2 / (P2_e1 * P2_e1 + P2_e2 * P2_e2 + P2_e3 * P2_e3) + P1_e3 * P2_e3 / (P2_e1 * P2_e1 + P2_e2 * P2_e2 + P2_e3 * P2_e3);
		float macro_Motor_temp2_e01 = P1_e0 * P2_e1 / (P2_e1 * P2_e1 + P2_e2 * P2_e2 + P2_e3 * P2_e3) + (-(P1_e1 * P2_e0 / (P2_e1 * P2_e1 + P2_e2 * P2_e2 + P2_e3 * P2_e3)));
		float macro_Motor_temp2_e02 = P1_e0 * P2_e2 / (P2_e1 * P2_e1 + P2_e2 * P2_e2 + P2_e3 * P2_e3) + (-(P1_e2 * P2_e0 / (P2_e1 * P2_e1 + P2_e2 * P2_e2 + P2_e3 * P2_e3)));
		float macro_Motor_temp2_e03 = P1_e0 * P2_e3 / (P2_e1 * P2_e1 + P2_e2 * P2_e2 + P2_e3 * P2_e3) + (-(P1_e3 * P2_e0 / (P2_e1 * P2_e1 + P2_e2 * P2_e2 + P2_e3 * P2_e3)));
		float macro_Motor_temp2_e12 = P1_e1 * P2_e2 / (P2_e1 * P2_e1 + P2_e2 * P2_e2 + P2_e3 * P2_e3) + (-(P1_e2 * P2_e1 / (P2_e1 * P2_e1 + P2_e2 * P2_e2 + P2_e3 * P2_e3)));
		float macro_Motor_temp2_e13 = P1_e1 * P2_e3 / (P2_e1 * P2_e1 + P2_e2 * P2_e2 + P2_e3 * P2_e3) + (-(P1_e3 * P2_e1 / (P2_e1 * P2_e1 + P2_e2 * P2_e2 + P2_e3 * P2_e3)));
		float macro_Motor_temp2_e23 = P1_e2 * P2_e3 / (P2_e1 * P2_e1 + P2_e2 * P2_e2 + P2_e3 * P2_e3) + (-(P1_e3 * P2_e2 / (P2_e1 * P2_e1 + P2_e2 * P2_e2 + P2_e3 * P2_e3)));
		float macro_Motor_abstemp2_1 = MathF.Sqrt(MathF.Abs(macro_Motor_temp2_1 * macro_Motor_temp2_1 + (-(macro_Motor_temp2_e12 * (-macro_Motor_temp2_e12))) + (-(macro_Motor_temp2_e13 * (-macro_Motor_temp2_e13))) + (-(macro_Motor_temp2_e23 * (-macro_Motor_temp2_e23)))));
		float VC_1 = macro_Motor_temp2_1 * macro_Motor_abstemp2_1 / (macro_Motor_abstemp2_1 * macro_Motor_abstemp2_1);
		float VC_e01 = macro_Motor_temp2_e01 * macro_Motor_abstemp2_1 / (macro_Motor_abstemp2_1 * macro_Motor_abstemp2_1);
		float VC_e02 = macro_Motor_temp2_e02 * macro_Motor_abstemp2_1 / (macro_Motor_abstemp2_1 * macro_Motor_abstemp2_1);
		float VC_e03 = macro_Motor_temp2_e03 * macro_Motor_abstemp2_1 / (macro_Motor_abstemp2_1 * macro_Motor_abstemp2_1);
		float VC_e12 = macro_Motor_temp2_e12 * macro_Motor_abstemp2_1 / (macro_Motor_abstemp2_1 * macro_Motor_abstemp2_1);
		float VC_e13 = macro_Motor_temp2_e13 * macro_Motor_abstemp2_1 / (macro_Motor_abstemp2_1 * macro_Motor_abstemp2_1);
		float VC_e23 = macro_Motor_temp2_e23 * macro_Motor_abstemp2_1 / (macro_Motor_abstemp2_1 * macro_Motor_abstemp2_1);
		float V_1 = VC_1 * VB_1 + (-(VC_e12 * VB_e12)) + (-(VC_e13 * VB_e13)) + (-(VC_e23 * VB_e23));
		float V_e01 = (VC_1 * VB_1 + (-(VC_e12 * VB_e12)) + (-(VC_e13 * VB_e13)) + (-(VC_e23 * VB_e23))) * VA_e01 + VC_1 * VB_e01 + VC_e01 * VB_1 + (-(VC_e02 * VB_e12)) + (-(VC_e03 * VB_e13)) + VC_e12 * VB_e02 + VC_e13 * VB_e03 + (-(VC_e23 * VB_e0123)) + (VC_1 * VB_e12 + VC_e12 * VB_1 + (-(VC_e13 * VB_e23)) + VC_e23 * VB_e13) * VA_e02 + (VC_1 * VB_e13 + VC_e12 * VB_e23 + VC_e13 * VB_1 + (-(VC_e23 * VB_e12))) * VA_e03 + (-((VC_1 * VB_e23 + (-(VC_e12 * VB_e13)) + VC_e13 * VB_e12 + VC_e23 * VB_1) * VA_e0123));
		float V_e02 = (VC_1 * VB_1 + (-(VC_e12 * VB_e12)) + (-(VC_e13 * VB_e13)) + (-(VC_e23 * VB_e23))) * VA_e02 + VC_1 * VB_e02 + VC_e01 * VB_e12 + VC_e02 * VB_1 + (-(VC_e03 * VB_e23)) + (-(VC_e12 * VB_e01)) + VC_e13 * VB_e0123 + VC_e23 * VB_e03 + (-((VC_1 * VB_e12 + VC_e12 * VB_1 + (-(VC_e13 * VB_e23)) + VC_e23 * VB_e13) * VA_e01)) + (VC_1 * VB_e13 + VC_e12 * VB_e23 + VC_e13 * VB_1 + (-(VC_e23 * VB_e12))) * VA_e0123 + (VC_1 * VB_e23 + (-(VC_e12 * VB_e13)) + VC_e13 * VB_e12 + VC_e23 * VB_1) * VA_e03;
		float V_e03 = (VC_1 * VB_1 + (-(VC_e12 * VB_e12)) + (-(VC_e13 * VB_e13)) + (-(VC_e23 * VB_e23))) * VA_e03 + VC_1 * VB_e03 + VC_e01 * VB_e13 + VC_e02 * VB_e23 + VC_e03 * VB_1 + (-(VC_e12 * VB_e0123)) + (-(VC_e13 * VB_e01)) + (-(VC_e23 * VB_e02)) + (-((VC_1 * VB_e12 + VC_e12 * VB_1 + (-(VC_e13 * VB_e23)) + VC_e23 * VB_e13) * VA_e0123)) + (-((VC_1 * VB_e13 + VC_e12 * VB_e23 + VC_e13 * VB_1 + (-(VC_e23 * VB_e12))) * VA_e01)) + (-((VC_1 * VB_e23 + (-(VC_e12 * VB_e13)) + VC_e13 * VB_e12 + VC_e23 * VB_1) * VA_e02));
		float V_e12 = VC_1 * VB_e12 + VC_e12 * VB_1 + (-(VC_e13 * VB_e23)) + VC_e23 * VB_e13;
		float V_e13 = VC_1 * VB_e13 + VC_e12 * VB_e23 + VC_e13 * VB_1 + (-(VC_e23 * VB_e12));
		float V_e23 = VC_1 * VB_e23 + (-(VC_e12 * VB_e13)) + VC_e13 * VB_e12 + VC_e23 * VB_1;
		float V_e0123 = (VC_1 * VB_1 + (-(VC_e12 * VB_e12)) + (-(VC_e13 * VB_e13)) + (-(VC_e23 * VB_e23))) * VA_e0123 + (VC_1 * VB_e12 + VC_e12 * VB_1 + (-(VC_e13 * VB_e23)) + VC_e23 * VB_e13) * VA_e03 + (-((VC_1 * VB_e13 + VC_e12 * VB_e23 + VC_e13 * VB_1 + (-(VC_e23 * VB_e12))) * VA_e02)) + (VC_1 * VB_e23 + (-(VC_e12 * VB_e13)) + VC_e13 * VB_e12 + VC_e23 * VB_1) * VA_e01 + VC_1 * VB_e0123 + VC_e01 * VB_e23 + (-(VC_e02 * VB_e13)) + VC_e03 * VB_e12 + VC_e12 * VB_e03 + (-(VC_e13 * VB_e02)) + VC_e23 * VB_e01;
		float lerp_1 = 1.0f - t + V_1 * t;
		float lerp_e01 = V_e01 * t;
		float lerp_e02 = V_e02 * t;
		float lerp_e03 = V_e03 * t;
		float lerp_e12 = V_e12 * t;
		float lerp_e13 = V_e13 * t;
		float lerp_e23 = V_e23 * t;
		float lerp_e0123 = V_e0123 * t;
		float AI_e0 = ((-(lerp_e12 * A1_e012)) + (-(lerp_e13 * ay)) + (-(lerp_e23 * A1_e023)) + (-lerp_e0123)) * lerp_1 + (-((-lerp_e23) * (-lerp_e01))) + (-(lerp_e13 * (-lerp_e02))) + (-((-lerp_e12) * (-lerp_e03))) + (-((lerp_1 * A1_e012 + lerp_e03 + (-(lerp_e13 * A1_e023)) + lerp_e23 * ay) * (-lerp_e12))) + (-((lerp_1 * ay + (-lerp_e02) + lerp_e12 * A1_e023 + (-(lerp_e23 * A1_e012))) * (-lerp_e13))) + (-((lerp_1 * A1_e023 + lerp_e01 + (-(lerp_e12 * ay)) + lerp_e13 * A1_e012) * (-lerp_e23))) + lerp_1 * lerp_e0123;
		float AI_e1 = (-lerp_e23) * lerp_1 + (-(lerp_e13 * (-lerp_e12))) + (-((-lerp_e12) * (-lerp_e13))) + (-(lerp_1 * (-lerp_e23)));
		float AI_e2 = (-lerp_e23) * (-lerp_e12) + lerp_e13 * lerp_1 + (-((-lerp_e12) * (-lerp_e23))) + lerp_1 * (-lerp_e13);
		float AI_e3 = (-lerp_e23) * (-lerp_e13) + lerp_e13 * (-lerp_e23) + (-lerp_e12) * lerp_1 + (-(lerp_1 * (-lerp_e12)));
		float AI_e012 = ((-(lerp_e12 * A1_e012)) + (-(lerp_e13 * ay)) + (-(lerp_e23 * A1_e023)) + (-lerp_e0123)) * (-lerp_e12) + (-((-lerp_e23) * (-lerp_e02))) + lerp_e13 * (-lerp_e01) + (-((-lerp_e12) * lerp_e0123)) + (lerp_1 * A1_e012 + lerp_e03 + (-(lerp_e13 * A1_e023)) + lerp_e23 * ay) * lerp_1 + (-((lerp_1 * ay + (-lerp_e02) + lerp_e12 * A1_e023 + (-(lerp_e23 * A1_e012))) * (-lerp_e23))) + (lerp_1 * A1_e023 + lerp_e01 + (-(lerp_e12 * ay)) + lerp_e13 * A1_e012) * (-lerp_e13) + (-(lerp_1 * (-lerp_e03)));
		float AI_e013 = ((-(lerp_e12 * A1_e012)) + (-(lerp_e13 * ay)) + (-(lerp_e23 * A1_e023)) + (-lerp_e0123)) * (-lerp_e13) + (-((-lerp_e23) * (-lerp_e03))) + lerp_e13 * lerp_e0123 + (-lerp_e12) * (-lerp_e01) + (lerp_1 * A1_e012 + lerp_e03 + (-(lerp_e13 * A1_e023)) + lerp_e23 * ay) * (-lerp_e23) + (lerp_1 * ay + (-lerp_e02) + lerp_e12 * A1_e023 + (-(lerp_e23 * A1_e012))) * lerp_1 + (-((lerp_1 * A1_e023 + lerp_e01 + (-(lerp_e12 * ay)) + lerp_e13 * A1_e012) * (-lerp_e12))) + lerp_1 * (-lerp_e02);
		float AI_e023 = ((-(lerp_e12 * A1_e012)) + (-(lerp_e13 * ay)) + (-(lerp_e23 * A1_e023)) + (-lerp_e0123)) * (-lerp_e23) + (-((-lerp_e23) * lerp_e0123)) + (-(lerp_e13 * (-lerp_e03))) + (-lerp_e12) * (-lerp_e02) + (-((lerp_1 * A1_e012 + lerp_e03 + (-(lerp_e13 * A1_e023)) + lerp_e23 * ay) * (-lerp_e13))) + (lerp_1 * ay + (-lerp_e02) + lerp_e12 * A1_e023 + (-(lerp_e23 * A1_e012))) * (-lerp_e12) + (lerp_1 * A1_e023 + lerp_e01 + (-(lerp_e12 * ay)) + lerp_e13 * A1_e012) * lerp_1 + (-(lerp_1 * (-lerp_e01)));
		float AI_e123 = (-lerp_e23) * (-lerp_e23) + (-(lerp_e13 * (-lerp_e13))) + (-lerp_e12) * (-lerp_e12) + lerp_1 * lerp_1;
		float BI_e0 = ((-(lerp_e12 * B1_e012)) + (-(lerp_e13 * by)) + (-(lerp_e23 * B1_e023)) + (-lerp_e0123)) * lerp_1 + (-((-lerp_e23) * (-lerp_e01))) + (-(lerp_e13 * (-lerp_e02))) + (-((-lerp_e12) * (-lerp_e03))) + (-((lerp_1 * B1_e012 + lerp_e03 + (-(lerp_e13 * B1_e023)) + lerp_e23 * by) * (-lerp_e12))) + (-((lerp_1 * by + (-lerp_e02) + lerp_e12 * B1_e023 + (-(lerp_e23 * B1_e012))) * (-lerp_e13))) + (-((lerp_1 * B1_e023 + lerp_e01 + (-(lerp_e12 * by)) + lerp_e13 * B1_e012) * (-lerp_e23))) + lerp_1 * lerp_e0123;
		float BI_e1 = (-lerp_e23) * lerp_1 + (-(lerp_e13 * (-lerp_e12))) + (-((-lerp_e12) * (-lerp_e13))) + (-(lerp_1 * (-lerp_e23)));
		float BI_e2 = (-lerp_e23) * (-lerp_e12) + lerp_e13 * lerp_1 + (-((-lerp_e12) * (-lerp_e23))) + lerp_1 * (-lerp_e13);
		float BI_e3 = (-lerp_e23) * (-lerp_e13) + lerp_e13 * (-lerp_e23) + (-lerp_e12) * lerp_1 + (-(lerp_1 * (-lerp_e12)));
		float BI_e012 = ((-(lerp_e12 * B1_e012)) + (-(lerp_e13 * by)) + (-(lerp_e23 * B1_e023)) + (-lerp_e0123)) * (-lerp_e12) + (-((-lerp_e23) * (-lerp_e02))) + lerp_e13 * (-lerp_e01) + (-((-lerp_e12) * lerp_e0123)) + (lerp_1 * B1_e012 + lerp_e03 + (-(lerp_e13 * B1_e023)) + lerp_e23 * by) * lerp_1 + (-((lerp_1 * by + (-lerp_e02) + lerp_e12 * B1_e023 + (-(lerp_e23 * B1_e012))) * (-lerp_e23))) + (lerp_1 * B1_e023 + lerp_e01 + (-(lerp_e12 * by)) + lerp_e13 * B1_e012) * (-lerp_e13) + (-(lerp_1 * (-lerp_e03)));
		float BI_e013 = ((-(lerp_e12 * B1_e012)) + (-(lerp_e13 * by)) + (-(lerp_e23 * B1_e023)) + (-lerp_e0123)) * (-lerp_e13) + (-((-lerp_e23) * (-lerp_e03))) + lerp_e13 * lerp_e0123 + (-lerp_e12) * (-lerp_e01) + (lerp_1 * B1_e012 + lerp_e03 + (-(lerp_e13 * B1_e023)) + lerp_e23 * by) * (-lerp_e23) + (lerp_1 * by + (-lerp_e02) + lerp_e12 * B1_e023 + (-(lerp_e23 * B1_e012))) * lerp_1 + (-((lerp_1 * B1_e023 + lerp_e01 + (-(lerp_e12 * by)) + lerp_e13 * B1_e012) * (-lerp_e12))) + lerp_1 * (-lerp_e02);
		float BI_e023 = ((-(lerp_e12 * B1_e012)) + (-(lerp_e13 * by)) + (-(lerp_e23 * B1_e023)) + (-lerp_e0123)) * (-lerp_e23) + (-((-lerp_e23) * lerp_e0123)) + (-(lerp_e13 * (-lerp_e03))) + (-lerp_e12) * (-lerp_e02) + (-((lerp_1 * B1_e012 + lerp_e03 + (-(lerp_e13 * B1_e023)) + lerp_e23 * by) * (-lerp_e13))) + (lerp_1 * by + (-lerp_e02) + lerp_e12 * B1_e023 + (-(lerp_e23 * B1_e012))) * (-lerp_e12) + (lerp_1 * B1_e023 + lerp_e01 + (-(lerp_e12 * by)) + lerp_e13 * B1_e012) * lerp_1 + (-(lerp_1 * (-lerp_e01)));
		float BI_e123 = (-lerp_e23) * (-lerp_e23) + (-(lerp_e13 * (-lerp_e13))) + (-lerp_e12) * (-lerp_e12) + lerp_1 * lerp_1;
		float CI_e0 = ((-(lerp_e12 * C1_e012)) + (-(lerp_e13 * cy)) + (-(lerp_e23 * C1_e023)) + (-lerp_e0123)) * lerp_1 + (-((-lerp_e23) * (-lerp_e01))) + (-(lerp_e13 * (-lerp_e02))) + (-((-lerp_e12) * (-lerp_e03))) + (-((lerp_1 * C1_e012 + lerp_e03 + (-(lerp_e13 * C1_e023)) + lerp_e23 * cy) * (-lerp_e12))) + (-((lerp_1 * cy + (-lerp_e02) + lerp_e12 * C1_e023 + (-(lerp_e23 * C1_e012))) * (-lerp_e13))) + (-((lerp_1 * C1_e023 + lerp_e01 + (-(lerp_e12 * cy)) + lerp_e13 * C1_e012) * (-lerp_e23))) + lerp_1 * lerp_e0123;
		float CI_e1 = (-lerp_e23) * lerp_1 + (-(lerp_e13 * (-lerp_e12))) + (-((-lerp_e12) * (-lerp_e13))) + (-(lerp_1 * (-lerp_e23)));
		float CI_e2 = (-lerp_e23) * (-lerp_e12) + lerp_e13 * lerp_1 + (-((-lerp_e12) * (-lerp_e23))) + lerp_1 * (-lerp_e13);
		float CI_e3 = (-lerp_e23) * (-lerp_e13) + lerp_e13 * (-lerp_e23) + (-lerp_e12) * lerp_1 + (-(lerp_1 * (-lerp_e12)));
		float CI_e012 = ((-(lerp_e12 * C1_e012)) + (-(lerp_e13 * cy)) + (-(lerp_e23 * C1_e023)) + (-lerp_e0123)) * (-lerp_e12) + (-((-lerp_e23) * (-lerp_e02))) + lerp_e13 * (-lerp_e01) + (-((-lerp_e12) * lerp_e0123)) + (lerp_1 * C1_e012 + lerp_e03 + (-(lerp_e13 * C1_e023)) + lerp_e23 * cy) * lerp_1 + (-((lerp_1 * cy + (-lerp_e02) + lerp_e12 * C1_e023 + (-(lerp_e23 * C1_e012))) * (-lerp_e23))) + (lerp_1 * C1_e023 + lerp_e01 + (-(lerp_e12 * cy)) + lerp_e13 * C1_e012) * (-lerp_e13) + (-(lerp_1 * (-lerp_e03)));
		float CI_e013 = ((-(lerp_e12 * C1_e012)) + (-(lerp_e13 * cy)) + (-(lerp_e23 * C1_e023)) + (-lerp_e0123)) * (-lerp_e13) + (-((-lerp_e23) * (-lerp_e03))) + lerp_e13 * lerp_e0123 + (-lerp_e12) * (-lerp_e01) + (lerp_1 * C1_e012 + lerp_e03 + (-(lerp_e13 * C1_e023)) + lerp_e23 * cy) * (-lerp_e23) + (lerp_1 * cy + (-lerp_e02) + lerp_e12 * C1_e023 + (-(lerp_e23 * C1_e012))) * lerp_1 + (-((lerp_1 * C1_e023 + lerp_e01 + (-(lerp_e12 * cy)) + lerp_e13 * C1_e012) * (-lerp_e12))) + lerp_1 * (-lerp_e02);
		float CI_e023 = ((-(lerp_e12 * C1_e012)) + (-(lerp_e13 * cy)) + (-(lerp_e23 * C1_e023)) + (-lerp_e0123)) * (-lerp_e23) + (-((-lerp_e23) * lerp_e0123)) + (-(lerp_e13 * (-lerp_e03))) + (-lerp_e12) * (-lerp_e02) + (-((lerp_1 * C1_e012 + lerp_e03 + (-(lerp_e13 * C1_e023)) + lerp_e23 * cy) * (-lerp_e13))) + (lerp_1 * cy + (-lerp_e02) + lerp_e12 * C1_e023 + (-(lerp_e23 * C1_e012))) * (-lerp_e12) + (lerp_1 * C1_e023 + lerp_e01 + (-(lerp_e12 * cy)) + lerp_e13 * C1_e012) * lerp_1 + (-(lerp_1 * (-lerp_e01)));
		float CI_e123 = (-lerp_e23) * (-lerp_e23) + (-(lerp_e13 * (-lerp_e13))) + (-lerp_e12) * (-lerp_e12) + lerp_1 * lerp_1;

		// GD.Print("Tuples: AI e012 = " + AI_e012);

		// GD.Print("Tuples : ", AI_e123, AI_e2, AI_e3, AI_e0, AI_e1, AI_e023, AI_e012, AI_e013);

		return (
			AI_e123, AI_e2, AI_e3, AI_e0, AI_e1, AI_e023, AI_e012, AI_e013,
			At_e0, At_e023, At_e123, At_e012, At_e013,
			BI_e012, BI_e013, BI_e1, BI_e2, BI_e3, BI_e0, BI_e023, BI_e123,
			Bt_e023, Bt_e0, Bt_e013, Bt_e012, Bt_e123,
			CI_e023, CI_e2, CI_e3, CI_e0, CI_e1, CI_e012, CI_e013, CI_e123,
			Ct_e123, Ct_e013, Ct_e012, Ct_e0, Ct_e023
		);
	}
}
