using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Client")]
public class SOClient : ScriptableObject
{
    public string name;
    public bool hasClientStartedOrder = false;
    public string secretOrder;
    public string normalOrder;
}
