using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    CanvasManager canvas;

    private void Start()
    {
        canvas = CanvasManager.Instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            canvas.ToggleImage();

            SceneManager.LoadScene(1);
        }
    }
}
