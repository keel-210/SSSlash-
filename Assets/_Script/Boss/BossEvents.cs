using UnityEngine;
using UnityEngine.Events;
public class BossEvents : MonoBehaviour, IClear
{
	[SerializeField] UnityEvent OnAwake, OnStart, OnFightStart, OnDefeat;
	void Awake()
	{
		OnAwake.Invoke();
		gameObject.tag = TagName.BossSettings;
	}
	void Start()
	{
		OnStart.Invoke();
	}
	public void FightStart()
	{
		Debug.Log("Fight");
		OnFightStart.Invoke();
	}
	public void Clear()
	{
		OnDefeat.Invoke();
	}
}