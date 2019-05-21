using UnityEngine;

public class Slasher : MonoBehaviour
{
    TouchInputObserver TouchObserver;
    MeshCutManeger cutter;
    void Start()
    {
        TouchObserver = FindObjectOfType<TouchInputObserver>();
        cutter = FindObjectOfType<MeshCutManeger>();
    }
    void Update()
    {
    }
    void PreSlash()
    {

    }
}