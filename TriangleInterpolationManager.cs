using Godot;
using System;

/// <summary>
///   Draws the interpolating triangle.
/// </summary>
public partial class TriangleInterpolationManager : Node3D
{
	Triangle3D topTriangle;
	Triangle3D movingTriangle;
	Triangle3D bottomTriangle;

	float time;

	// Start position of the triangle
	private static Vector3 A = new(0.8f, -0.1f, 0);
	private static Vector3 B = new(0, 0.33f, 0.1f);
	private static Vector3 C = new(0, 0.1f, 1);

	public override void _Ready()
	{
		topTriangle = GetNode("TopTriangle") as Triangle3D;
		movingTriangle = GetNode("MovingTriangle") as Triangle3D;
		bottomTriangle = GetNode("BottomTriangle") as Triangle3D;

		bottomTriangle.Set(A, B, C);
	}

	public static (Vector3, Vector3, Vector3) GetTriangleUsingArray(float time)
	{
		float[] arrayAI = new float[32];
		float[] arrayAt = new float[32];
		float[] arrayBI = new float[32];
		float[] arrayBt = new float[32];
		float[] arrayCI = new float[32];
		float[] arrayCt = new float[32];
		TriangleInterpolationArrays.Execute(
			A.X, A.Y, A.Z,
			B.X, B.Y, B.Z,
			C.X, C.Y, C.Z,
			Mathf.Sin(time),
			arrayAI, arrayAt, arrayBI, arrayBt, arrayCI, arrayCt
		);
		return (
			new Vector3(arrayAI[11], arrayAI[12], arrayAI[13]),
			new Vector3(arrayBI[11], arrayBI[12], arrayBI[13]),
			new Vector3(arrayCI[11], arrayCI[12], arrayCI[13]));
	}

	public static (Vector3, Vector3, Vector3) GetTriangleUsingTuple(float time)
	{
		(float AI_e123, float AI_e2, float AI_e3, float AI_e0, float AI_e1, float AI_e023, float AI_e012, float AI_e013,
		 float At_e0, float At_e023, float At_e123, float At_e012, float At_e013,
		 float BI_e012, float BI_e013, float BI_e1, float BI_e2, float BI_e3, float BI_e0, float BI_e023, float BI_e123,
		 float Bt_e023, float Bt_e0, float Bt_e013, float Bt_e012, float Bt_e123,
		 float CI_e023, float CI_e2, float CI_e3, float CI_e0, float CI_e1, float CI_e012, float CI_e013, float CI_e123,
		 float Ct_e123, float Ct_e013, float Ct_e012, float Ct_e0, float Ct_e023) = TriangleInterpolationTuples.Execute(
			A.X, A.Y, A.Z,
			B.X, B.Y, B.Z,
			C.X, C.Y, C.Z,
			Mathf.Sin(time));
		return (
			new Vector3(AI_e012, AI_e013, AI_e023),
			new Vector3(BI_e012, BI_e013, BI_e023),
			new Vector3(CI_e012, CI_e013, CI_e023));
		// return (
		// 	new Vector3(At_e012, At_e013, At_e023),
		// 	new Vector3(Bt_e012, Bt_e013, Bt_e023),
		// 	new Vector3(Ct_e012, Ct_e013, Ct_e023));
	}

	public static (Vector3, Vector3, Vector3) GetTriangleUsingVector3(float time)
	{
		// Return Vector3
		(Vector3 AI, Vector3 At, Vector3 BI, Vector3 Bt, Vector3 CI, Vector3 Ct) = TriangleInterpolationVector3.Execute(
		   A.X, A.Y, A.Z,
		   B.X, B.Y, B.Z,
		   C.X, C.Y, C.Z,
		   Mathf.Sin(time));
		return (AI, BI, CI);
	}

    public static (Vector3, Vector3, Vector3) GetTriangleUsingVector3Short(float time)
    {
        // Return Vector3
        (Vector3 AI, Vector3 At, Vector3 BI, Vector3 Bt, Vector3 CI, Vector3 Ct) = TriangleInterpolationVector3Short.Execute(
           A.X, A.Y, A.Z,
           B.X, B.Y, B.Z,
           C.X, C.Y, C.Z,
           Mathf.Sin(time));
        return (AI, BI, CI);
    }

    
	public override void _Process(double delta)
	{
		time += (float)delta;

		(Vector3 a, Vector3 b, Vector3 c) = (new(), new(), new());

		(a, b, c) = GetTriangleUsingArray(time);
		movingTriangle.Set(a, b, c);

		(a, b, c) = GetTriangleUsingTuple(time);
		movingTriangle.Set(a, b, c);

		(a, b, c) = GetTriangleUsingVector3(time);
		movingTriangle.Set(a, b, c);

		// Top and bottom triangle are nonetheless invisible for some reason
		// topTriangle.Set(At, Bt, Ct);
	}
}
