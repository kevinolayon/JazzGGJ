using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField]
    private SOText _dialogText;

    [SerializeField]
    private SOText _dialogName;

    [SerializeField]
    private float _timeBetweenwords = 0.03f;

    private char[] _dialogLetters;

    private Node _currentNodeDialog;

    private Sprite _nodePortrait;
  
    private bool _isWriting;
    public bool IsWriting { get { return _isWriting; } }

    public Action onStartDialog;
    public Action onEndDialog;
    public Action<List<Option>> onUpdateOptions;
    public Action onEnableNextButton;
    public Action<Sprite> onChangePortrait;
    public Action<int> onSendDialogPoints;

    private Coroutine _currentCoroutine;

    private int _nextNode;
    private int _currentAnswer;

    private bool _hasAnswered;
    private List<Option> _currentDialogOptions;
    private int _dialogIndex;
    private int _dialogPoints;
    private bool _hasReadBrachDialogData;

    private InitializeDialogs _dialogReference;

    public void Start()
    {
       
    }

    public void Init()
    {
        _dialogReference = GameManager.Instance.InitializeDialogs;

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
        _hasReadBrachDialogData = false;
        _dialogPoints = 0;
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

    public void StartDialog(int startNode)
    {
        _isWriting = true;
        _currentNodeDialog = _dialogReference.dialogNodes.nodes[startNode];
        _dialogPoints = 0;

        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(WriteCoroutine());
    }   

    private  IEnumerator WriteCoroutine()
    {
        onStartDialog.Invoke();

        while(_currentNodeDialog != null)
        {
            _hasAnswered = false;

            _dialogName.value = "";
            _dialogText.value = "";

            if (_currentNodeDialog.normalDialogs.Length > 0 && _dialogIndex < _currentNodeDialog.normalDialogs.Length)
            {
                UpdateDialog(_currentNodeDialog.normalDialogs[_dialogIndex].dialog.ToCharArray(), _currentNodeDialog.normalDialogs[_dialogIndex].nodePortrait);
                ChangePortrait();

                _dialogIndex++;

                onEnableNextButton?.Invoke();
                _hasReadBrachDialogData = false;
            }
            else
            {
                _dialogIndex = 0;

                if (_currentNodeDialog.nextNode == -1 && _currentNodeDialog.answers.Length == 0)
                    OnEndDialog();

                else
                {
                    UpdateDialog(_currentNodeDialog.normalDialogs[_dialogIndex].dialog.ToCharArray(), _currentNodeDialog.normalDialogs[_dialogIndex].nodePortrait);
                    ResetOptions();
                    OnUpdateOptions(_currentNodeDialog.answers);

                    //_nextNode = _currentNodeDialog.answers[_currentAnswer].nodeLinkID;
                    //_dialogPoints += _currentNodeDialog.answers[_currentAnswer].point;

                    _hasReadBrachDialogData = true;

                    _isWriting = true;

                    foreach (char letter in _dialogLetters)
                    {
                        _dialogText.value = _dialogText.value + letter;
                        yield return new WaitForSeconds(_timeBetweenwords);
                    }

                    _isWriting = false;

                    Debug.Log("waiting for answer...");
                    yield return new WaitUntil(() => _hasAnswered || _currentNodeDialog == null);
                    Debug.Log("answered");
                }
            }
        }     
    }

    private void OnUpdateOptions(Answer[] answers)
    {
        for (int i = 0; i < answers.Length; i++)
        {      
            _currentDialogOptions[i].text = "";
            _currentDialogOptions[i].text = answers[i].answer;

            _currentDialogOptions[i].index = i;     
        }

        onUpdateOptions?.Invoke(_currentDialogOptions);
    }

    //private void ChangeCurrentNode(int index)
    //{
    //    if (_currentNodeDialog.children.Count > 0)
    //    {
    //        var choosedOption = _currentNodeDialog.children[index];

    //        if (choosedOption.children.Count > 0)
    //        {
    //            if (choosedOption.normalDialogs.Count != 0)
    //            {
    //                _currentNodeDialog = choosedOption;
    //            }
    //            else
    //            {
    //                _currentNodeDialog = choosedOption.children[0];
    //                Debug.Log(_currentNodeDialog);
    //            }

    //            _hasAnswered = true;
    //            Debug.Log("change node");
    //        }
    //        else
    //            OnEndDialog();
    //    }
    //    else
    //    {
    //        if(_currentNodeDialog.normalDialogs.Count != 0)
    //        {
    //            if (_dialogIndex < _currentNodeDialog.normalDialogs.Count && !_currentNodeDialog.isLastNode)
    //                _hasAnswered = true;

    //            else
    //                OnEndDialog();
    //        }       
    //        else
    //        {
    //            if(_currentNodeDialog.isLastNode)
    //            {
    //                OnEndDialog();
    //            }
    //        }          
    //    }                      
    //}

    //public void ChangeToNextDialog(int index)
    //{
    //    ChangeCurrentNode(index);
    //}

    ////Used for normal dialog
    //public void OnContinueDialog()
    //{
    //    if(!_isWriting)
    //    {
    //        if (_currentNodeDialog.normalDialogs.Count > 0)
    //        {
    //            if(_dialogIndex >= _currentNodeDialog.normalDialogs.Count)
    //            {
    //                if (_hasReadBrachDialogData)
    //                    OnEndDialog();

    //                else
    //                    _hasAnswered = true;
    //            }
    //            else
    //                _hasAnswered = true;
    //        }           
    //        else if(_hasReadBrachDialogData)
    //        {
    //            OnEndDialog();
    //        }
    //    } 
    //}

    public void OnEndDialog()
    {
        _hasAnswered = false;
        _currentNodeDialog = null;
        _dialogIndex = 0;
        _hasReadBrachDialogData = false;

        StopCoroutine(WriteCoroutine());

        onSendDialogPoints?.Invoke(_dialogPoints);
        onEndDialog.Invoke();     
        _isWriting = false;
    }

    private void ChangePortrait()
    {
        _nodePortrait = _dialogReference.GetPortrait(_dialogName.ToString());

        if (_nodePortrait != null)
            onChangePortrait?.Invoke(_nodePortrait);
    }

    private void UpdateDialog(char[] dialog, string portraitName)
    {
        _dialogLetters = dialog;
        _dialogName.value = portraitName;
    }
}

public class Option
{
    public string text;
    public int index;
}
