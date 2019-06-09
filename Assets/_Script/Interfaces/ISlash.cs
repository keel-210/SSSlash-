using System;
using UnityEngine;

public interface ISlash
{
	void Slashed(Vector2 p0, Vector2 p1, bool PlayerSide, Vector3 SlideVec);
	void Return();
}