using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class PlayerMovementCC : MonoBehaviour
{
    public float speed, runningSpeed, mouseX, mouseSens, gravityScale, jumpforce;
    //private bool jumpPressed;
    private Vector3 auxmovementVector;
    private float yVelocity = 0, currentSpeed;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        gravityScale = Mathf.Abs(gravityScale);
    }

    // Update is called once per frame
    void Update()
    {
        //if ((characterController.isGrounded))
        //{
        //    yVelocity = 0;//REINICIA SU GRAVEDAD A 0 SI ESTA EN EL SUELO   
        //}
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        bool jumpPressed = Input.GetKey(KeyCode.Space);
        bool shiftPressed = Input.GetKey(KeyCode.LeftShift);
        Jump(jumpPressed);
        Movement(x, z, shiftPressed);
        Rotation(mouseX);
        //Rotation(mouseX);



    }

    void Rotation(float mouseX)
    {
        Vector3 rotation = new Vector3(0, mouseX, 0) * mouseSens;
        transform.Rotate(rotation);//sensibilidad del personaje 

    }
    void Movement(float x, float z, bool shiftPressed)
    {
        if (shiftPressed)
            currentSpeed = runningSpeed;
        else
            currentSpeed = speed;

        Vector3 movementVector = transform.forward * currentSpeed * z + transform.right * currentSpeed * x;
        auxmovementVector = movementVector;
        if (!characterController.isGrounded)
            yVelocity -= gravityScale;

        movementVector.y = yVelocity;

        movementVector *= Time.deltaTime;//se tiene que mover igual en el pc de mi abuela que en la nasa
        characterController.Move(movementVector);
    }
    public Vector3 GetMovementVector()
    {
        return auxmovementVector;
    }
    void Jump(bool jumpPressed)
    {
        if (jumpPressed && characterController.isGrounded)
        {
            yVelocity = 0;
            yVelocity += jumpforce; //Mathf.Sqrt(jumpforce * 3 * gravityScale);

        }

    }
}
