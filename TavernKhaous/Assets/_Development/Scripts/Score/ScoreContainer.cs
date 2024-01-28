using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreContainer : MonoBehaviour
{
    public Image coin;
    public TextMeshProUGUI score;
    public float timeBetweenPoints;

    public void Init()
    {
        Reset();
    }

    public void Reset()
    {
        score.text = "$0";
    }

    private void UpdateScore(int value)
    {
        score.text = "$" + value;
    }

    public void StartCoinAnimation(int value)
    {
        StartCoroutine(CoinAnimationCoroutine(value));
    }

    private IEnumerator CoinAnimationCoroutine(int value)
    {
        for(int i = 1; i <= value; i++)
        {
            UpdateScore(i);
            yield return new WaitForSeconds(timeBetweenPoints);
        }
    }
}
