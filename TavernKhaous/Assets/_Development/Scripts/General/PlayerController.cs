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

    float horizontal;
    float vertical;

    bool isRotating;
    bool isMoving;

    float initialSpeed;
    Quaternion newRotation;

    private void Start()
    {
        initialSpeed = movementSpeed;
    }

    private void FixedUpdate()
    {
        Movement();
        Rotate();
    }

    private void Update()
    {
        Jump();
    }

    void Movement()
    {
        vertical = Input.GetAxis("Vertical"); // Get input to move

        //movementSpeed = isRotating ? movementSpeed / 2 : initialSpeed;

        isMoving = vertical != 0; // Toggle bool if is moving or not

        rb.AddForce(vertical * movementSpeed * rb.transform.forward); // Add force to movement the character
    }

    void Rotate()
    {
        horizontal = Input.GetAxis("Horizontal"); // Get input to rotate

        isRotating = horizontal != 0;  // Toggle bool if is rotating or not

        newRotation = Quaternion.Euler(0, -horizontal * rotationSpeed, 0); // Calculate the new rotation

        cj.targetRotation *= newRotation; // Apply rotation to the joint
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
