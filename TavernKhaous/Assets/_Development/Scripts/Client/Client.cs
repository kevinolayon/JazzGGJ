using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClientSatisfactionStatus
{
    None,
    Satisfied,
    Dissatisfied,
    verySatisfied
}

public class Client : InteractableClientOrder, IClient
{
    private SOClient _clientData;
    public SOClient ClientData { get { return _clientData; } }

    private ClientSatisfactionStatus _clientStatus;
    public ClientSatisfactionStatus ClientStatus { get { return _clientStatus; } set { _clientStatus = value; } }

    private Dictionary<ClientSatisfactionStatus, int> lastDialog;

    private bool _hasOrdered;
    private int _currencyGiven;
    private int _satisfactionPoints;

    public void Init(SOClient data)
    {
        Reset();

        _clientData = data;

        lastDialog = new Dictionary<ClientSatisfactionStatus, int>();
        lastDialog.Add(ClientSatisfactionStatus.Satisfied, _clientData.SatisfiedDialog);
        lastDialog.Add(ClientSatisfactionStatus.verySatisfied, _clientData.VerySatisfiedDialog);
        lastDialog.Add(ClientSatisfactionStatus.Dissatisfied, _clientData.DissatisfiedDialog);    
    }

    public void Reset()
    {
        _hasOrdered = false;
        _currencyGiven = 0;
        _satisfactionPoints = 0;
        _clientStatus = ClientSatisfactionStatus.None;
    }

    public void PayOrder()
    {
        GameManager.Instance.NightCurrencyManager.UpdateCurrency(_currencyGiven);
    }

    public void UpdateWallet(int value)
    {
        _currencyGiven += value;
    }

    private void CalculateClientStatus(int dialogPoints)
    {
        
    }

    public override void Interact()
    {
        if(!_hasOrdered)
        {
            GameManager.Instance.DialogManager.StartDialog(_clientData.firstDialogNode);
            _hasOrdered = true;
        }
        else
        {
            int lastDialogNode = lastDialog[_clientStatus];
            GameManager.Instance.DialogManager.StartDialog(lastDialogNode);
        }
    }
}
