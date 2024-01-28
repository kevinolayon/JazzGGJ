using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClientSatisfaction : MonoBehaviour
{

    [Header("Events")]
    public GameEvent onClientSatisfactionInitializes;

    [Header("Events")]
    public GameEvent onClientSatisfactionChanges;

    [SerializeField]
    private int initialSatisfaction = 50;

    [SerializeField]
    private int maxSatisfaction = 100;

    private int currentSatisfaction;

    private void Awake()
    {
        currentSatisfaction = initialSatisfaction;
    }

    // Start is called before the first frame update
    void Start()
    {
        SatisfactionStruct initialSatisfactionData;
        initialSatisfactionData.InitialSatisfaction = initialSatisfaction;
        initialSatisfactionData.MaxSatisfaction = maxSatisfaction;

        onClientSatisfactionInitializes.Raise(this, initialSatisfactionData);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DecreaseSatisfaction(Random.Range(5, 20));
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            IncreaseSatisfaction(Random.Range(5, 20));
        }
    }

    public void HandleDecreaseSatisfaction(Component sender, object data)
    {
        if (data is int)
        {
            int amount = (int) data;
            DecreaseSatisfaction(amount);
        }
    }

    public void HandleIncreaseSatisfaction(Component sender, object data)
    {
        if (data is int)
        {
            int amount = (int) data;
            IncreaseSatisfaction(amount);
        }
    }

    private void DecreaseSatisfaction(int amount)
    {
        currentSatisfaction -= amount;
        currentSatisfaction = Mathf.Clamp(currentSatisfaction, 0, maxSatisfaction);

        onClientSatisfactionChanges.Raise(this, currentSatisfaction);
    }

    private void IncreaseSatisfaction(int amount)
    {
        currentSatisfaction += amount;
        currentSatisfaction = Mathf.Clamp(currentSatisfaction, 0, maxSatisfaction);

        onClientSatisfactionChanges.Raise(this, currentSatisfaction);
    }
}
