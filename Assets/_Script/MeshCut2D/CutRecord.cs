using UnityEngine;
public class CutRecord
{
	public Transform tra { get; set; }
	public Mesh mesh { get; set; }
	public GameObject CutObj0 { get; set; }
	public GameObject CutObj1 { get; set; }
	public MeshCollider collider { get; set; }
	public MeshFilter filter { get; set; }
}