using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private DialogBox _dialogBox;

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
}
