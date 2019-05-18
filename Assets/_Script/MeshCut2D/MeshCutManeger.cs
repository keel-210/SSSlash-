using System.Linq;
using UnityEngine;

public class MeshCutManeger : MonoBehaviour
{
	public MeshCut2D cutter = new MeshCut2D();
	MeshCutResult a = new MeshCutResult(), b = new MeshCutResult();
	void Start()
	{

	}
	public void Cut(MeshCollider col, MeshFilter filter, Vector2 p0, Vector2 p1)
	{
		Mesh mesh = DuplicateMesh(col.sharedMesh);
		MeshCut2D.Cut(mesh.vertices, mesh.colors32, mesh.uv, mesh.triangles, mesh.vertexCount, p0.x, p0.y, p1.x, p1.y, a, b);
		ApplyPolygonColloderAndMeshFilter(col, filter, a);
		MakeNewMeshGameObject(b, col.transform, col.GetComponent<MeshRenderer>().material);
	}
	void Return()
	{

	}
	GameObject MakeNewMeshGameObject(MeshCutResult res, Transform tra, Material mat)
	{
		GameObject obj = new GameObject();
		MeshFilter f = obj.AddComponent<MeshFilter>();
		MeshRenderer r = obj.AddComponent<MeshRenderer>();
		MeshCollider c = obj.AddComponent<MeshCollider>();
		ApplyPolygonColloderAndMeshFilter(c, f, res);
		ApplyTransform(obj.transform, tra);
		r.material = mat;
		return obj;
	}
	void ApplyTransform(Transform obj, Transform tra)
	{
		obj.position = tra.position;
		obj.rotation = tra.rotation;
		obj.localScale = tra.localScale;
	}
	Mesh DuplicateMesh(Mesh mesh)
	{
		Mesh m = new Mesh();
		m.vertices = mesh.vertices;
		m.triangles = mesh.triangles;
		m.uv = mesh.uv;
		m.normals = mesh.normals;
		return m;
	}
	void ApplyPolygonColloderAndMeshFilter(MeshCollider col, MeshFilter filter, MeshCutResult res)
	{
		Mesh mesh = new Mesh();
		mesh.vertices = res.vertices.ToArray();
		mesh.uv = res.uv.ToArray();
		mesh.triangles = res.indices.ToArray();
		col.sharedMesh = mesh;
		filter.mesh = mesh;
	}
}