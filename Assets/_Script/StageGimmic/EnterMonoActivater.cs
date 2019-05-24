using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterMonoActivater : MonoBehaviour
{
    [SerializeField] string OtherTag;
    [SerializeField] MonoBehaviour Target;
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == OtherTag && Target)
            Target.enabled = true;
    }
}