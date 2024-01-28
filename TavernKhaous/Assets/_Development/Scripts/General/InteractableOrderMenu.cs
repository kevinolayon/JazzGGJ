using UnityEngine;

public class InteractableOrderMenu : MonoBehaviour, IInteractable
{
    CanvasManager canvas;

    private void Start()
    {
        canvas = CanvasManager.Instance;
    }

    public void Interact()
    {
        canvas.ShowOrderMenu();
    }
}
