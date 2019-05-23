using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "expose/joystick")]
public class AccessCircleJoyStick : ScriptableObject
{
    public CircleJoyStick target { get; set; }
}