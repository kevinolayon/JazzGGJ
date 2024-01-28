using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    private bool _isWriting;
    public bool IsWriting;

    [SerializeField]
    private float _timeBetweenwords = 0.03f;

    private char[] _dialogLetters;

    private TreeNode _currentNodeDialog;

    [SerializeField]
    private SOText dialogText;
    [SerializeField]
    private SOText _dialogName;

    public Action onStartDialog;
    public Action onEndDialog;
    public Action<List<Option>> onUpdateOptions;
    public Action onEnableNextButton;
    public Action<Sprite> onChangePortrait;

    private Coroutine _currentCoroutine;

    private bool _hasAnswered;
    private List<Option> _currentDialogOptions;

    public void Start()
    {
       
    }

    public void Init()
    {
        _currentDialogOptions = new List<Option>();
        _currentDialogOptions.Add(new Option());
        _currentDialogOptions.Add(new Option());
        _currentDialogOptions.Add(new Option());

        Reset();       
    }

    public void Reset()
    {
        _isWriting = false;
        _hasAnswered = false;

        _currentNodeDialog = null;

        ResetOptions();
    }

    private void ResetOptions()
    {
        for (int i = 0; i < _currentDialogOptions.Count; i++)
        {
            _currentDialogOptions[i].text = "";
            _currentDialogOptions[i].index = -1;
        }
    }

    public void DialogStart(TreeNode tree, string characterName)
    {
        Debug.Log("Dialog Start");

        _isWriting = true;
        _currentNodeDialog = tree;
        _dialogName.value = characterName;

        Write();
    }

    private void Write()
    {
        Debug.Log("Write");

        if (_currentCoroutine != null)
        {
            Debug.Log("Coroutine != null");
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(WriteCoroutine());
    }

    private  IEnumerator WriteCoroutine()
    {
        Debug.Log("Write Coroutine");
        onStartDialog.Invoke();

        while(_currentNodeDialog != null)
        {
            Debug.Log("_currentNodeDialog != null");

            _hasAnswered = false;
            _dialogLetters = _currentNodeDialog.data.ToCharArray();

            dialogText.value = "";

            ResetOptions();

            if (_currentNodeDialog.characterPortrait != null)
                onChangePortrait?.Invoke(_currentNodeDialog.characterPortrait);

            if (_currentNodeDialog.children.Count > 0)
                OnUpdateOptions(_currentNodeDialog.children);
            else
                onEnableNextButton?.Invoke();
                
            foreach (char letter in _dialogLetters)
            {
                dialogText.value = dialogText.value + letter;
                yield return new WaitForSeconds(_timeBetweenwords);
            }
   
            Debug.Log("waiting for answer...");
            yield return new WaitUntil(() => _hasAnswered || _currentNodeDialog == null);
            Debug.Log("answered");
        }     
    }

    private void OnUpdateOptions(List<TreeNode> answers)
    {
        Debug.Log("Set Node Answers");

        for (int i = 0; i < answers.Count; i++)
        {      
            _currentDialogOptions[i].text = "";
            _currentDialogOptions[i].text = answers[i].data;

            _currentDialogOptions[i].index = i;
            
            Debug.Log($"answers: {_currentDialogOptions[i].text}");
        }

        onUpdateOptions?.Invoke(_currentDialogOptions);
    }

    private void ChangeCurrentNode(int index)
    {
        if (_currentNodeDialog.children.Count > 0)
        {
            var choosedOption = _currentNodeDialog.children[index];

            if (choosedOption.children.Count > 0)
            {
                _currentNodeDialog = choosedOption.children[0];
                Debug.Log(_currentNodeDialog);

                _hasAnswered = true;
                Debug.Log("change node");
            }
            else
                OnEndDialog();
        }
        else
            OnEndDialog();             
    }

    public void ChangeToNextDialog(int index)
    {
        ChangeCurrentNode(index);
    }

    public void OnEndDialog()
    {
        _hasAnswered = false;
        _currentNodeDialog = null;

        StopCoroutine(WriteCoroutine());

        onEndDialog.Invoke();     
        _isWriting = false;
    }
}

public class Option
{
    public string text;
    public int index;
}
