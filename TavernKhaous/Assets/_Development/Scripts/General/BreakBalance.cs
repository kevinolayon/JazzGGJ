using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBalance : MonoBehaviour, IBreakBalance
{
    [SerializeField] float damage;

    public float Damage()
    {
        return damage;
    }
}
