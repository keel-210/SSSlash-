using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveStrict : MonoBehaviour
{
    public void PlayerMoveDeactivater()
    {
        if (GameObject.FindGameObjectWithTag(TagName.Player))
        {

            GameObject.FindGameObjectWithTag(TagName.Player)
                .GetComponent<PlayerMover>().enabled = false;
            GameObject.FindGameObjectWithTag(TagName.Player)
                .GetComponent<PlayerAnimator>().enabled = false;
        }
        else
        {
            StartCoroutine(this.DelayMethod(0.1f, () => PlayerMoveDeactivater()));
        }
    }
    public void PlayerIdleAnim()
    {
        if (GameObject.FindGameObjectWithTag(TagName.Player))
        {
            Animator anim = GameObject.FindGameObjectWithTag(TagName.Player)
                .transform.GetComponentInChildren<Animator>();
            anim.SetBool("OnGround", true);
            anim.CrossFadeInFixedTime(AnimatorParameter.Rindou.Base_Layer_Rindou_idle, 0);
        }
        else
        {
            StartCoroutine(this.DelayMethod(0.1f, () => PlayerIdleAnim()));
        }
    }
    public void PlayerMoveActivater()
    {
        GameObject.FindGameObjectWithTag(TagName.Player)
            .GetComponent<PlayerMover>().enabled = true;
        GameObject.FindGameObjectWithTag(TagName.Player)
            .GetComponent<PlayerAnimator>().enabled = true;
    }
}