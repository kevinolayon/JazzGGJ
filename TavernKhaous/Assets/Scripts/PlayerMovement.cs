using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// <<<<<<<<<<< CODE JUST FOR TESTING!! >>>>>>>>>>>>>>>>>

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        characterController.Move(new Vector3 (x, 0, z));
    }
}
