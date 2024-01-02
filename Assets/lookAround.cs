using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAround : MonoBehaviour
{
    public float zoomSpeed = 2.0f;
    public float rotationSpeed = 2.0f;

    private bool isRotating = false;
    private Vector3 dragOrigin;

    private void Update()
    {
        // Zooming
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        Zoom(scrollWheel);

        // Rotating
        if (Input.GetMouseButtonDown(0))
        {
            StartRotation();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopRotation();
        }

        if (isRotating)
        {
            Rotate();
        }
    }

    void Zoom(float zoomInput)
    {
        // Adjust the camera's field of view based on the zoom input
        Camera.main.fieldOfView += zoomInput * zoomSpeed;

        // Optionally, you can add clamping to prevent extreme zoom values
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 20f, 80f);
    }

    void StartRotation()
    {
        isRotating = true;
        dragOrigin = Input.mousePosition;
    }

    void StopRotation()
    {
        isRotating = false;
    }

    void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the motorcycle around its own Y axis based on the horizontal mouse input
        transform.Rotate(Vector3.up * mouseX * rotationSpeed);

        // Rotate the motorcycle around its own X axis based on the vertical mouse input
        transform.Rotate(Vector3.left * mouseY * rotationSpeed);
    }
}
