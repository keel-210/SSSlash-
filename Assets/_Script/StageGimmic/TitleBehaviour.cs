using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBehaviour : MonoBehaviour, ISlash
{
    [SerializeField] SceneLoader loader;
    [SerializeField] float waitTime;
    public void Slashed(Vector2 p0, Vector2 p1, bool PlayerSide, Vector3 SlideVec)
    {
        StartCoroutine(this.DelayMethod(waitTime, () => { loader.LoadScene(); }));
    }
    public void Return()
    {

    }
}