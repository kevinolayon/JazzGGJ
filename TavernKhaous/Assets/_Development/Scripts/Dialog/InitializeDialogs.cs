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
        dialogNodes = JsonUtils.Read<DialogNodes>(dialogFile);
        LoadPortraits();
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

    public Sprite GetPortrait(string portraitName)
    {
        for(int i = 0; i < dialogPortraits.Length; i++)
        {
            if (dialogPortraits[i].name.Contains(portraitName.ToLower()))
                return dialogPortraits[i];
        }

        return null;
    }

    public string CaptalizeFirstLeter(string name)
    {
        return char.ToUpper(name[0]) + name.Substring(1);
    }
}
