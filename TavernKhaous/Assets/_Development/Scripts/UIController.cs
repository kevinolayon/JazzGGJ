using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
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

    public void SetDialogOptions(List<Option> options)
    {
        _dialogBox.SetOptions(options);
    }

    public void SelectOption(int option)
    {
        Debug.Log($"next dialog index: {option}");
        GameManager.Instance.DialogManager.ChangeToNextDialog(option);
    }

    public void HideOptions()
    {
        _dialogBox.HideDialogOptions();
    }

    public void UpdatePoints(int value)
    {
        _scoreContainer.UpdateScore(value);
    }
}
