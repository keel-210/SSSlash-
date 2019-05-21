using UnityEngine;

public class Slasher : MonoBehaviour
{
    [SerializeField] float MinimamActivateLength;
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
            CanSlash = true;
        if (info == TouchInfo.Ended)
        {
            if (CanSlash)
            {
                Debug.Log("StartPos : " + StartPos + " EndPos" + AppUtil.GetTouchPosition());
                // cutter.Slash(StartPos, AppUtil.GetTouchPosition());
            }
            CanSlash = false;
        }
    }
}