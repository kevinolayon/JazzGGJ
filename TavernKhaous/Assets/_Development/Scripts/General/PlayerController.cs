using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float timeToStable = 1;
    public Vector2 Direction;

    [Header("References")]
    [SerializeField] Transform bowlSocket;
    [SerializeField] ConfigurableJoint rLegJoint;
    [SerializeField] ConfigurableJoint lLegJoint;

    Rigidbody rb;
    ConfigurableJoint cj;

    [SerializeField] bool dragging;
    [SerializeField] bool isMoving;
    [SerializeField] bool canWalk = true;
    [SerializeField] bool canInteract = true;

    Coroutine legRoutine;
    List<IInteractable> interactables = new();

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cj = GetComponent<ConfigurableJoint>();
    }

    private void OnEnable()
    {
        CanvasManager.enableWalk += DisablePlayer;
        InteractableDragItem.draggableObject += DragItem;
    }

    private void OnDisable()
    {
        CanvasManager.enableWalk -= DisablePlayer;
        InteractableDragItem.draggableObject -= DragItem;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void DisablePlayer(bool value)
    {
        canWalk = value;
        canInteract = value;
    }

    void Movement()
    {
        if (!canWalk) return;

        Vector3 dir = new Vector3(Direction.x, 0, Direction.y).normalized;

        isMoving = dir.magnitude != 0;

        rb.AddForce(dir * movementSpeed, ForceMode.Impulse);

        if (isMoving && legRoutine == null)
        {
            legRoutine = StartCoroutine("LegAnimation");
        }
        if (isMoving)
        {
            Vector3 rotDir = dir;
            rotDir.x = -dir.x;
            Quaternion rotTarget = Quaternion.LookRotation(rotDir);
            cj.targetRotation = rotTarget;
        }
        else if (legRoutine != null)
        {
            StopCoroutine(legRoutine);
            legRoutine = null;
            lLegJoint.targetRotation = Quaternion.identity;
            rLegJoint.targetRotation = Quaternion.identity;
        }
    }

    IEnumerator LegAnimation()
    {
        while (isMoving)
        {
            lLegJoint.targetRotation = Quaternion.Euler(0, 0, 33);
            rLegJoint.targetRotation = Quaternion.Euler(0, 0, 33);

            yield return new WaitForSeconds(0.3f);

            lLegJoint.targetRotation = Quaternion.Euler(0, 0, -33);
            rLegJoint.targetRotation = Quaternion.Euler(0, 0, -33);

            yield return new WaitForSeconds(.3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            interactables.Add(interactable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            interactables.Remove(interactable);
        }
    }

    public void Interact()
    {
        if (canInteract && interactables.Count > 0)
        {
            interactables[0].Interact();
        }
    }

    void DragItem(GameObject item, GameObject vfx)
    {
        if (dragging) return;
        dragging = true;
        Instantiate(item, bowlSocket);
        Instantiate(vfx, bowlSocket.position, Quaternion.identity);
    }

    public void ReleaseItem()
    {
        dragging = false;
        Destroy(bowlSocket.GetChild(0).gameObject);
    }
}
