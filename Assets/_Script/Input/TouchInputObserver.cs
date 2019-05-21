using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputObserver : MonoBehaviour
{
    public TouchInfo info;
    void Start()
    {

    }

    void Update()
    {
        info = AppUtil.GetTouch();
    }
}
