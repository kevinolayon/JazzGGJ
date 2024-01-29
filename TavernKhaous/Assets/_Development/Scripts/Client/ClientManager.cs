using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager
{
    public Client[] _clients;

    public void Init()
    {
        _clients = new Client[GameManager.Instance.ClientSpawner.clientQtd];
        Debug.Log("qtd:" + GameManager.Instance.ClientSpawner.clientQtd);
    }

    public void AddClient(Client newClient, int index)
    {
        _clients[index] = newClient;
    }

    public void CompareOrder(int orderIndex)
    {
        
    }
}
