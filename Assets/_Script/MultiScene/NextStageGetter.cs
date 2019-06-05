using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStageGetter : MonoBehaviour
{
    void Start()
    {
        GetComponent<SceneLoader>().scene = FindObjectOfType<NextStageScene>().NextScene;
    }
}