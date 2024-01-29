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
    private NightCurrencyManager _nightCurrencyManager;
    public NightCurrencyManager NightCurrencyManager { get { return _nightCurrencyManager; } }

    [SerializeField]
    private ClientSpawner _clientSpawner;
    public ClientSpawner ClientSpawner { get { return _clientSpawner; } }

    private ClientManager _clientManager;
    public ClientManager ClientManager { get { return _clientManager; } }

    public void Start()
    {
        Init();
    }

    private void Init()
    {
        DialogManager.Init();

        _nightCurrencyManager = new NightCurrencyManager();
        _nightCurrencyManager.Int();

        _clientManager = new ClientManager();
        _clientManager.Init();
    }

    public void Update()
    {
        #region Test PointsType
        if (Input.GetKeyDown(KeyCode.A))
        {
            _nightCurrencyManager.UpdateCurrency(10);
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            _nightCurrencyManager.UpdateCurrency(-10);
        }
        #endregion
    }
}
