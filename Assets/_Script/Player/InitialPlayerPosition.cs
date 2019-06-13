using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPlayerPosition : MonoBehaviour
{
    [SerializeField] AccessTransform player;
    void Update()
    {
        if (player)
        {
            player.target.position = transform.position;
            Destroy(this);
        }
    }
}