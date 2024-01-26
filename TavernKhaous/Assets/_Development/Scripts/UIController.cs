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
        GameManager.Instance.DialogManager.onDialogStart += OpenDialogBox;
        GameManager.Instance.DialogManager.onDialogEnd += CloseDialogBox;
        GameManager.Instance.DialogManager.onSendDialogOptions += SetDialogOptions;

        DialogOption.onChooseOption += NextDialog;

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
        GameManager.Instance.DialogManager.onDialogStart -= OpenDialogBox;
        GameManager.Instance.DialogManager.onDialogEnd -= CloseDialogBox;
        GameManager.Instance.DialogManager.onSendDialogOptions -= SetDialogOptions;
    }

    public void SetDialogOptions(List<Option> options)
    {
        _dialogBox.SetOptions(options);
    }

    public void NextDialog(int option)
    {
        Debug.Log($"next dialog index: {option}");
        GameManager.Instance.DialogManager.ChangeToNextDialog(option);
    }
}
