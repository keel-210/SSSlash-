using System;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayer, IClear
{
	void Update()
	{

	}
	void OnBecameInvisible()
	{
		if (gameObject.activeInHierarchy)
		{
			StartCoroutine(this.DelayMethod(0.2f, () =>
			{
				Death();
			}));
		}
	}
	public void Death()
	{
		if (this.enabled)
		{
			Debug.Log("Death");
			FindObjectOfType<SceneLoader>()?.LoadActiveScene();
		}
	}
	public void Clear()
	{
		this.enabled = false;
	}
}