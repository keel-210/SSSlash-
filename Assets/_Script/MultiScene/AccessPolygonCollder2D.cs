using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "expose/PolygonCollider2D")]
public class AccessPolygonCollider2D : ScriptableObject
{
	public PolygonCollider2D target { get; set; }
}