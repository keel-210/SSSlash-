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
		Vector3 v1 = new Vector3(x1, y1, 0);
		Vector3 v2 = new Vector3(x2, y2, 0);
		Vector3 v3 = new Vector3(x3, y3, 0);
		int i1 = vertices.IndexOf(v1);
		int i2 = vertices.IndexOf(v2);
		int i3 = vertices.IndexOf(v3);
		if (i1 == -1)
		{
			vertices.Add(new Vector3(x1, y1, 0));
			uv.Add(new Vector2(uv1X, uv1Y));
		}
		if (i2 == -1)
		{
			vertices.Add(new Vector3(x2, y2, 0));
			uv.Add(new Vector2(uv2X, uv2Y));
		}
		if (i3 == -1)
		{
			vertices.Add(new Vector3(x3, y3, 0));
			uv.Add(new Vector2(uv3X, uv3Y));
		}
		indices.Add(vertices.IndexOf(v1));
		indices.Add(vertices.IndexOf(v2));
		indices.Add(vertices.IndexOf(v3));
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
		Vector3 v1 = new Vector3(x1, y1, 0);
		Vector3 v2 = new Vector3(x2, y2, 0);
		Vector3 v3 = new Vector3(x3, y3, 0);
		Vector3 v4 = new Vector3(x4, y4, 0);
		int i1 = vertices.IndexOf(v1);
		int i2 = vertices.IndexOf(v2);
		int i3 = vertices.IndexOf(v3);
		int i4 = vertices.IndexOf(v4);
		if (i1 == -1)
		{
			vertices.Add(new Vector3(x1, y1, 0));
			uv.Add(new Vector2(uv1_X, uv1_Y));
		}
		if (i2 == -1)
		{
			vertices.Add(new Vector3(x2, y2, 0));
			uv.Add(new Vector2(uv2_X, uv2_Y));
		}
		if (i3 == -1)
		{
			vertices.Add(new Vector3(x3, y3, 0));
			uv.Add(new Vector2(uv3_X, uv3_Y));
		}
		if (i4 == -1)
		{
			vertices.Add(new Vector3(x4, y4, 0));
			uv.Add(new Vector2(uv4_X, uv4_Y));
		}
		i1 = vertices.IndexOf(v1);
		i2 = vertices.IndexOf(v2);
		i3 = vertices.IndexOf(v3);
		i4 = vertices.IndexOf(v4);
		indices.Add(i1);
		indices.Add(i2);
		indices.Add(i3);
		indices.Add(i1);
		indices.Add(i3);
		indices.Add(i4);
	}
}