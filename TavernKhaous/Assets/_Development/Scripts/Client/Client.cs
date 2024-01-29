using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : InteractableClientOrder
{
    [SerializeField]
    private SOClient _clientData;
    public SOClient ClientData { get { return _clientData; } }

    [SerializeField]
    private SODialog _firstDialog;

    [SerializeField]
    private SODialog _lastDialog;

    private bool _hasOrdered;
    private int _currencyGiven;

    private int _clientIndex;
    public int ClientIndex { get { return _clientIndex; } set { _clientIndex = value; } }

    public void Init(int value)
    {
        _hasOrdered = false;
        _currencyGiven = 0;
        _clientIndex = value;
    }

    public void Reset()
    {
        _hasOrdered = false;
        _currencyGiven = 0;
        _clientIndex = 0;
    }

    public void SetIndex(int value)
    {
        _clientIndex = value;
    }

    public void PayOrder()
    {
        GameManager.Instance.NightCurrencyManager.UpdateCurrency(_currencyGiven);
    }

    public void UpdateWallet(int value)
    {
        _currencyGiven += value;
    }

    public override void Interact()
    {
        // Call dialog
        if(!_hasOrdered)
        GameManager.Instance.DialogManager.DialogStart(_firstDialog.root);

        else
            GameManager.Instance.DialogManager.DialogStart(_lastDialog.root);
    }
}
