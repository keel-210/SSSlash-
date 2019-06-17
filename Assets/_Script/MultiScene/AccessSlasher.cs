using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "expose/slasher")]
public class AccessSlasher : ScriptableObject
{
	public Slasher target { get; set; }
}