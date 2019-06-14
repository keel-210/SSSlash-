using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] bool LoadOnAwake;
    [SerializeField] public string scene;
    [SerializeField] public List<string> Additivescenes;
    void Start()
    {
        if (LoadOnAwake)
            LoadScene();
    }
    public void LoadScene()
    {
        Debug.Log(gameObject.name + " : " + scene);
        if (!string.IsNullOrEmpty(scene))
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        foreach (string s in Additivescenes)
            SceneManager.LoadScene(s, LoadSceneMode.Additive);
    }
    public void LoadActiveScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}