using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoinsettiaAnimator : MonoBehaviour, IBossAnimator
{
    [SerializeField] AccessTransform _player;
    [SerializeField] public AccessTransform player { get; set; }

    [SerializeField] public Animator animator { get; set; }

    [SerializeField] public IBoss boss { get; set; }

    [SerializeField] PoinsettiaMover mover;
    AnimatorParameter.Poinsettia_Anim p;
    PoinsettiaState AnimState;
    public int state, prevState;
    void Start()
    {
        player = _player;
        animator = GetComponentInChildren<Animator>();
        boss = GetComponent<IBoss>();
    }
    void Update()
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        state = info.fullPathHash;
        if (state != prevState)
            mover.UpdateState();
        prevState = info.fullPathHash;
    }
    public void Stan()
    {
        p.IsDamagable = true;
    }
    public void HealthUpdate()
    {
        p.Damaged = true;
        p.Health = boss.Health;
    }
    public void ResetParameter()
    {
        p.IsDamagable = false;
        p.Damaged = false;
    }
}