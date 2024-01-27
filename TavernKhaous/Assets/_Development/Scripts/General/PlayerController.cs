using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float jumpForce = 5f;

    [Header("References")]
    [SerializeField] Rigidbody rb;
    [SerializeField] ConfigurableJoint cj;

    bool isMoving;
    bool canWalk = true;
    bool canInteract = false;

    CanvasManager canvas;

    private void Start()
    {
        canvas = CanvasManager.Instance;        
    }

    private void OnEnable()
    {
        CanvasManager.enableWalk += CanWalk;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        Jump();
        Interact();
    }

    public void CanWalk(bool value)
    {
        canWalk = value;
        canInteract = value;
    }

    void Movement()
    {
        if (!canWalk) return;

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 dir = new Vector3(horizontal, 0, vertical).normalized;

        isMoving = dir.magnitude != 0;

        rb.AddForce(dir * movementSpeed, ForceMode.Impulse);

        if (dir != Vector3.zero)
        {
            Vector3 rotDir = dir;
            rotDir.x = -dir.x;
            Quaternion rotTarget = Quaternion.LookRotation(rotDir);
            cj.targetRotation = rotTarget;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Counter"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Counter"))
        {
            canInteract = false;
        }
    }

    void Interact()
    {
        if (!canInteract) return;

        if (Input.GetKeyDown(KeyCode.E))
            canvas.ShowOrderMenu();
    }
}
