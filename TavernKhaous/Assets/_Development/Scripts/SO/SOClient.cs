using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Client")]
public class SOClient : ScriptableObject
{
    public string clientName;
    public List<int> orders;

    public int firstDialogNode;

    public int SatisfiedDialog;
    public int VerySatisfiedDialog;
    public int DissatisfiedDialog;

    public GameObject _model;
}
