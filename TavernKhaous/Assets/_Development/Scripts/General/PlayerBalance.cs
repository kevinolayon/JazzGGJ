using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBalance : MonoBehaviour
{
    public int initialBalance = 100;

    [Header("Events")]
    public GameEvent onPlayerBalanceChanges;

    [Header("Events")]
    public GameEvent onPlayerBalanceInitializes;

    [SerializeField]
    private float decreasingBalanceCooldown = 1f;

    [SerializeField]
    private int continuousBalanceDecreaseAmount = 1;

    private int currentBalance;
    private WaitForSeconds waitForDecrease;

    void Awake()
    {
        currentBalance = initialBalance;
        waitForDecrease = new WaitForSeconds(decreasingBalanceCooldown);

        StartCoroutine(ContinuallyDecreaseBalance(continuousBalanceDecreaseAmount));
    }

    private void Start()
    {
        onPlayerBalanceInitializes.Raise(this, currentBalance);
    }

    private void Update()
    {
        // Just to test if methods are working. Ideally 'DecreaseBalance' and 'ResetBalace' should be called by events!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int decreaseAmount = Random.Range(5, 25);
            DecreaseBalance(decreaseAmount);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetBalance();
        }
    }

    IEnumerator ContinuallyDecreaseBalance(int amount)
    {
        while (true)
        {
            if (currentBalance > 0)
            {
                currentBalance -= amount;
                onPlayerBalanceChanges.Raise(this, currentBalance);
            }

            yield return waitForDecrease;
        }
    }

    void DecreaseBalance(int amount, int multiplier = 1)
    {
        currentBalance = currentBalance - (amount * multiplier);
        currentBalance = Mathf.Clamp(currentBalance, 0, initialBalance);

        onPlayerBalanceChanges.Raise(this, currentBalance);
    }

    void ResetBalance()
    {
        currentBalance = initialBalance;
        onPlayerBalanceChanges.Raise(this, currentBalance);
    }
}
