using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoinsettiaAnimator : MonoBehaviour, IBossAnimator
{
    [SerializeField] AccessTransform _player;
    [SerializeField] public AccessTransform player { get; set; }

    [SerializeField] public Animator animator { get; set; }

    [SerializeField] public IBoss boss { get; set; }

    [SerializeField] public Rigidbody rb { get; set; }
    public PoinsettiaState state;
    void Start()
    {
        player = _player;
        animator = GetComponent<Animator>();
        boss = GetComponent<IBoss>();
        rb = GetComponent<Rigidbody>();
        animator.CrossFadeInFixedTime(AnimatorParameter.Poinsettia_Anim.Base_Layer_Idle, 0);
    }
    void Update()
    {}
    public void HealthUpdate() {}
}