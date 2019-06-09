using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVScroll4Line : MonoBehaviour
{
    [SerializeField] float ScrollSpeed;
    [SerializeField] LineRenderer line;
    void Update()
    {
        float scroll = Mathf.Repeat(Time.time * ScrollSpeed, 1);
        Vector2 offset = new Vector2(scroll, 0);
        line.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}