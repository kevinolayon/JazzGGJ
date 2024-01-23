using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private DialogManager _dialogManager;
    public DialogManager DialogManager { get { return _dialogManager; } }

    public void Start()
    {
        
    }

    public void Init()
    {
        _dialogManager = new DialogManager();
    }
}
