public static class FourSpheresCenterArrays
{
	public static void Execute(float P1i, float P1x, float P1y, float P1z, float P2i, float P2x, float P2y, float P2z, float P3i, float P3x, float P3y, float P3z, float P4i, float P4x, float P4y, float P4z, float[] C)
	{
		float[] S = new float[32];
		S[27] = (P1x * P2y + (-(P1y * P2x))) * P3z + (-((P1x * P2z + (-(P1z * P2x))) * P3y)) + (P1y * P2z + (-(P1z * P2y))) * P3x + (-((P1x * P2y + (-(P1y * P2x)) + (-((P1x + (-P2x)) * P3y)) + (P1y + (-P2y)) * P3x) * P4z)) + (P1x * P2z + (-(P1z * P2x)) + (-((P1x + (-P2x)) * P3z)) + (P1z + (-P2z)) * P3x) * P4y + (-((P1y * P2z + (-(P1z * P2y)) + (-((P1y + (-P2y)) * P3z)) + (P1z + (-P2z)) * P3y) * P4x));
		S[28] = (P1x * P2y + (-(P1y * P2x))) * P3i + (-((P1x * P2i + (-(P1i * P2x))) * P3y)) + (P1y * P2i + (-(P1i * P2y))) * P3x + (-((P1x * P2y + (-(P1y * P2x)) + (-((P1x + (-P2x)) * P3y)) + (P1y + (-P2y)) * P3x) * P4i)) + (P1x * P2i + (-(P1i * P2x)) + (-((P1x + (-P2x)) * P3i)) + (P1i + (-P2i)) * P3x) * P4y + (-((P1y * P2i + (-(P1i * P2y)) + (-((P1y + (-P2y)) * P3i)) + (P1i + (-P2i)) * P3y) * P4x));
		S[29] = (P1x * P2z + (-(P1z * P2x))) * P3i + (-((P1x * P2i + (-(P1i * P2x))) * P3z)) + (P1z * P2i + (-(P1i * P2z))) * P3x + (-((P1x * P2z + (-(P1z * P2x)) + (-((P1x + (-P2x)) * P3z)) + (P1z + (-P2z)) * P3x) * P4i)) + (P1x * P2i + (-(P1i * P2x)) + (-((P1x + (-P2x)) * P3i)) + (P1i + (-P2i)) * P3x) * P4z + (-((P1z * P2i + (-(P1i * P2z)) + (-((P1z + (-P2z)) * P3i)) + (P1i + (-P2i)) * P3z) * P4x));
		S[30] = (P1y * P2z + (-(P1z * P2y))) * P3i + (-((P1y * P2i + (-(P1i * P2y))) * P3z)) + (P1z * P2i + (-(P1i * P2z))) * P3y + (-((P1y * P2z + (-(P1z * P2y)) + (-((P1y + (-P2y)) * P3z)) + (P1z + (-P2z)) * P3y) * P4i)) + (P1y * P2i + (-(P1i * P2y)) + (-((P1y + (-P2y)) * P3i)) + (P1i + (-P2i)) * P3y) * P4z + (-((P1z * P2i + (-(P1i * P2z)) + (-((P1z + (-P2z)) * P3i)) + (P1i + (-P2i)) * P3z) * P4y));
		C[1] = (-S[27]) * S[30] / (-((-S[27]) * S[27]));
		C[2] = (-((-S[27]) * S[29] / (-((-S[27]) * S[27]))));
		C[3] = (-S[27]) * S[28] / (-((-S[27]) * S[27]));
	}
}
