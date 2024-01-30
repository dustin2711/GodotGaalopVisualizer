using Godot;
using System;

public partial class TriangleInterpolationManager : Node3D
{
	Triangle3D topTriangle;
	Triangle3D movingTriangle;
	Triangle3D bottomTriangle;

	float time;

	// Start position
	Vector3 A = new(0.8f, -0.1f, 0);
	Vector3 B = new(0, 0.33f, 0.1f);
	Vector3 C = new(0, 0.1f, 1);

	public override void _Ready()
	{
		topTriangle = GetNode("TopTriangle") as Triangle3D;
		movingTriangle = GetNode("MovingTriangle") as Triangle3D;
		bottomTriangle = GetNode("BottomTriangle") as Triangle3D;

		bottomTriangle.Set(A, B, C);
	}

	public override void _Process(double delta)
	{
		time += (float)delta;

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
		topTriangle.Set(new Vector3(At_e012, At_e013, At_e023), new Vector3(Bt_e012, Bt_e013, Bt_e023), new Vector3(Ct_e012, Ct_e013, Ct_e023));
		movingTriangle.Set(new Vector3(AI_e012, AI_e013, AI_e023), new Vector3(BI_e012, BI_e013, BI_e023), new Vector3(CI_e012, CI_e013, CI_e023));

		(Vector3 AI, Vector3 At, Vector3 BI, Vector3 Bt, Vector3 CI, Vector3 Ct) = TriangleInterpolationVector3.Execute(
		   A.X, A.Y, A.Z,
		   B.X, B.Y, B.Z,
		   C.X, C.Y, C.Z,
		   Mathf.Sin(time));
		// topTriangle.Set(At, Bt, Ct);
		// movingTriangle.Set(AI, BI, CI);

	}
}
