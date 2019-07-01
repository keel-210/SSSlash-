using UnityEngine;

public interface IBossAnimator
{
	Animator animator { get; set; }

	AccessTransform player { get; set; }
	IBoss boss { get; set; }
	void HealthUpdate();
}