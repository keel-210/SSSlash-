using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoss
{
    int Health { get; set; }
    bool IsDamagable { get; set; }
    void Damage();
    void Clear();
}