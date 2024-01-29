using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    public Transform parent;
    public Client [] clients;
    public int clientQtd;
    public Transform clientLocation;

    private int _index;

    public void Init()
    {
        clients = new Client[clientQtd];
        _index = 0;
    }

    public void Spawn(int index)
    {
        var spawnedObject = Instantiate(clients[index].gameObject, parent);

        if(spawnedObject != null)
        {
            spawnedObject.transform.localPosition = clientLocation.localPosition;
            Client newClient = spawnedObject.GetComponent<Client>();

            if (newClient != null)
            {
                newClient.Init(_index);
                GameManager.Instance.ClientManager.AddClient(newClient, index);
            }         
        }

        _index++;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Spawn(0);
        }    
    }
}
