using System;
using System.Collections;
using UnityEngine;

public class PoinsettiaMover : MonoBehaviour
{
	[SerializeField] PoinsettiaAnimator anim;
	[SerializeField] Rigidbody rb;
	[SerializeField] AccessTransform StageLeft, StageRight, StageLeftUp, StageRightUp;
	[SerializeField] GameObject PoinsettiaShot, PoinsettiaSummon;
	[SerializeField] float PrevShotTime, ShotTimeInterval, BackShotTime;
	[SerializeField] float PrevSummonTime, BackSummonTime;
	[SerializeField] float PrevChargeTime, ChargingTime, BackChargeTime;
	[SerializeField] float PrevStanTime, StanTime;
	[SerializeField] float PrevFallTime, WaitFallTime, FallingTime, BackFallTime;
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
	void Idle()
	{
		rb.velocity = Vector3.zero;
		transform.position = StageRight.target.position;
	}
	void Shot() => StartCoroutine(Shot_Coroutine());
	void Summon() => StartCoroutine(Summon_Coroutine());
	void Charge() => StartCoroutine(Charge_Coroutine());
	void Stan() => StartCoroutine(Stan_Coroutine());
	void Fall() => StartCoroutine(Fall_Coroutine());

	void Defeat()
	{
		rb.velocity = Vector3.zero;
		transform.position = StageRight.target.position;
	}
	IEnumerator Shot_Coroutine()
	{
		rb.velocity = Vector3.zero;
		transform.position = StageRight.target.position;
		yield return new WaitForSeconds(PrevShotTime);
		Instantiate(PoinsettiaShot, StageRight.target.position, Quaternion.identity);
		yield return new WaitForSeconds(ShotTimeInterval);
		transform.position = StageLeft.target.position;
		Instantiate(PoinsettiaShot, StageLeft.target.position, Quaternion.Euler(0, 180, 0));
		yield return new WaitForSeconds(BackShotTime);
	}
	IEnumerator Summon_Coroutine()
	{
		rb.velocity = Vector3.zero;
		transform.position = StageRight.target.position;
		yield return new WaitForSeconds(PrevSummonTime);
		Instantiate(PoinsettiaSummon, StageRight.target.position, Quaternion.identity);
		Instantiate(PoinsettiaSummon, StageRight.target.position, Quaternion.identity);
		Instantiate(PoinsettiaSummon, StageRight.target.position, Quaternion.identity);
		yield return new WaitForSeconds(BackSummonTime);
	}
	IEnumerator Charge_Coroutine()
	{
		rb.velocity = Vector3.zero;
		transform.position = StageLeft.target.position;
		yield return new WaitForSeconds(PrevChargeTime);
		rb.velocity = new Vector3(10, 0, 0);
		if (transform.position.x > StageRight.target.position.x)
			rb.velocity = Vector3.zero;
		if (IsStan)yield break;
		yield return new WaitForSeconds(ChargingTime);
		rb.velocity = Vector3.zero;
		transform.position = StageRight.target.position;
		yield return new WaitForSeconds(0.1f);
		rb.velocity = new Vector3(-10, 0, 0);
		if (transform.position.x < StageLeft.target.position.x)
			rb.velocity = Vector3.zero;
		if (IsStan)yield break;
		yield return new WaitForSeconds(ChargingTime);
		rb.velocity = Vector3.zero;
		transform.position = StageRight.target.position;
		yield return new WaitForSeconds(BackChargeTime);
	}
	IEnumerator Stan_Coroutine()
	{
		rb.velocity = new Vector3(-rb.velocity.x, 10f, 0);
		yield return new WaitForSeconds(PrevStanTime);
		rb.velocity = Vector3.zero;
		yield return new WaitForSeconds(StanTime);
	}
	IEnumerator Fall_Coroutine()
	{
		rb.velocity = Vector3.zero;
		transform.position = StageLeft.target.position;
		Vector3 diff = (StageRight.target.position - StageLeft.target.position) / 4;
		yield return new WaitForSeconds(PrevFallTime);
		for (int i = 0; i < 5; i++)
		{
			transform.position = StageLeftUp.target.position + diff * i;
			rb.velocity = Vector3.zero;
			yield return new WaitForSeconds(WaitFallTime);
			for (float Timer = 0; Timer < FallingTime; Timer += Time.deltaTime)
			{
				rb.velocity += new Vector3(0, -500f * Time.deltaTime, 0);
				yield return null;
			}
		}
		transform.position = StageRight.target.position;
		yield return new WaitForSeconds(BackFallTime);
	}

}