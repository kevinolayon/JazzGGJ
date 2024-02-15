using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    public class ClientWrapper
    {
        public SOClient clientData;
        public GameObject model;
    }

    public Queue<ClientWrapper> clients;
    public Transform parent;
    public Transform clientLocation;

    private ClientWrapper currentClient;

    public void Spawn()
    {
        if(clients.Count > 0)
        {
            currentClient = clients.Dequeue();

            var spawnedObject = Instantiate(currentClient.model, parent);

            if (spawnedObject != null)
            {
                spawnedObject.transform.localPosition = clientLocation.localPosition;
                Client newClient = spawnedObject.GetComponent<Client>();

                if (newClient != null)
                {
                    newClient.Init(currentClient.clientData);
                }
            }
        }      
    }

    public void Reset()
    {
        clients.Clear();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Spawn();
        }    
    }
}


