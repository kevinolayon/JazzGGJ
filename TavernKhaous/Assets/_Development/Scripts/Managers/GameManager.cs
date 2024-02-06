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
    private ClientSpawner _clientSpawner;
    public ClientSpawner ClientSpawner { get { return _clientSpawner; } }

    private NightCurrencyManager _nightCurrencyManager;
    public NightCurrencyManager NightCurrencyManager { get { return _nightCurrencyManager; } }

    private InitializeDialogs _initializeDialogs;
    public InitializeDialogs InitializeDialogs { get { return _initializeDialogs; } }

    public TextAsset dialogFile;

    [SerializeField]
    private LocalizationManager _localizationManager;
    public LocalizationManager LocalizationManager { get { return _localizationManager; } }

    public void Start()
    {
        Init();
    }

    private void Init()
    {
        _nightCurrencyManager = new NightCurrencyManager();
        _nightCurrencyManager.Int();

        _initializeDialogs = new InitializeDialogs();
        _initializeDialogs.Load(dialogFile);

        _localizationManager.Init();

        DialogManager.Init();
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
