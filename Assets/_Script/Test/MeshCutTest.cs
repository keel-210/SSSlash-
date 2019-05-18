using UnityEngine;

public class MeshCutTest : MonoBehaviour
{
	[SerializeField] MeshCutManeger MM;
	[SerializeField] MeshCollider mesh;
	[SerializeField] Vector2 p0, p1;

	void Start()
	{
		MM.Cut(mesh, mesh.GetComponent<MeshFilter>(), p0, p1);
	}
}