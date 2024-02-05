using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// <<<<<<<<<<<<<<<<< Code just to switch between cameras during testing >>>>>>>>>>>>>>>>

public class SwitchCameras : MonoBehaviour
{
    [SerializeField]
    private GameObject isometricTopDownCamera;

    [SerializeField]
    private GameObject thirdPersonCamera;

    private bool isometricTopDownCameraState = true;
    private bool thirdPersonCameraState = false;

    // Start is called before the first frame update
    void Start()
    {
        isometricTopDownCamera.SetActive(isometricTopDownCameraState);
        thirdPersonCamera.SetActive(thirdPersonCameraState);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isometricTopDownCameraState = !isometricTopDownCameraState;
            thirdPersonCameraState = !thirdPersonCameraState;

            isometricTopDownCamera.SetActive(isometricTopDownCameraState);
            thirdPersonCamera.SetActive(thirdPersonCameraState);
        }
    }
}
