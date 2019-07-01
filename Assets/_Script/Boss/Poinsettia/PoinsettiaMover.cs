using System;
using System.Collections;
using UnityEngine;

public class PoinsettiaMover : MonoBehaviour
{
	[SerializeField] PoinsettiaAnimator anim;
	[SerializeField] Rigidbody rb;
	[SerializeField] AccessTransform StageLeft, StageRight, StageLeftUp, StageRightUp;
	[SerializeField] GameObject PoinsettiaShot, PoinsettiaSummon;
	public bool IsStan;
	public void UpdateState()
	{
		if (anim.state == AnimatorParameter.Poinsettia_Anim.Base_Layer_Idle)
			Idle();
		if (anim.state == AnimatorParameter.Poinsettia_Anim.Base_Layer_Shot)
			Shot();
		if (anim.state == AnimatorParameter.Poinsettia_Anim.Base_Layer_Summon)
			Summon();
		if (anim.state == AnimatorParameter.Poinsettia_Anim.Base_Layer_Charge)
			Charge();
		if (anim.state == AnimatorParameter.Poinsettia_Anim.Base_Layer_Stan)
			Stan();
		if (anim.state == AnimatorParameter.Poinsettia_Anim.Base_Layer_Fall)
			Fall();
		if (anim.state == AnimatorParameter.Poinsettia_Anim.Base_Layer_Defeat)
			Defeat();
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
		transform.position = StageRight.target.position;
		yield return new WaitForSeconds(0.5f);
		Instantiate(PoinsettiaShot, StageRight.target.position, Quaternion.identity);
		yield return new WaitForSeconds(1f);
		transform.position = StageLeft.target.position;
		Instantiate(PoinsettiaShot, StageLeft.target.position, Quaternion.Euler(0, 180, 0));
		yield return new WaitForSeconds(1f);
	}
	IEnumerator Summon_Coroutine()
	{
		yield return new WaitForSeconds(0.5f);
		transform.position = StageRight.target.position;
		yield return new WaitForSeconds(0.5f);
		Instantiate(PoinsettiaSummon, StageRight.target.position, Quaternion.identity);
		Instantiate(PoinsettiaSummon, StageRight.target.position, Quaternion.identity);
		Instantiate(PoinsettiaSummon, StageRight.target.position, Quaternion.identity);
		yield return new WaitForSeconds(1f);
	}
	IEnumerator Charge_Coroutine()
	{
		transform.position = StageLeft.target.position;
		yield return new WaitForSeconds(1.0f);
		rb.velocity = new Vector3(5, 0, 0);
		if (transform.position.x > StageRight.target.position.x)
			rb.position = Vector3.zero;
		if (IsStan)yield break;
		yield return new WaitForSeconds(1.0f);
		rb.velocity = new Vector3(-5, 0, 0);
		if (transform.position.x < StageLeft.target.position.x)
			rb.position = Vector3.zero;
		if (IsStan)yield break;
		yield return new WaitForSeconds(1.0f);
	}
	IEnumerator Stan_Coroutine()
	{
		rb.velocity = new Vector3(-rb.velocity.x, 10f, 0);
		yield return new WaitForSeconds(0.2f);
		rb.velocity = Vector3.zero;
		yield return new WaitForSeconds(2f);
	}
	IEnumerator Fall_Coroutine()
	{
		transform.position = StageLeft.target.position;
		Vector3 diff = (StageRight.target.position - StageLeft.target.position) / 5;
		yield return new WaitForSeconds(0.5f);
		for (int i = 0; i < 5; i++)
		{
			transform.position = StageLeftUp.target.position + diff * i;
			rb.velocity = Vector3.zero;
			yield return new WaitForSeconds(0.1f);
			rb.velocity = new Vector3(0, -10f, 0);
			yield return new WaitForSeconds(0.1f);
		}
		yield return new WaitForSeconds(1);
	}

}