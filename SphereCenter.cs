using Godot;
using System;
using System.Diagnostics;

public partial class SphereCenter : Node
{
	public override void _Ready()
	{
		// The classic array method
		float[] center = new float[4];
		FourSpheresCenterArrays.Execute(
			1, 3, 7, 2,
			2, 1, 3, 2,
			3, 2, 1, 3,
			4, 1, 2, 5, center);
		Vector3 centerArray = new(center[1], center[2], center[3]);

		// Returning tuples
		(float C_e3, float C_e2, float C_e1) = FourSpheresCenterTuples.Execute(
			1, 3, 7, 2,
			2, 1, 3, 2,
			3, 2, 1, 3,
			4, 1, 2, 5);
		Vector3 centerTuples = new(C_e1, C_e2, C_e3);

		// Returning a Vector3
		Vector3 centerVector3 = FourSpheresCenterVector3.Execute(
			1, 3, 7, 2,
			2, 1, 3, 2,
			3, 2, 1, 3,
			4, 1, 2, 5);

		Debug.Assert(centerArray == centerTuples);
		Debug.Assert(centerArray == centerVector3);
	}

	public override void _Process(double delta)
	{
	}
}
