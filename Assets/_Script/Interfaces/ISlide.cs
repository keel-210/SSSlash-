using System;
using System.Collections.Generic;
using UnityEngine;
public interface ISlide
{
	List<Vector3> PosHistory { get; set; }
	void Slide(Vector2 p0, Vector2 p1, bool PlayerSide, Vector3 SlideVec);
	void Return();
}