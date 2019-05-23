using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeshCutTest : MonoBehaviour
{
    [SerializeField] MeshCutManeger MM;
    [SerializeField] Vector2 p0, p1;
    void Update()
    {
        StartCoroutine(test());
    }
    IEnumerator test()
    {
        this.enabled = false;
        yield return new WaitForEndOfFrame();
        MM.Slash(p0, p1);
    }
}