﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehaviour : SingletonGameObject<GoalBehaviour>
{
    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IPlayer>()?.Clear();
    }
}