using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClientStatus
{
    None,
    Satisfied,
    Dissatisfied,
    verySatisfied
}

public class Client : InteractableClientOrder
{
    [SerializeField]
    private SOClient _clientData;
    public SOClient ClientData { get { return _clientData; } }

    private ClientStatus _clientStatus;
    public ClientStatus ClientStatus { get { return _clientStatus; } }

    private Dictionary<ClientStatus, int> lastDialog;

    private bool _hasOrdered;
    private int _currencyGiven;

    public void Init(int value)
    {
        _hasOrdered = false;
        _currencyGiven = 0;
        _clientStatus = ClientStatus.None;

        lastDialog = new Dictionary<ClientStatus, int>();
        lastDialog.Add(ClientStatus.Satisfied, 1);
        lastDialog.Add(ClientStatus.Dissatisfied, 2);
        lastDialog.Add(ClientStatus.verySatisfied, 3);
    }

    public void Reset()
    {
        _hasOrdered = false;
        _currencyGiven = 0;
        _clientStatus = ClientStatus.None;
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
        GameManager.Instance.DialogManager.DialogStart(_clientData.firstDialog);

        else
        {
            int lastDialogNode = lastDialog[_clientStatus];
            GameManager.Instance.DialogManager.DialogStart(lastDialogNode);
        }
    }
}
