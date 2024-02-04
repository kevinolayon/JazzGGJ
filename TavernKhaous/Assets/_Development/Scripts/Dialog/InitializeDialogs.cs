using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeDialogs : MonoBehaviour
{
    public TextAsset dialogFile;

    [SerializeField]
    public DialogNodes dialogNodes;
    [SerializeField]
    public Sprite [] dialogPortraits;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Numlock))
        {
            Read();
        }
    }

    public void Load()
    {
        Read();
        LoadPortraits();
    }

    private void Read()
    {
        dialogNodes = JsonUtility.FromJson<DialogNodes>(dialogFile.text);
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
