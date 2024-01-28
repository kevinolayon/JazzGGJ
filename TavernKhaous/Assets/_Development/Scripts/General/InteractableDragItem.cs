using System;
using UnityEngine;

public class InteractableDragItem : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject objectToDrag;
    [SerializeField] GameObject spawnVfx;

    public static Action<GameObject, GameObject> draggableObject;
    bool canDrag;

    public void Interact()
    {
        if (!canDrag) return;
        draggableObject?.Invoke(objectToDrag, spawnVfx);
    }

    private void OnEnable()
    {
        CanvasManager.enableDrag += EnableDrag;
    }

    void EnableDrag(bool value)
    {
        canDrag = true;
    }
}
