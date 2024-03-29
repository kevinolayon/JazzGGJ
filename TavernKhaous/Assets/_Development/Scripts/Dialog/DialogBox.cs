using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogBox : MonoBehaviour
{
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialog;
    public Button nextButton;

    public Image dialogBackground;
    public Image portrait;

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
        ResetFields();

        this.gameObject.SetActive(isVisible);
        dialogBackground.gameObject.SetActive(isVisible);
        portrait.enabled = isVisible;
    }

    public void EnableNextButton(bool enable)
    {
        nextButton.interactable = enable;
    }

    public void HideDialogOptions()
    {
        ResetOptions();
        EnableDialogOptions(false);

        EnableNextButton(true);     
    }

    public void Update()
    {
        if(dialogText.value != "")
            dialog.text = dialogText.value;

        if(dialogName.value != "")
            characterName.text = dialogName.value;
    }

    public void ResetFields()
    {
        dialogName.value = "";
        characterName.text = dialogName.value;

        dialogText.value = "";
        dialog.text = dialogText.value;

        dialogBackground.gameObject.SetActive(false);

        EnableNextButton(false);

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

    public void ChangePortrait(Sprite sprite)
    {
        portrait.sprite = sprite;
    }

    public void SetOptions(List<Option> options)
    {
        ResetOptions();

        for (int i = 0; i < _options.Length; i++)
        {           
            if(options[i].text == "")
                _options[i].EnableOption(false);

            else
            {
                _options[i].SetText(options[i].text);
                _options[i].SetIndex(options[i].index);
                _options[i].EnableOption(true);
            }          
        }           
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        float value;
        SoundManager.Instance.audioMixer.GetFloat("volume", out value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("click"), Vector3.zero, value);
        throw new System.NotImplementedException();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        float value;
        SoundManager.Instance.audioMixer.GetFloat("volume", out value);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.GetSFXByName("click"), Vector3.zero, value);
        throw new System.NotImplementedException();
        
    }
}
