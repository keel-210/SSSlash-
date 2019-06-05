﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerMover : MonoBehaviour, IRecieveGravity
{
    [SerializeField] AccessCircleJoyStick JoyStick;
    public Rigidbody rb { get; set; }

    [SerializeField] float Speed, JumpPower, JumpThreshold;
    Vector2 velo;
    public bool OnGround, HasJumped, HasDoubleJumped = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // Vector2 input = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
        Vector2 input = JoyStick.target.Position;
        if (OnGround && !HasJumped && input.y > JumpThreshold)
        {
            velo = new Vector2(input.x * Speed, JumpPower);
            HasJumped = true;
        }
        else if (!OnGround && HasJumped && !HasDoubleJumped && rb.velocity.y <= 0 && input.y > JumpThreshold)
        {
            velo = new Vector2(input.x * Speed, JumpPower);
        }
        else
        {
            velo = new Vector2(input.x * Speed, rb.velocity.y);
        }
    }
    void FixedUpdate()
    {
        rb.velocity = velo;
    }
    void OnCollisionEnter(Collision other)
    {
        if (rb.velocity.y <= 0)
        {
            OnGround = true;
            HasJumped = false;
        }
    }
    void OnCollisionExit(Collision other)
    {
        OnGround = false;
    }
}