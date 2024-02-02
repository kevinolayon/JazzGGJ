using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeDialogs : MonoBehaviour
{
    public TextAsset dialogFile;
    public DialogNodes dialogNodes;
    public Sprite dialogPortraits;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Numlock))
        {
            Read();
        }
    }

    private void Read()
    {
        dialogNodes = JsonUtility.FromJson<DialogNodes>(dialogFile.text);

    }
}
