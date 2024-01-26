using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DialogOption : MonoBehaviour
{
    private int optionIndex;
    public int OptionIndex { get { return optionIndex; } }

    [SerializeField]
    private TextMeshProUGUI text;

    public static Action<int> onChooseOption;

    public void Init()
    {
        Reset();
    }

    public void Reset()
    {
        SetText("");
        SetIndex(-1);
    }

    public void SetText(string optionText)
    {
        text.text = optionText;
    }

    public void SetIndex(int index)
    {
        optionIndex = index;
    }

    public void SendOptionIndex()
    {
        onChooseOption?.Invoke(optionIndex);
    }

    public void EnableOption(bool enable)
    {
        this.gameObject.SetActive(enable);
    }
}
