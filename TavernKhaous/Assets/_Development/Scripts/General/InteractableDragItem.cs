using System;
using UnityEngine;

public class InteractableDragItem : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject objectToDrag;

    public static Action<GameObject> draggableObject;

    public void Interact()
    {
        draggableObject?.Invoke(objectToDrag);
    }
}
