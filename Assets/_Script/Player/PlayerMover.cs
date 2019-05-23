using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] AccessCircleJoyStick JoyStick;
    [SerializeField] Rigidbody player;
    [SerializeField] float Speed, JumpPower, JumpThreshold;
    Vector2 velo;

    void Update()
    {
        Vector2 i = JoyStick.target.Position;
        float up = i.y > JumpThreshold ? JumpPower : 0;
        velo = new Vector2(i.x * Speed, up * JumpPower);
    }
    void FixedUpdate()
    {
        player.velocity = velo;
    }
}
