using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "expose/meshcut")]
public class AccessMeshCutManager : ScriptableObject
{
	public MeshCutManeger target { get; set; }
}