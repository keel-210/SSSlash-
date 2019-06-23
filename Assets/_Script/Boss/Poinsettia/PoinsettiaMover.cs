using UnityEngine;

public class PoinsettiaMover : MonoBehaviour
{
	[SerializeField] PoinsettiaAnimator anim;
	[SerializeField] Rigidbody rb;
	[SerializeField] AccessTransform StageLeft, StageRight, StageLeftUp, StageRightUp;
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
	void Idle() {}
	void Shot() {}
	void Summon() {}
	void Charge() {}
	void Stan() {}
	void Fall() {}
	void Defeat() {}
}