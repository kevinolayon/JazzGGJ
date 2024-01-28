using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private DialogBox _dialogBox;

    [SerializeField]
    private ScoreContainer _scoreContainer;

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
        GameManager.Instance.ScoreManager.onUpdatePoints += UpdatePoints;

        DialogOption.onChooseOption += SelectOption;

        _dialogBox.Init();
        _scoreContainer.Init();
    }

    public void Reset()
    {
        _dialogBox.ResetFields();
        _scoreContainer.Reset();
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
        GameManager.Instance.ScoreManager.onUpdatePoints -= UpdatePoints;

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

    #endregion

    public void SelectOption(int option)
    {
        Debug.Log($"next dialog index: {option}");
        GameManager.Instance.DialogManager.ChangeToNextDialog(option);
    }

    #region Score
    public void UpdatePoints(int value)
    {
        _scoreContainer.StartCoinAnimation(value);
    }

    #endregion
}
