using System;

using Godot;
public static class LinePolygonCse
{
	public static (Vector2, Vector2, Vector2, Vector2) Execute(float ax, float ay, float bx, float by, float cx, float cy, float halfWidth)
	{
		float a_e02 = (-ax);
		float b_e02 = (-bx);
		float c_e02 = (-cx);
		float temp_gcse_5 = (-b_e02);
		float firstLine__e0 = (-a_e02) * by + (-(ay * temp_gcse_5));
		float firstLine__e1 = (-(by + (-ay)));
		float firstLine__e2 = temp_gcse_5 + a_e02;
		float temp_gcse_9 = (firstLine__e1 * firstLine__e1 + firstLine__e2 * firstLine__e2) * (firstLine__e1 * firstLine__e1 + firstLine__e2 * firstLine__e2);
		float temp_gcse_16 = MathF.Sqrt(MathF.Abs(firstLine__e1 * firstLine__e1 + firstLine__e2 * firstLine__e2)) / MathF.Sqrt(MathF.Abs(temp_gcse_9));
		float temp_gcse_18 = MathF.Sqrt(MathF.Abs(firstLine__e1 * firstLine__e1 + firstLine__e2 * firstLine__e2));
		float temp_gcse_28 = firstLine__e1 * firstLine__e1 + firstLine__e2 * firstLine__e2;
		float temp_gcse_31 = firstLine__e1 * firstLine__e1;
		float temp_gcse_32 = MathF.Sqrt(MathF.Abs(temp_gcse_9));
		float temp_gcse_39 = MathF.Abs(firstLine__e1 * firstLine__e1 + firstLine__e2 * firstLine__e2);
		float temp_gcse_41 = MathF.Abs(temp_gcse_9);
		float temp_gcse_44 = firstLine__e2 * firstLine__e2;
		float firstLine_e0 = firstLine__e0 * temp_gcse_16;
		float firstLine_e1 = firstLine__e1 * temp_gcse_16;
		float firstLine_e2 = firstLine__e2 * temp_gcse_16;
		float firstLineLeft_e0 = firstLine_e0 - halfWidth;
		float firstLineRight_e0 = firstLine_e0 + halfWidth;
		float temp_gcse_38 = (-c_e02);
		float secondLine__e0 = temp_gcse_5 * cy + (-(by * temp_gcse_38));
		float secondLine__e1 = (-(cy + (-by)));
		float secondLine__e2 = temp_gcse_38 + b_e02;
		float temp_gcse_2 = MathF.Abs(secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2);
		float temp_gcse_7 = MathF.Sqrt(temp_gcse_2) / MathF.Sqrt(MathF.Abs((secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2) * (secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2)));
		float temp_gcse_13 = secondLine__e1 * secondLine__e1;
		float temp_gcse_17 = secondLine__e2 * secondLine__e2;
		float temp_gcse_26 = MathF.Sqrt(MathF.Abs((secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2) * (secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2)));
		float temp_gcse_33 = secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2;
		float temp_gcse_34 = MathF.Abs((secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2) * (secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2));
		float temp_gcse_37 = (secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2) * (secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2);
		float temp_gcse_55 = MathF.Sqrt(temp_gcse_2);
		float secondLine_e0 = secondLine__e0 * temp_gcse_7;
		float secondLine_e1 = secondLine__e1 * temp_gcse_7;
		float secondLine_e2 = secondLine__e2 * temp_gcse_7;
		float secondLineLeft_e0 = secondLine_e0 - halfWidth;
		float secondLineRight_e0 = secondLine_e0 + halfWidth;
		float quarterRotorAroundA_e01 = 0.7071067805519557f * ay;
		float quarterRotorAroundA_e02 = 0.7071067805519557f * a_e02;
		float temp_gcse_3 = 0.7071067805519557f * firstLine_e1;
		float temp_gcse_4 = 0.7071067818211393f * firstLine_e0;
		float temp_gcse_6 = quarterRotorAroundA_e02 * firstLine_e1;
		float temp_gcse_11 = 0.7071067805519557f * firstLine_e2;
		float temp_gcse_12 = 0.7071067818211393f * firstLine_e1;
		float temp_gcse_21 = 0.7071067818211393f * firstLine_e2 + (-temp_gcse_3);
		float temp_gcse_23 = (-temp_gcse_3);
		float temp_gcse_24 = (-temp_gcse_6);
		float temp_gcse_25 = quarterRotorAroundA_e01 * firstLine_e2 + temp_gcse_24;
		float temp_gcse_29 = 0.7071067805519557f * firstLine_e0;
		float temp_gcse_30 = quarterRotorAroundA_e01 * firstLine_e1;
		float temp_gcse_35 = quarterRotorAroundA_e01 * firstLine_e2;
		float temp_gcse_43 = (-quarterRotorAroundA_e02);
		float temp_gcse_45 = quarterRotorAroundA_e02 * firstLine_e2;
		float temp_gcse_46 = temp_gcse_4 + temp_gcse_30;
		float temp_gcse_47 = 0.7071067818211393f * firstLine_e2;
		float temp_gcse_49 = temp_gcse_12 + temp_gcse_11;
		float temp_gcse_52 = (-quarterRotorAroundA_e01);
		float temp_gcse_54 = temp_gcse_25 + temp_gcse_29;
		float temp_gcse_57 = temp_gcse_46 + temp_gcse_45;
		float verticalLineAtA_e0 = temp_gcse_57 * 0.7071067818211393f + (-(temp_gcse_49 * temp_gcse_52)) + (-(temp_gcse_21 * temp_gcse_43)) + (-(temp_gcse_54 * -0.7071067805519557f));
		float verticalLineAtA_e1 = temp_gcse_49 * 0.7071067818211393f + (-(temp_gcse_21 * -0.7071067805519557f));
		float verticalLineAtA_e2 = temp_gcse_49 * -0.7071067805519557f + temp_gcse_21 * 0.7071067818211393f;
		float verticalLineAtA_e012 = temp_gcse_57 * -0.7071067805519557f + (-(temp_gcse_49 * temp_gcse_43)) + temp_gcse_21 * temp_gcse_52 + temp_gcse_54 * 0.7071067818211393f;
		float temp_gcse_22 = firstLine_e2 * verticalLineAtA_e2;
		float firstPointLeft_1 = firstLine_e1 * verticalLineAtA_e1 + temp_gcse_22;
		float temp_gcse_36 = (-(firstLine_e1 * verticalLineAtA_e0));
		float temp_gcse_50 = firstLine_e2 * verticalLineAtA_e012;
		float temp_gcse_56 = firstLine_e1 * verticalLineAtA_e0;
		float firstPointLeft_e01 = firstLineLeft_e0 * verticalLineAtA_e1 + temp_gcse_36 + temp_gcse_50;
		float temp_gcse_8 = firstLine_e2 * verticalLineAtA_e0;
		float temp_gcse_15 = firstLine_e1 * verticalLineAtA_e012;
		float temp_gcse_20 = (-temp_gcse_8);
		float temp_gcse_53 = (-temp_gcse_15);
		float firstPointLeft_e02 = firstLineLeft_e0 * verticalLineAtA_e2 + temp_gcse_53 + temp_gcse_20;
		float temp_gcse_14 = firstLine_e2 * verticalLineAtA_e1;
		float temp_gcse_27 = (-temp_gcse_14);
		float firstPointLeft_e12 = firstLine_e1 * verticalLineAtA_e2 + temp_gcse_27;
		float firstPointRight_1 = firstPointLeft_1;
		float firstPointRight_e01 = firstLineRight_e0 * verticalLineAtA_e1 + temp_gcse_36 + temp_gcse_50;
		float firstPointRight_e02 = firstLineRight_e0 * verticalLineAtA_e2 + temp_gcse_53 + temp_gcse_20;
		float firstPointRight_e12 = firstPointLeft_e12;
		float temp_gcse_1 = firstLine_e1 * secondLine_e1;
		float secondPointLeft_1 = temp_gcse_1 + firstLine_e2 * secondLine_e2;
		float secondPointLeft_e01 = firstLineLeft_e0 * secondLine_e1 + (-(firstLine_e1 * secondLineLeft_e0));
		float secondPointLeft_e02 = firstLineLeft_e0 * secondLine_e2 + (-(firstLine_e2 * secondLineLeft_e0));
		float secondPointLeft_e12 = firstLine_e1 * secondLine_e2 + (-(firstLine_e2 * secondLine_e1));
		float secondPointRight_1 = secondPointLeft_1;
		float secondPointRight_e01 = firstLineRight_e0 * secondLine_e1 + (-(firstLine_e1 * secondLineRight_e0));
		float secondPointRight_e02 = firstLineRight_e0 * secondLine_e2 + (-(firstLine_e2 * secondLineRight_e0));
		float secondPointRight_e12 = secondPointLeft_e12;

		return (
			new Vector2(-firstPointLeft_e02 / firstPointLeft_e12, firstPointLeft_e01 / firstPointLeft_e12),
			new Vector2(-firstPointRight_e02 / firstPointRight_e12, firstPointRight_e01 / firstPointRight_e12),
			new Vector2(-secondPointLeft_e02 / secondPointLeft_e12, secondPointLeft_e01 / secondPointLeft_e12),
			new Vector2(-secondPointRight_e02 / secondPointRight_e12, secondPointRight_e01 / secondPointRight_e12)
		);
	}
}
