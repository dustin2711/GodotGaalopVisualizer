using Godot;

public static class FloatArrayExtensions
{
	public static Vector2 ToVector2(this double[] array)
	{
		return new Vector2((float)(-array[5] / array[6]), (float)(1f * array[4] / array[6]));
	}

	public static Vector2 ToVector2(this float[] array)
	{
		return new Vector2(1f * -array[5] / array[6], 1f * array[4] / array[6]);
	}
}
