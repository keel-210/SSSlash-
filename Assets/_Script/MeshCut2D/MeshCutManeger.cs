using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeshCutManeger : MonoBehaviour
{
    [SerializeField] AccessTransform player;
    [SerializeField] float SlideLength;
    [SerializeField] string CanCutObjectTag;
    [SerializeField] GameObject CutParent;
    public MeshCut2D cutter = new MeshCut2D();
    MeshCutResult a = new MeshCutResult(), b = new MeshCutResult();
    List<List<CutRecord>> CutHistory = new List<List<CutRecord>>();
    public void Slash(Vector2 p0, Vector2 p1)
    {
        var objs = GameObject.FindGameObjectsWithTag(CanCutObjectTag).Where(x => x.GetComponent<Renderer>().isVisible);
        List<MeshCollider> cols = objs.Select(x => x.GetComponent<MeshCollider>()).ToList();
        List<MeshFilter> filters = objs.Select(x => x.GetComponent<MeshFilter>()).ToList();
        CutAll(cols, filters, p0, p1);
    }
    public void Slide(Vector3 PlayerPos, IList<CutRecord> rec, Vector2 p0, Vector2 p1)
    {
        GameObject OneSide = Instantiate(CutParent);
        GameObject OtherSide = Instantiate(CutParent);
        foreach (CutRecord r in rec)
        {
            r.CutObj0.transform.parent = OneSide.transform;
            r.CutObj1.transform.parent = OtherSide.transform;
        }
        //True is Oneside False is otherside is playerside
        Vector3 dir = new Vector3(p0.x - p1.x, p0.y - p1.y, 0).normalized;
        if (MeshCut2D.IsClockWise(p0.x, p0.y, p1.x, p1.y, PlayerPos.x, PlayerPos.y))
            OneSide.transform.position += dir * SlideLength;
        else
            OtherSide.transform.position += dir * SlideLength;
    }
    public IList<CutRecord> CutAll(IList<MeshCollider> colliders, IList<MeshFilter> filters, Vector2 p0, Vector2 p1)
    {
        List<CutRecord> templist = new List<CutRecord>();
        for (int i = 0; i < colliders.Count; i++)
        {
            var r = Cut(colliders[i], filters[i], p0, p1);
            templist.Add(r);
        }
        CutHistory.Add(templist);
        Slide(player.target.position, templist, p0, p1);
        return templist;
    }
    CutRecord Cut(MeshCollider col, MeshFilter filter, Vector2 p0, Vector2 p1)
    {
        Mesh mesh = DuplicateMesh(col.sharedMesh);
        Vector3 PosOffset = col.transform.position;
        Vector3 ScaleOffset = col.transform.lossyScale;
        Vector3[] slidedVertices = mesh.vertices.Select(v => new Vector3(v.x * ScaleOffset.x, v.y * ScaleOffset.y, v.z * ScaleOffset.z))
            .Select(v => v + PosOffset).ToArray();
        MeshCut2D.Cut(slidedVertices, mesh.uv, mesh.triangles, mesh.triangles.Count(), p0.x, p0.y, p1.x, p1.y, a, b);
        a.vertices = a.vertices.Select(v => v - PosOffset)
            .Select(v => new Vector3(v.x / ScaleOffset.x, v.y / ScaleOffset.y, v.z / ScaleOffset.z)).ToList();
        b.vertices = b.vertices.Select(v => v - PosOffset)
            .Select(v => new Vector3(v.x / ScaleOffset.x, v.y / ScaleOffset.y, v.z / ScaleOffset.z)).ToList();
        var obj1 = DuplicateMeshGameObject(col.gameObject, b, col.transform, col.GetComponent<MeshRenderer>().material);
        CutRecord rec = SaveCutRecord(col, obj1, filter, p0, p1);
        ApplyPolygonColloderAndMeshFilter(col, filter, a);
        return rec;
    }
    public void Return()
    {
        if (CutHistory.Count() > 0)
        {
            foreach (CutRecord r in CutHistory[CutHistory.Count - 1])
            {
                Vector3 dir = new Vector3(r.p0.x - r.p1.x, r.p0.y - r.p1.y, 0).normalized;
                if (MeshCut2D.IsClockWise(r.p0.x, r.p0.y, r.p1.x, r.p1.y, player.target.position.x, player.target.position.y))
                {
                    Vector3 pos = r.CutObj1.transform.position;
                    Vector3 scale = r.CutObj1.transform.localScale;
                    Quaternion rot = r.CutObj1.transform.rotation;
                    if (r.CutObj1)
                        Destroy(r.CutObj1);
                    r.CutObj0.GetComponent<MeshCollider>().sharedMesh = r.mesh;
                    r.CutObj0.GetComponent<MeshFilter>().mesh = r.mesh;
                    ApplyTransform(r.CutObj0.transform, pos, rot, scale);
                }
                else
                {
                    Vector3 pos = r.CutObj0.transform.position;
                    Vector3 scale = r.CutObj0.transform.localScale;
                    Quaternion rot = r.CutObj0.transform.rotation;
                    if (r.CutObj0)
                        Destroy(r.CutObj0);
                    r.CutObj1.GetComponent<MeshCollider>().sharedMesh = r.mesh;
                    r.CutObj1.GetComponent<MeshFilter>().mesh = r.mesh;
                    ApplyTransform(r.CutObj1.transform, pos, rot, scale);
                }
            }
            CutHistory.RemoveAt(CutHistory.Count - 1);
        }
    }
    CutRecord SaveCutRecord(MeshCollider col, GameObject Obj1, MeshFilter filter, Vector2 p0, Vector2 p1)
    {
        CutRecord rec = new CutRecord();
        rec.mesh = col.sharedMesh;
        rec.tra = col.transform;
        rec.pos = col.transform.position;
        rec.rot = col.transform.rotation;
        rec.scale = col.transform.localScale;
        rec.p0 = p0;
        rec.p1 = p1;
        rec.CutObj0 = Obj1;
        rec.CutObj1 = col.gameObject;
        return rec;
    }
    GameObject DuplicateMeshGameObject(GameObject original, MeshCutResult res, Transform tra, Material mat)
    {
        GameObject obj = Instantiate(original, original.transform.position, original.transform.rotation);
        MeshFilter f = obj.GetComponent<MeshFilter>();
        MeshRenderer r = obj.GetComponent<MeshRenderer>();
        MeshCollider c = obj.GetComponent<MeshCollider>();
        ApplyPolygonColloderAndMeshFilter(c, f, res);
        ApplyTransform(obj.transform, tra.position, tra.rotation, tra.localScale);
        r.material = mat;
        return obj;
    }
    void ApplyTransform(Transform obj, Vector3 pos, Quaternion rot, Vector3 scale)
    {
        obj.position = pos;
        obj.rotation = rot;
        obj.localScale = scale;
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