using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerMover : MonoBehaviour
{
    [SerializeField] AccessCircleJoyStick JoyStick;
    [SerializeField] Rigidbody playerRigidbody;
    [SerializeField] float Speed, JumpPower, JumpThreshold;
    Vector2 velo;
    public bool OnGround, HasJumped, HasDoubleJumped = true;
    void Update()
    {
        // Vector2 input = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
        Vector2 input = JoyStick.target.Position;
        if (OnGround && !HasJumped && input.y > JumpThreshold)
        {
            velo = new Vector2(input.x * Speed, JumpPower);
            HasJumped = true;
        }
        else if (!OnGround && HasJumped && !HasDoubleJumped && playerRigidbody.velocity.y <= 0 && input.y > JumpThreshold)
        {
            velo = new Vector2(input.x * Speed, JumpPower);
        }
        else
        {
            velo = new Vector2(input.x * Speed, playerRigidbody.velocity.y);
        }
    }
    void FixedUpdate()
    {
        playerRigidbody.velocity = velo;
    }
    void OnCollisionEnter(Collision other)
    {
        if (playerRigidbody.velocity.y <= 0)
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