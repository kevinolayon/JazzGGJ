using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClient
{
    public ClientSatisfactionStatus ClientStatus { get; set; }

    public void Init(SOClient data);
    public void Reset();
    public void PayOrder();
    public void UpdateWallet(int value);
}
