using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeshCutManeger : MonoBehaviour
{
	public MeshCut2D cutter = new MeshCut2D();
	MeshCutResult a = new MeshCutResult(), b = new MeshCutResult();
	List<List<CutRecord>> CutHistory = new List<List<CutRecord>>();
	public void CutAll(IList<MeshCollider> colliders, IList<MeshFilter> filters, Vector2 p0, Vector2 p1)
	{
		List<CutRecord> templist = new List<CutRecord>();
		for (int i = 0; i < colliders.Count; i++)
		{
			var r = Cut(colliders[i], filters[i], p0, p1);
			templist.Add(r);
		}
		CutHistory.Add(templist);
	}
	public CutRecord Cut(MeshCollider col, MeshFilter filter, Vector2 p0, Vector2 p1)
	{
		CutRecord rec = new CutRecord();
		rec.mesh = col.sharedMesh;
		rec.CutObj0 = col.gameObject;
		rec.tra = col.transform;
		rec.collider = col;
		rec.filter = filter;
		Mesh mesh = DuplicateMesh(col.sharedMesh);
		MeshCut2D.Cut(mesh.vertices, mesh.uv, mesh.triangles, mesh.triangles.Count(), p0.x, p0.y, p1.x, p1.y, a, b);
		ApplyPolygonColloderAndMeshFilter(col, filter, a);
		rec.CutObj1 = DuplicateMeshGameObject(col.gameObject, b, col.transform, col.GetComponent<MeshRenderer>().material);
		return rec;
	}
	public void Return()
	{
		foreach (CutRecord r in CutHistory[CutHistory.Count - 1])
		{
			Destroy(r.CutObj1);
			r.collider.sharedMesh = r.mesh;
			r.filter.mesh = r.mesh;
			ApplyTransform(r.CutObj0.transform, r.tra);
		}
		CutHistory.RemoveAt(CutHistory.Count - 1);
	}
	GameObject DuplicateMeshGameObject(GameObject original, MeshCutResult res, Transform tra, Material mat)
	{
		GameObject obj = Instantiate(original, original.transform.position, original.transform.rotation);
		MeshFilter f = obj.GetComponent<MeshFilter>();
		MeshRenderer r = obj.GetComponent<MeshRenderer>();
		MeshCollider c = obj.GetComponent<MeshCollider>();
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