using System.Collections.Generic;
using UnityEngine;

public class MeshCutTest : MonoBehaviour
{
	[SerializeField] MeshCutManeger MM;
	[SerializeField] MeshCollider mesh;
	[SerializeField] Vector2 p0, p1;

	void Start()
	{
		List<MeshCollider> m = new List<MeshCollider> { mesh };
		List<MeshFilter> f = new List<MeshFilter> { mesh.GetComponent<MeshFilter>() };
		MM.CutAll(m, f, p0, p1);
	}
}