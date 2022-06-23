using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{  
    [Header("Camera Options")]
    [SerializeField] float lookSensitivity;
    [SerializeField] float minCameraRotation;
    [SerializeField] float maxCameraRotation;
    [SerializeField] Transform rotationPoint;
    [SerializeField] bool invertX;
    [SerializeField] bool cursorLock;
    private float xRotation;


    // Update is called once per frame
    void LateUpdate()
    {
        CameraLogic();   
        CursorLock();

    }

    private void CursorLock()
    {
        if (cursorLock)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
    }

    void CameraLogic()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        transform.eulerAngles += Vector3.up * horizontal * lookSensitivity;

        if (invertX)
            xRotation += vertical * lookSensitivity;
        else
            xRotation -= vertical * lookSensitivity;

        xRotation = Mathf.Clamp(xRotation, minCameraRotation, maxCameraRotation);

        Vector3 clampedAngle = rotationPoint.eulerAngles;
        clampedAngle.x = xRotation;

        rotationPoint.eulerAngles = clampedAngle;
    }
}
