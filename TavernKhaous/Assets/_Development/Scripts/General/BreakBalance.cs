using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBalance : MonoBehaviour, IBreakBalance
{
    [SerializeField] int damage;

    public int Damage()
    {
        return damage;
    }
}
