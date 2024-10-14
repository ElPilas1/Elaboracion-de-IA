using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private PlayerMovementCC playerMovementCC;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovementCC = GetComponent<PlayerMovementCC>();
    }

    // Update is called once per frame
    void Update() { }

    private void LateUpdate()
    {


        animator.SetFloat("Speed", playerMovementCC.GetMovementVector().magnitude / playerMovementCC.runningSpeed);
    }






    //float x = Input.GetAxis("Horizontal");
    //float z = Input.GetAxis("Vertical");
    //bool shiftPressed = Input.GetKey(KeyCode.LeftShift);

    //if (x != 0 || z != 0)
    //{
    //    if (shiftPressed)
    //    {
    //        //y ademas esta corriendo
    //        animator.SetBool("isRunning", true);
    //        animator.SetBool("isWalking",false);
    //    }
    //    else
    //    {
    //        //y ademas esta andando
    //        animator.SetBool("isRunning", false);
    //        animator.SetBool("isWalking", true);

    //    }
    //}
    //else
    //{
    //    animator.SetBool("isWalking", false);
    //    animator.SetBool("isWalking", false);

    //}

}
