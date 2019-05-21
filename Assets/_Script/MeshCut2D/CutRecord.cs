using UnityEngine;
public class CutRecord
{
    public Transform tra { get; set; }
    public Vector3 pos { get; set; }
    public Quaternion rot { get; set; }
    public Vector3 scale { get; set; }
    public Mesh mesh { get; set; }
    public GameObject CutObj0 { get; set; }
    public GameObject CutObj1 { get; set; }
    public Vector2 p0 { get; set; }
    public Vector2 p1 { get; set; }
}