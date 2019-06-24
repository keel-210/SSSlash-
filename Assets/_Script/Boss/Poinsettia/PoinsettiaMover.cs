using System;
using System.Collections;
using UnityEngine;

public class PoinsettiaMover : MonoBehaviour
{
	[SerializeField] PoinsettiaAnimator anim;
	[SerializeField] Rigidbody rb;
	[SerializeField] AccessTransform StageLeft, StageRight, StageLeftUp, StageRightUp;
	[SerializeField] GameObject PoinsettiaShot, PoinsettiaSummon;
	IBoss boss;
	void Update()
	{
		switch (anim.state)
		{
			case PoinsettiaState.Idle:
				Idle();
				break;
			case PoinsettiaState.Shot:
				Shot();
				break;
			case PoinsettiaState.Summon:
				Summon();
				break;
			case PoinsettiaState.Charge:
				Charge();
				break;
			case PoinsettiaState.Stan:
				Stan();
				break;
			case PoinsettiaState.Fall:
				Fall();
				break;
			case PoinsettiaState.Defeat:
				Defeat();
				break;
		}
	}
	void Idle() => transform.position = StageRight.target.position;
	void Shot() => StartCoroutine(Shot_Coroutine());
	void Summon() => StartCoroutine(Summon_Coroutine());
	void Charge() => StartCoroutine(Charge_Coroutine());
	void Stan() => StartCoroutine(Stan_Coroutine());
	void Fall() => StartCoroutine(Fall_Coroutine());

	void Defeat() => transform.position = StageRight.target.position;
	IEnumerator Shot_Coroutine()
	{
		yield return new WaitForSeconds(0.5f);
	}
	IEnumerator Summon_Coroutine()
	{
		yield return new WaitForSeconds(0.5f);
	}
	IEnumerator Charge_Coroutine()
	{
		yield return new WaitForSeconds(0.5f);
	}
	IEnumerator Stan_Coroutine()
	{
		yield return new WaitForSeconds(0.5f);
	}
	IEnumerator Fall_Coroutine()
	{
		yield return new WaitForSeconds(0.5f);
	}
	void OnCollisionEnter(Collision other)
	{
		if (anim.state == PoinsettiaState.Charge && rb.velocity.x > 0 &&
			other.gameObject.tag == TagName.CanCutObject)
		{
			anim.Stan();
		}
	}
}