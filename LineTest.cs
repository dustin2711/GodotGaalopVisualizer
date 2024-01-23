using System;

public static class LineTest
{
	public static Godot.Vector2 Execute()
	{
		float line_e1 = 1.0f;
		float line_e2 = 1.0f;
		
		// Normalizing outputs:
		
		float line_magnitude = MathF.Sqrt(line_e2 * line_e2 + line_e1 * line_e1);
		line_e2 = line_e2 / line_magnitude;
		line_e1 = line_e1 / line_magnitude;
		
		return new Godot.Vector2(line_e1, line_e2);
	}
}
