using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteCheck : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        Debug.Log(UnityRemoteChecker.IsRemote);
    }
}