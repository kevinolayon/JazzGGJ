using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogNodes
{
    public Node[] nodes;
}

[System.Serializable]
public class Node 
{
    public int nodeId;
    public int nextNode;
    public NormalDialog[] normalDialogs;
    public Answer[] answers;
}

[System.Serializable]
public class NormalDialog
{
    public string nodePortrait;
    public string dialog;
}

[System.Serializable]
public class Answer
{
    public string answer;
    public int point;
    public int nodeLinkID;
}
