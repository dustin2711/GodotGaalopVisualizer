using System.Collections.Generic;
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


	public static IEnumerable<(T, T)> IterateWithNext<T>(this IList<T> items)
	{
		for (int index = 0; index < items.Count - 1; index++)
		{
			yield return (items[index], items[index + 1]);
		}
	}

	public static IEnumerable<(T, T, T)> IterateWithNexts<T>(this IList<T> items)
	{
		for (int index = 0; index < items.Count - 2; index++)
		{
			yield return (items[index], items[index + 1], items[index + 2]);
		}
	}
}