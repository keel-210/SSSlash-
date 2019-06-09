using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "expose/ImpulseSource")]
public class AccessCinemachineImpulseSource : ScriptableObject
{
	public Cinemachine.CinemachineImpulseSource target { get; set; }
}