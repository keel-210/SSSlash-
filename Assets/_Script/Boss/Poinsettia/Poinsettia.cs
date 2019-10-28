using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Poinsettia : MonoBehaviour, IBoss, ISlide
{
	public int Health { get; set; }
	public bool IsDamagable { get; set; }
	public List<Vector3> PosHistory { get; set; } = new List<Vector3>();
	public PoinsettiaAnimator anim;
	public PoinsettiaMover mover;
	public Rigidbody rb;
	void Start()
	{
		Health = 3;
	}
	public void Slide(Vector2 p0, Vector2 p1, bool PlayerSide, Vector3 SlideVec)
	{
		PosHistory.Add(transform.position);
		bool GoalSide = MeshCut2D.IsClockWise(p0.x, p0.y, p1.x, p1.y, transform.position.x, transform.position.y);
		if (PlayerSide && !GoalSide)
			transform.position += SlideVec;
		else if (!PlayerSide && GoalSide)
			transform.position += SlideVec;
	}
	public void Return(Vector2 p0, Vector2 p1, bool PlayerSide)
	{
		bool GoalSide = MeshCut2D.IsClockWise(p0.x, p0.y, p1.x, p1.y, transform.position.x, transform.position.y);
		if (PlayerSide && !GoalSide)
			transform.position = PosHistory.Last();
		else if (!PlayerSide && GoalSide)
			transform.position = PosHistory.Last();
		PosHistory.Remove(PosHistory.Last());
	}
	void OnCollisionEnter(Collision other)
	{
		if (anim.state == AnimatorParameter.Poinsettia_Anim.Base_Layer_Charge &&
			Mathf.Abs(rb.velocity.x) > 0 && other.gameObject.tag == TagName.CanCutObject)
		{
			mover.IsStan = true;
			anim.Stan();
		}
	}
	public void Damage()
	{
		if (IsDamagable)
		{
			Health--;
			anim.HealthUpdate();
		}
		if (Health <= 0)
			Clear();
	}
	public void Clear()
	{
		GameObject.FindGameObjectWithTag(TagName.BossSettings).GetComponent<IClear>()?.Clear();
	}
}