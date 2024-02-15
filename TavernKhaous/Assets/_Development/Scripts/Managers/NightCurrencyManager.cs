using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PointsType
{
    hitOrder,
    rightTime,
    hitSecretOrder,
    goodInteraction,
    neutralInteraction,
    badInteraction,
    wrongOrder,
    badTime
}

public class NightCurrencyManager
{
    private int _currentOrderScore;
    public Action<int> onUpdateCurrency;

    public void Int()
    {
        Reset();
    }

    public void Reset()
    { 
        _currentOrderScore = 0;
        UpdateUICurrency();
    }

    public void UpdateCurrency(int pts)
    {
        _currentOrderScore += pts;
        UpdateUICurrency();
    }

    public void UpdateUICurrency()
    {
        onUpdateCurrency?.Invoke(_currentOrderScore);
    }
}
