using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void OnMove(InputValue value)
    {
        playerController.Direction = value.Get<Vector2>();
    }

    public void OnInteract()
    {
        playerController.Interact();
    }
}
