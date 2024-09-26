using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float mouseSens;
    public Transform playerTransform;
    private float mouseYRotation;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        mouseYRotation -= mouseY;
        mouseYRotation = Mathf.Clamp(mouseYRotation, -90, 90);

        transform.localEulerAngles=Vector3.right* mouseYRotation;




        playerTransform.Rotate(Vector3.up*mouseX);

    }
}
