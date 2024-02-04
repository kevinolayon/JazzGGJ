using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeDialogs
{
    [HideInInspector]
    public DialogNodes dialogNodes;
    [SerializeField]
    public Sprite [] dialogPortraits;

    public void Load(TextAsset dialogFile)
    {
        Read(dialogFile.text);
        LoadPortraits();
    }

    private void Read(string dialogText)
    {
        dialogNodes = JsonUtility.FromJson<DialogNodes>(dialogText);
    }

    private void LoadPortraits()
    {
        var loadesSprites = Resources.LoadAll("Portraits", typeof(Sprite));
        dialogPortraits = new Sprite[loadesSprites.Length];

        for(int i = 0; i < loadesSprites.Length; i++)
        {
            dialogPortraits[i] = (Sprite) loadesSprites[i];
        }
    }

    public Node GetNode(int id)
    {
        Node node = dialogNodes.nodes[id];

        if(node != null)
            return node;

        return null;
    }

    public Sprite GetPortrait(string portraitName)
    {
        for(int i = 0; i < dialogPortraits.Length; i++)
        {
            if (dialogPortraits[i].name.Contains(portraitName))
                return dialogPortraits[i];
        }

        return null;
    }
}
