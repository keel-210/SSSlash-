using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "expose/gameobject")]
public class AccessGameObject : ScriptableObject
{
	public GameObject target { get; set; }
}