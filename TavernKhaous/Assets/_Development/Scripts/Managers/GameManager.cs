using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private DialogManager _dialogManager;
    public DialogManager DialogManager { get { return _dialogManager; } }

    [SerializeField]
    private UIManager _uiController;
    public UIManager UIController { get { return _uiController; } }

    [SerializeField]
    public NightCurrencyManager _nightCurrentManager;
    public NightCurrencyManager ScoreManager { get { return _nightCurrentManager; } }

    public void Start()
    {
        Init();
    }

    private void Init()
    {
        DialogManager.Init();
        _nightCurrentManager = new NightCurrencyManager();
        _nightCurrentManager.Int();
    }

    public void Update()
    {
        #region Test PointsType
        if (Input.GetKeyDown(KeyCode.A))
        {
            _nightCurrentManager.UpdateCurrency(10);
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            _nightCurrentManager.UpdateCurrency(-10);
        }
        #endregion
    }
}
