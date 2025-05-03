using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public Transform target; // Typically your player
    public float distance = 5.0f;
    public float mouseSensitivity = 100f;
    public float verticalClamp = 80f;

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, 0, verticalClamp);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        if (target != null)
        {
            //fixes the the direction of the lizard to direction of camera
            //target.rotation = Quaternion.Euler(0f, yRotation, 0f);
            //distance between camera and controller
            Vector3 offset = transform.rotation * new Vector3(0, 0, -distance);
            transform.position = target.position + offset;
        }
    }
}
