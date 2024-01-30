public static class CenterOf4PointsSphereTuples
{
	public static (float C_e3, float C_e2, float C_e1) Execute(float P1i, float P1x, float P1y, float P1z, float P2i, float P2x, float P2y, float P2z, float P3i, float P3x, float P3y, float P3z, float P4i, float P4x, float P4y, float P4z)
	{
		float S_e1230 = (P1x * P2y + (-(P1y * P2x))) * P3z + (-((P1x * P2z + (-(P1z * P2x))) * P3y)) + (P1y * P2z + (-(P1z * P2y))) * P3x + (-((P1x * P2y + (-(P1y * P2x)) + (-((P1x + (-P2x)) * P3y)) + (P1y + (-P2y)) * P3x) * P4z)) + (P1x * P2z + (-(P1z * P2x)) + (-((P1x + (-P2x)) * P3z)) + (P1z + (-P2z)) * P3x) * P4y + (-((P1y * P2z + (-(P1z * P2y)) + (-((P1y + (-P2y)) * P3z)) + (P1z + (-P2z)) * P3y) * P4x));
		float S_e12inf0 = (P1x * P2y + (-(P1y * P2x))) * P3i + (-((P1x * P2i + (-(P1i * P2x))) * P3y)) + (P1y * P2i + (-(P1i * P2y))) * P3x + (-((P1x * P2y + (-(P1y * P2x)) + (-((P1x + (-P2x)) * P3y)) + (P1y + (-P2y)) * P3x) * P4i)) + (P1x * P2i + (-(P1i * P2x)) + (-((P1x + (-P2x)) * P3i)) + (P1i + (-P2i)) * P3x) * P4y + (-((P1y * P2i + (-(P1i * P2y)) + (-((P1y + (-P2y)) * P3i)) + (P1i + (-P2i)) * P3y) * P4x));
		float S_e13inf0 = (P1x * P2z + (-(P1z * P2x))) * P3i + (-((P1x * P2i + (-(P1i * P2x))) * P3z)) + (P1z * P2i + (-(P1i * P2z))) * P3x + (-((P1x * P2z + (-(P1z * P2x)) + (-((P1x + (-P2x)) * P3z)) + (P1z + (-P2z)) * P3x) * P4i)) + (P1x * P2i + (-(P1i * P2x)) + (-((P1x + (-P2x)) * P3i)) + (P1i + (-P2i)) * P3x) * P4z + (-((P1z * P2i + (-(P1i * P2z)) + (-((P1z + (-P2z)) * P3i)) + (P1i + (-P2i)) * P3z) * P4x));
		float S_e23inf0 = (P1y * P2z + (-(P1z * P2y))) * P3i + (-((P1y * P2i + (-(P1i * P2y))) * P3z)) + (P1z * P2i + (-(P1i * P2z))) * P3y + (-((P1y * P2z + (-(P1z * P2y)) + (-((P1y + (-P2y)) * P3z)) + (P1z + (-P2z)) * P3y) * P4i)) + (P1y * P2i + (-(P1i * P2y)) + (-((P1y + (-P2y)) * P3i)) + (P1i + (-P2i)) * P3y) * P4z + (-((P1z * P2i + (-(P1i * P2z)) + (-((P1z + (-P2z)) * P3i)) + (P1i + (-P2i)) * P3z) * P4y));
		float C_e1 = (-S_e1230) * S_e23inf0 / (-((-S_e1230) * S_e1230));
		float C_e2 = (-((-S_e1230) * S_e13inf0 / (-((-S_e1230) * S_e1230))));
		float C_e3 = (-S_e1230) * S_e12inf0 / (-((-S_e1230) * S_e1230));


		return (C_e3, C_e2, C_e1);
	}
}
