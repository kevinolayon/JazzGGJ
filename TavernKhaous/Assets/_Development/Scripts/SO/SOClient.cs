using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Client")]
public class SOClient : ScriptableObject
{
    public string clientName;
    public List<int> orders;

    public int Satisfied;
    public int dissatisfied;
    public int verySatisfied;
}
