using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] string scene;
    [SerializeField] List<string> Additivescenes;
    void Start()
    {
        if (!string.IsNullOrEmpty(scene))
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        foreach (string s in Additivescenes)
            SceneManager.LoadScene(s, LoadSceneMode.Additive);
    }
}