using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "dialog")]
public class SODialog : ScriptableObject
{
    public SpriteRenderer img;
    public string characterName;
    public DialogText[] dialogs;
}

[System.Serializable]
public class DialogText
{
    [TextArea(5, 5)]
    public string dialog;
}
