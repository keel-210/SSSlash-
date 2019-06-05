using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityZone : MonoBehaviour
{
    [SerializeField] public Vector3 gravity;
    List<Rigidbody> rigidbodyList = new List<Rigidbody>();
    void FixedUpdate()
    {
        foreach (Rigidbody r in rigidbodyList)
        {
            Debug.Log(r);
            r.AddForce(gravity, ForceMode.Acceleration);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        var t = other.GetComponent<IRecieveGravity>();
        if (t != null)
            rigidbodyList.Add(t.rb);
    }
    void OnTriggerExit(Collider other)
    {
        var t = other.GetComponent<IRecieveGravity>();
        if (t != null)
            rigidbodyList.Remove(t.rb);
    }
}