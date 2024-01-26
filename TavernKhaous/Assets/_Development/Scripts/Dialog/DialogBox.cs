using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialog;
    public Button nextButton;

    public Image img;

    public SOText dialogText;
    public SOText dialogName;

    [SerializeField]
    private DialogOption[] _options;

    public void Init()
    {
        SetBoxVisibility(false);
        ResetFields();
    }

    public void SetBoxVisibility(bool isVisible)
    {
        this.gameObject.SetActive(isVisible);
        img.gameObject.SetActive(isVisible);

        if(isVisible)
        {
            EnableDialogOptions(true);
            nextButton.interactable = true;
        }          
        else
        {
            EnableDialogOptions(false);
            nextButton.interactable = false;
        }
           

    }

    public void Update()
    {
        if(dialogText.value != "")
            dialog.text = dialogText.value;

        if(dialogName.value != "")
            characterName.text = dialogName.value;
    }

    private void ResetFields()
    {
        dialogName.value = "";
        characterName.text = dialogName.value;

        dialogText.value = "";
        dialog.text = dialogText.value;

        img.gameObject.SetActive(false);

        ResetOptions();

        EnableDialogOptions(false);
    }

    private void ResetOptions()
    {
        if(_options.Length > 0)
        {
            for (int i = 0; i < _options.Length; i++)
            {
                _options[i].Reset();
            }
        }
    }

    private void EnableDialogOptions(bool enable)
    {
        if (_options.Length > 0)
        {
            for (int i = 0; i < _options.Length; i++)
            {
                _options[i].EnableOption(enable);
            }
        }
    }

    public void SetOptions(List<Option> options)
    {
        for(int i = 0; i < _options.Length; i++)
        {
            _options[i].SetText(options[i].text);
            _options[i].SetIndex(options[i].index);
        }
    }
}
