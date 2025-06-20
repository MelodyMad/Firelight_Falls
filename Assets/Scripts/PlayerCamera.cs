using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Mouse Variables
    [Header("Player View")]
    [SerializeField]
    private float xSensitivity = 800f;
    [SerializeField]
    private float ySensitivity = 800f;

    [SerializeField]
    private Transform orientation;

    private float xRotation;
    private float yRotation;
    [SerializeField]
    private float fieldOfView = 70f;

    private void Start()
    {
        // Set mouse to be locked in the game and to be invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Mouse Input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySensitivity;
        // Mouse Rotation
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -fieldOfView, fieldOfView);
        // Player Rotation
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
