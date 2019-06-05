using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(Light))]
public class Dynamic2DLight : MonoBehaviour
{
    [SerializeField] MeshRenderer rend;
    [SerializeField] MeshFilter filter;
    [SerializeField] Light pointLight;
    Mesh mesh;
    List<MeshFilter> list = new List<MeshFilter>();
    void Start()
    {
        if (!(rend = GetComponent<MeshRenderer>()))
            rend = gameObject.AddComponent<MeshRenderer>();
        if (!(filter = GetComponent<MeshFilter>()))
            filter = gameObject.AddComponent<MeshFilter>();
        if (!(pointLight = GetComponent<Light>()))
            pointLight = gameObject.AddComponent<Light>();
    }

    void Update()
    {

    }
    void MakeMesh()
    {

    }
    void ApplyMesh()
    {

    }
}