using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreContainer : MonoBehaviour
{
    public Image coin;
    public TextMeshProUGUI score;
    public TextMeshProUGUI scoreSimbol;

    public float timeBetweenPoints;
  
    private int _currentScore;
    private int _newValue;

    private bool _isPositiveValue;

    public void Init()
    {
        Reset();
    }

    public void Reset()
    {
        scoreSimbol.text = "$";
        score.text = "0";
        _currentScore = 0;
    }

    private void UpdateScore(int value)
    {
        score.text = value.ToString();
    }

    public void StartCoinAnimation(int value)
    {
        _newValue = _currentScore;

        if (value < _currentScore)
            _isPositiveValue = false;

        else  
            _isPositiveValue = true;

        _newValue = value;

        StartCoroutine(CoinAnimationCoroutine(_isPositiveValue, value));
    }

    private IEnumerator CoinAnimationCoroutine(bool isPositiveValue, int newValue)
    {
        if(isPositiveValue)
        {
            for (int i = _currentScore; i <= newValue; i++)
            {
                UpdateScore(i);
                yield return new WaitForSeconds(timeBetweenPoints);
            }
        }
        else
        {
            for (int i = (int)_currentScore; i >= _newValue; i--)
            {
                UpdateScore(i);
                yield return new WaitForSeconds(timeBetweenPoints);
            }
        }

        _currentScore = newValue;
    }
}
