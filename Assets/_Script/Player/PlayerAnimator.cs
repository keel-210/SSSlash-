using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] AccessCircleJoyStick JoyStick;
    [SerializeField] PlayerMover mover;
    [SerializeField] Animator animator;
    [SerializeField] AccessSlasher slasher;
    [SerializeField] GameObject walkParticle0, walkParticle1;
    public Rigidbody rb { get; set; }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Vector2 input = JoyStick.target.Position;
        if (input.x != 0)
            transform.localScale = new Vector3(input.x / Mathf.Abs(input.x), 1, 1);
        animator.SetBool("OnGround", mover.OnGround);
        animator.SetFloat("VeloX", rb.velocity.x);
        animator.SetFloat("VeloY", rb.velocity.y);
        animator.SetFloat("JoyStickX", input.x);
        animator.SetFloat("JoyStickY", input.y);
        animator.SetBool("JoyStickXZero", input.x == 0);
        animator.SetBool("JoyStickYZero", input.y == 0);
        if (slasher.target != null)
            animator.SetBool("Slash", slasher.target.CanSlash);
    }
}