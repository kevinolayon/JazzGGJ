using System;
using UnityEngine;

public class InteractableDragItem : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject objectToDrag;
    [SerializeField] GameObject spawnVfx;

    public static Action<GameObject, GameObject> draggableObject;

    public void Interact()
    {
        draggableObject?.Invoke(objectToDrag, spawnVfx);
    }
}
