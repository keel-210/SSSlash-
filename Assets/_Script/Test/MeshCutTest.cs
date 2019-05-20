using System.Collections.Generic;
using UnityEngine;

public class MeshCutTest : MonoBehaviour
{
    [SerializeField] MeshCutManeger MM;
    [SerializeField] List<MeshCollider> mesh;
    [SerializeField] Vector2 p0, p1;

    void Start()
    {
        List<MeshFilter> f = new List<MeshFilter>();
        foreach (MeshCollider m in mesh)
        {
            f.Add(m.GetComponent<MeshFilter>());
        }
        MM.CutAll(mesh, f, p0, p1);
    }
}