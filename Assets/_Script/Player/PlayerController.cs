using System;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayer, IClear
{
	void Update()
	{

	}
	void OnBecameInvisible()
	{
		Death();
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