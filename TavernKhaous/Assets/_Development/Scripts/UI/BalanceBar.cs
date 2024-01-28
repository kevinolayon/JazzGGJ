using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceBar : MonoBehaviour
{
    
    public Slider balanceBarFill;

    public void SetInitialMaxBalance(Component sender, object data)
    {
        if (data is int)
        {
            int balance = (int) data;

            balanceBarFill.maxValue = balance;
            balanceBarFill.minValue = 0;
            balanceBarFill.value = balance;
        }
    }

    public void UpdateBalance(Component sender, object data)
    {
        if (data is int)
        {
            int balance = (int) data;
            SetBalance(balance);
        }
    }

    private void SetBalance(int balance)
    {
        balanceBarFill.value = balance;
    }
}
