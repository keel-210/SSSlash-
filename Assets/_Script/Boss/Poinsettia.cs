using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poinsettia : MonoBehaviour, IBoss, ISlide
{
    public List<Vector3> PosHistory { get; set; }
    public void Slide(Vector2 p0, Vector2 p1, bool PlayerSide, Vector3 SlideVec)
    {

    }
    public void Return(Vector2 p0, Vector2 p1, bool PlayerSide)
    {

    }

    [SerializeField] public int Health { get; set; }
    public void Damage()
    {

    }
    public void Clear()
    {

    }
}