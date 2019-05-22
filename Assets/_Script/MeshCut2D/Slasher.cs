using UnityEngine;

public class Slasher : MonoBehaviour
{
    [SerializeField] float MinimamActivateLength;
    [SerializeField] LineRenderer line;
    MeshCutManeger cutter;
    Vector3 StartPos;
    TouchInfo info;
    bool CanSlash = false;
    void Start()
    {
        cutter = FindObjectOfType<MeshCutManeger>();
    }
    void Update()
    {
        info = AppUtil.GetTouch();
        if (info == TouchInfo.Began)
            StartPos = AppUtil.GetTouchPosition();
        if (info == TouchInfo.Moved && Vector3.Distance(StartPos, AppUtil.GetTouchPosition()) > MinimamActivateLength)
        {
            CanSlash = true;
            Vector3[] slashLine = { Camera.main.ScreenToWorldPoint(StartPos), Camera.main.ScreenToWorldPoint(AppUtil.GetTouchPosition()) };
            slashLine[0] = new Vector3(slashLine[0].x, slashLine[0].y, 0);
            slashLine[1] = new Vector3(slashLine[1].x, slashLine[1].y, 0);
            line.SetPositions(slashLine);
        }
        if (info == TouchInfo.Ended)
        {
            if (CanSlash)
            {
                Vector3 s = Camera.main.ScreenToWorldPoint(StartPos);
                Vector3 e = Camera.main.ScreenToWorldPoint(AppUtil.GetTouchPosition());
                Debug.Log("StartPos : " + s + " EndPos" + e);
                cutter.Slash(new Vector3(s.x, s.y, 0), new Vector3(e.x, e.y, 0));
            }
            CanSlash = false;
        }
    }
}