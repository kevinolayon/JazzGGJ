using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private DialogBox _dialogBox;

    [SerializeField]
    private CurrencyContainer _currencyContainer;

    public void Start()
    {
        Init();
    }

    public void Init()
    {
        GameManager.Instance.DialogManager.onStartDialog += OpenDialogBox;
        GameManager.Instance.DialogManager.onEndDialog += CloseDialogBox;
        GameManager.Instance.DialogManager.onUpdateOptions += SetDialogOptions;
        GameManager.Instance.DialogManager.onEnableNextButton += HideOptions;
        GameManager.Instance.NightCurrencyManager.onUpdateCurrency += UpdatePoints;
        GameManager.Instance.DialogManager.onChangePortrait += UpdatePortrait;

        DialogOption.onChooseOption += SelectOption;

        _dialogBox.Init();
        _currencyContainer.Init();
    }

    public void Reset()
    {
        _dialogBox.ResetFields();
        _currencyContainer.Reset();
    }

    public void OpenDialogBox()
    {
        _dialogBox.SetBoxVisibility(true);
    }

    public void CloseDialogBox()
    {
        _dialogBox.SetBoxVisibility(false);
    }

    private void OnDisable()
    {
        GameManager.Instance.DialogManager.onStartDialog -= OpenDialogBox;
        GameManager.Instance.DialogManager.onEndDialog -= CloseDialogBox;
        GameManager.Instance.DialogManager.onUpdateOptions -= SetDialogOptions;
        GameManager.Instance.DialogManager.onEnableNextButton -= HideOptions;
        GameManager.Instance.NightCurrencyManager.onUpdateCurrency -= UpdatePoints;
        GameManager.Instance.DialogManager.onChangePortrait -= UpdatePortrait;

        DialogOption.onChooseOption -= SelectOption;
    }

    #region DialogBox
    public void SetDialogOptions(List<Option> options)
    {
        _dialogBox.SetOptions(options);
    }

    public void HideOptions()
    {
        _dialogBox.HideDialogOptions();
    }

    public void UpdatePortrait(Sprite newPortrait)
    {
        _dialogBox.ChangePortrait(newPortrait);
    }

    #endregion

    public void SelectOption(int option)
    {
        Debug.Log($"next dialog index: {option}");
        GameManager.Instance.DialogManager.ChangeToNextDialog(option);
    }

    #region Score
    public void UpdatePoints(int value)
    {
        _currencyContainer.StartCoinAnimation(value);
    }

    #endregion
}
