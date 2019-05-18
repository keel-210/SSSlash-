using System.Collections.Generic;
using UnityEngine;

// MeshCutの結果を管理するクラス
public class MeshCutResult
{
	public List<Vector3> vertices = new List<Vector3>();
	public List<int> indices = new List<int>();
	public List<Vector2> uv = new List<Vector2>();

	public void Clear()
	{
		vertices.Clear();
		uv.Clear();
		indices.Clear();
	}

	public void AddTriangle(
		float x1, float y1,
		float x2, float y2,
		float x3, float y3,
		float uv1X, float uv1Y,
		float uv2X, float uv2Y,
		float uv3X, float uv3Y
	)
	{
		int vertexCount = vertices.Count;
		vertices.Add(new Vector3(x1, y1, 0));
		vertices.Add(new Vector3(x2, y2, 0));
		vertices.Add(new Vector3(x3, y3, 0));
		uv.Add(new Vector2(uv1X, uv1Y));
		uv.Add(new Vector2(uv2X, uv2Y));
		uv.Add(new Vector2(uv3X, uv3Y));
		indices.Add(vertexCount + 0);
		indices.Add(vertexCount + 1);
		indices.Add(vertexCount + 2);
	}

	public void AddRectangle(
		float x1, float y1,
		float x2, float y2,
		float x3, float y3,
		float x4, float y4,
		float uv1_X, float uv1_Y,
		float uv2_X, float uv2_Y,
		float uv3_X, float uv3_Y,
		float uv4_X, float uv4_Y
	)
	{
		int vertexCount = vertices.Count;
		vertices.Add(new Vector3(x1, y1, 0));
		vertices.Add(new Vector3(x2, y2, 0));
		vertices.Add(new Vector3(x3, y3, 0));
		vertices.Add(new Vector3(x4, y4, 0));
		uv.Add(new Vector2(uv1_X, uv1_Y));
		uv.Add(new Vector2(uv2_X, uv2_Y));
		uv.Add(new Vector2(uv3_X, uv3_Y));
		uv.Add(new Vector2(uv4_X, uv4_Y));
		indices.Add(vertexCount + 0);
		indices.Add(vertexCount + 1);
		indices.Add(vertexCount + 2);
		indices.Add(vertexCount + 0);
		indices.Add(vertexCount + 2);
		indices.Add(vertexCount + 3);
	}
}