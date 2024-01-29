using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBalance : MonoBehaviour
{
    public int initialBalance = 100;
    PlayerController player;

    [Header("Events")]
    public GameEvent onPlayerBalanceChanges;

    [Header("Events")]
    public GameEvent onPlayerBalanceInitializes;

    [SerializeField]
    private float decreasingBalanceCooldown = 1f;

    [SerializeField]
    private int continuousBalanceDecreaseAmount = 1;

    [SerializeField]
    private int continuousBalanceDecreaseMultiplier = 1;

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
        player = GetComponent<PlayerController>();
        //onPlayerBalanceInitializes.Raise(this, currentBalance);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (other.TryGetComponent<IBreakBalance>(out IBreakBalance obs))
            {
                currentBalance -= obs.Damage();
            }
        }
    }

    void StartBalance()
    {
        onPlayerBalanceInitializes.Raise(this, currentBalance);
    }

    private void OnEnable()
    {
        DialogManager.onEndDialog += StartBalance;
    }

    private void OnDisable()
    {
        DialogManager.onEndDialog -= StartBalance;
    }

    private void Update()
    {
        // Just to test if methods are working. Ideally 'DecreaseBalance' and 'ResetBalace' should be called by events
        // through 'HandleDecreaseBalance' and 'ResetBalance'
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            int decreaseAmount = Random.Range(5, 25);
            DecreaseBalance(decreaseAmount);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetBalance();
        }*/

        if (currentBalance <= 0)
            StartCoroutine("ReloadScene");
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("Game");
    }

    public void HandleDecreaseBalance(Component sender, object data)
    {
        // If the event did not have a multiplier
        if (data is int)
        {
            int amount = (int)data;
            DecreaseBalance(amount);
        }
        // If the event did have a multiplier (in this case it should send the values as a BalaceStruct)
        else if (data is BalanceStruct)
        {
            BalanceStruct balanceValues = (BalanceStruct)data;
            DecreaseBalance(balanceValues.Amount, balanceValues.Multiplier);
        }
    }

    public void ResetBalance()
    {
        currentBalance = initialBalance;
        onPlayerBalanceChanges.Raise(this, currentBalance);
    }

    public void HandleSetContinuousBalanceDecreaseMultiplier(Component sender, object data)
    {
        if (data is int)
        {
            // We could add some validation to see if the multplier value received is reasonable

            int value = (int)data;
            SetContinuousBalanceDecreaseMultiplier(value);
        }
    }

    IEnumerator ContinuallyDecreaseBalance(int amount)
    {
        while (true)
        {
            if (currentBalance > 0)
            {
                DecreaseBalance(amount, continuousBalanceDecreaseMultiplier);
            }

            yield return waitForDecrease;
        }
    }

    private void DecreaseBalance(int amount, int multiplier = 1)
    {
        currentBalance = currentBalance - (amount * multiplier);
        currentBalance = Mathf.Clamp(currentBalance, 0, initialBalance);

        onPlayerBalanceChanges.Raise(this, currentBalance);
    }

    private void SetContinuousBalanceDecreaseMultiplier(int value)
    {
        continuousBalanceDecreaseMultiplier = value;
    }
}
