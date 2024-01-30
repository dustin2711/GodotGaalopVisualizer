using System.Collections.Generic;
using System.Linq;
using Godot;
using Godot.Collections;

public partial class Triangle3D : MeshInstance3D
{
	ArrayMesh ArrayMesh => Mesh as ArrayMesh;

	public override void _Ready()
	{
		Set(
			new Vector3(0, 0, 0),
			new Vector3(0, 0, 1.5f),
			new Vector3(0.5f, 0, 0)
			);
	}

	public void Set(Vector3 a, Vector3 b, Vector3 c)
	{
		ArrayMesh.ClearSurfaces();

		var surfaceArray = new Array();
		surfaceArray.Resize((int)Mesh.ArrayType.Max);

		var verts = new List<Vector3>() { a, b, c };

		var uvs = verts.Select(vert => new Vector2(vert.X, vert.Z)).ToArray();
		//  new List<Vector2>() { new Vector2(0, 0), new Vector2(0, 1.5f), new Vector2(0.5f, 0), };

		var delta1 = verts[1] - verts[0];
		var delta2 = verts[2] - verts[1];

		var normal = delta1.Cross(delta2);

		// var normals = new List<Vector3>() { new Vector3(0, 1, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 0) };
		var normals = verts.Select(_ => normal).ToArray();
		var indices = new List<int>() { 2, 1, 0, 0, 1, 2 };

		surfaceArray[(int)Mesh.ArrayType.Vertex] = verts.ToArray();
		surfaceArray[(int)Mesh.ArrayType.TexUV] = uvs.ToArray();
		surfaceArray[(int)Mesh.ArrayType.Normal] = normals.ToArray();
		surfaceArray[(int)Mesh.ArrayType.Index] = indices.ToArray();

		ArrayMesh.AddSurfaceFromArrays(Mesh.PrimitiveType.Triangles, surfaceArray);
	}
}