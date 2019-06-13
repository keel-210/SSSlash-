using System.Collections;
using UnityEngine;

public class Slasher : MonoBehaviour
{
    [SerializeField] float MinimamActivateLength, SlashShakeStrength;
    [SerializeField] LineRenderer line;
    [SerializeField] AccessCinemachineImpulseSource target;
    [SerializeField] RectTransform JoyStick, ReturnButton;
    [SerializeField] UVScroll4Line lineScroll;
    MeshCutManeger cutter;
    public Vector3 StartPos;
    TouchInfo info;
    bool CanSlash = false;
    void Start()
    {
        cutter = FindObjectOfType<MeshCutManeger>();
        lineScroll.enabled = false;
    }
    void Update()
    {
        info = AppUtil.GetTouch();
        if (info == TouchInfo.Began)
            StartPos = AppUtil.GetTouchPosition();
        if (info == TouchInfo.Moved)
        {
            bool OnJoyStick = JoyStick.rect.Contains(JoyStick.InverseTransformPoint(StartPos));
            bool OnButton = ReturnButton.rect.Contains(ReturnButton.InverseTransformPoint(StartPos));
            bool t = Vector3.Distance(StartPos, AppUtil.GetTouchPosition()) > MinimamActivateLength;
            if (!OnJoyStick && !OnButton && t)
            {
                line.enabled = true;
                lineScroll.enabled = true;
                CanSlash = true;
                Vector3[] slashLine = { Camera.main.ScreenToWorldPoint(StartPos), Camera.main.ScreenToWorldPoint(AppUtil.GetTouchPosition()) };
                slashLine[0] = new Vector3(slashLine[0].x, slashLine[0].y, 0);
                slashLine[1] = new Vector3(slashLine[1].x, slashLine[1].y, 0);
                Vector3 LineDirection = (slashLine[0] - slashLine[1]).normalized;
                slashLine[1] = slashLine[0] + LineDirection * 30;
                slashLine[0] += -LineDirection * 30;
                line.SetPositions(slashLine);
            }
        }
        if (info == TouchInfo.Ended)
        {
            if (CanSlash)
                StartCoroutine(SlashCoroutine());
            CanSlash = false;
        }
    }
    IEnumerator SlashCoroutine()
    {
        Vector3 s = Camera.main.ScreenToWorldPoint(StartPos);
        Vector3 e = Camera.main.ScreenToWorldPoint(AppUtil.GetTouchPosition());
        target.target?.GenerateImpulseAt(Vector3.zero, (e - s).normalized * SlashShakeStrength);
        yield return new WaitForEndOfFrame();
        cutter.Slash(new Vector3(s.x, s.y, 0), new Vector3(e.x, e.y, 0));
        line.enabled = false;
        lineScroll.enabled = false;
    }
}