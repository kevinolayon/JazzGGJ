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
    private SOText _dialogText;
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
    private int _dialogIndex;

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
        _dialogIndex = 0;
        _dialogName.value = "";
        _dialogText.value = "";

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

    public void DialogStart(TreeNode tree)
    {
        Debug.Log("Dialog Start");
        _isWriting = true;
        _currentNodeDialog = tree;

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

            _dialogName.value = "";
            _dialogText.value = "";

            if (_currentNodeDialog.normalDialogs.Count > 0 && _dialogIndex < _currentNodeDialog.normalDialogs.Count)
            {      
                _dialogLetters = _currentNodeDialog.normalDialogs[_dialogIndex].data.ToCharArray();
                _dialogName.value = _currentNodeDialog.normalDialogs[_dialogIndex].name;

                if (_currentNodeDialog.normalDialogs[_dialogIndex].characterPortrait != null)
                    onChangePortrait?.Invoke(_currentNodeDialog.normalDialogs[_dialogIndex].characterPortrait);

                _dialogIndex++;

            }
            else
            {
                _dialogIndex = 0;

                if (_currentNodeDialog.dialogData.characterPortrait != null)
                    onChangePortrait?.Invoke(_currentNodeDialog.dialogData.characterPortrait);

                else
                    onChangePortrait?.Invoke(null);

                _dialogLetters = _currentNodeDialog.dialogData.data.ToCharArray();
                _dialogName.value = _currentNodeDialog.dialogData.name;
            }
   
            ResetOptions();

            if (_currentNodeDialog.children.Count > 0 && _dialogIndex == 0)
                OnUpdateOptions(_currentNodeDialog.children);

            else
                onEnableNextButton?.Invoke();
                
            foreach (char letter in _dialogLetters)
            {
                _dialogText.value = _dialogText.value + letter;
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
            _currentDialogOptions[i].text = answers[i].dialogData.data;

            _currentDialogOptions[i].index = i;     
            Debug.Log($"answers: {_currentDialogOptions[i].text}");
        }

        onUpdateOptions?.Invoke(_currentDialogOptions);
    }

    private void ChangeCurrentNode(int index)
    {
        if (_currentNodeDialog.children.Count > 0 && _currentNodeDialog.normalDialogs.Count != 0)
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
        {
            if (_currentNodeDialog.normalDialogs.Count != 0 && _dialogIndex < _currentNodeDialog.normalDialogs.Count && !_currentNodeDialog.isLastNode)
                _hasAnswered = true;
            
            else
            {
                if(_currentNodeDialog.isLastNode)
                {
                    OnEndDialog();
                }
            }          
        }                      
    }

    public void ChangeToNextDialog(int index)
    {
        ChangeCurrentNode(index);
    }

    public void OnContinueDialog()
    {
        _hasAnswered = true;
    }

    public void OnEndDialog()
    {
        _hasAnswered = false;
        _currentNodeDialog = null;
        _dialogIndex = 0;

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
