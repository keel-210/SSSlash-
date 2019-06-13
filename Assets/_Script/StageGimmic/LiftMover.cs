using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftMover : MonoBehaviour
{
    [SerializeField] Vector3 TargetPos;
    [SerializeField] float time;
    bool IsGoToTarget = true;
    Vector3 PosDiff;
    float Timer;
    void Start()
    {
        PosDiff = TargetPos / time;
    }
    void Update()
    {
        Timer += Time.deltaTime;
        if (IsGoToTarget)
        {
            transform.localPosition += PosDiff * Time.deltaTime;
        }
        else
        {
            transform.localPosition -= PosDiff * Time.deltaTime;
        }
        if (Timer > time)
        {
            Timer = 0;
            IsGoToTarget = !IsGoToTarget;
        }
    }
}