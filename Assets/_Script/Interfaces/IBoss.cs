using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoss
{
    int Health { get; set; }
    void Damage();
    void Clear();
}