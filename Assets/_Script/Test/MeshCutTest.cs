using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeshCutTest : MonoBehaviour
{
    [SerializeField] MeshCutManeger MM;
    [SerializeField] Vector2 p0, p1;

    void Start()
    {
        var objs = GameObject.FindGameObjectsWithTag("CanCutObject");
        List<MeshCollider> mesh = objs.Select(x => x.GetComponent<MeshCollider>()).ToList();
        List<MeshFilter> f = new List<MeshFilter>();
        foreach (MeshCollider m in mesh)
        {
            f.Add(m.GetComponent<MeshFilter>());
        }
        MM.CutAll(mesh, f, p0, p1);
    }
}