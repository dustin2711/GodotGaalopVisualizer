public static class TwoPlanesIntersect
{
	public static void Execute(float[] line)
	{
		line[5] = -6.0f; // e0 ^ e1
		line[6] = 6.0f; // e0 ^ e2
		line[8] = 4.0f; // e1 ^ e2
	}
}
