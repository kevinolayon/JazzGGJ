using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private DialogManager _dialogManager;
    public DialogManager DialogManager { get { return _dialogManager; } }

    [SerializeField]
    private UIController _uiController;
    public UIController UIController { get { return _uiController; } }

    [SerializeField]
    public ScoreManager _scoreManager;
    public ScoreManager ScoreManager { get { return _scoreManager; } }

    [SerializeField]
    private SOPoints scoreGuide;

    public void Start()
    {
        Init();
    }

    private void Init()
    {
        DialogManager.Init();
        _scoreManager = new ScoreManager(scoreGuide);
    }
}
