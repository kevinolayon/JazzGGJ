using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreContainer : MonoBehaviour
{
    public Image coin;
    public TextMeshProUGUI score;

    public void Init()
    {
        Reset();
    }

    public void Reset()
    {
        score.text = "";
    }

    public void UpdateScore(int value)
    {
        score.text = "$" + value;
    }
}
