using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyContainer : MonoBehaviour
{
    public Image coin;
    public TextMeshProUGUI currency;
    public TextMeshProUGUI currencySimbol;

    public float timeBetweenPoints;
  
    private int _currentCurrency;
    private int _newValue;

    private bool _isPositiveValue;

    public void Init()
    {
        Reset();
    }

    public void Reset()
    {
        currencySimbol.text = "$";
        currency.text = "0";
        _currentCurrency = 0;
    }

    private void UpdateScore(int value)
    {
        currency.text = value.ToString();
    }

    public void StartCoinAnimation(int value)
    {
        _newValue = _currentCurrency;

        if (value < _currentCurrency)
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
            for (int i = _currentCurrency; i <= newValue; i++)
            {
                UpdateScore(i);
                yield return new WaitForSeconds(timeBetweenPoints);
            }
        }
        else
        {
            for (int i = (int)_currentCurrency; i >= _newValue; i--)
            {
                UpdateScore(i);
                yield return new WaitForSeconds(timeBetweenPoints);
            }
        }

        _currentCurrency = newValue;
    }
}
