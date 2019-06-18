using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCopy : MonoBehaviour
{
    [SerializeField] Transform tra;
    void Update()
    {
        transform.localScale = tra.lossyScale;
    }
}