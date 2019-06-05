using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Restrict2DCamera : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera Vcam;
    [SerializeField] AccessTransform Target;
    void Start()
    {
        if (Target.target)
        {
            Vcam.Follow = Target.target;
            this.enabled = false;
        }
    }
    void Update()
    {
        if (Target.target)
        {
            Vcam.Follow = Target.target;
            this.enabled = false;
        }
    }
}