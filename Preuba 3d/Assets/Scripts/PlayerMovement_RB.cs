using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, gravityScale, mouseSens,jumpforce,sphereRadius;//el mousesens es para que el diseñador decida a que velocidad rota el personaje
    Rigidbody rb;
    public string groundname;
    private float x, z, mouseX;//input para las cosas 
    private bool jumpPressed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
       // gravityScale= -Mathf.Abs(gravityScale);//lo de mathf es el valor absoluto para la gravedad pq menos por menos mas y asi//el math f es el valor absoluta de los floats
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        if(Input.GetKeyDown(KeyCode.Space)&&IsGrounded())
        {
            jumpPressed = true;
        }
        RotatePlayer();
    }


    private void FixedUpdate()
    {
        ApllyJumpForce();
        ApllySpeed();  
        

    }
    void RotatePlayer()
    {
        Vector3 rotation = new Vector3(0, mouseX, 0) * mouseSens;
        transform.Rotate(rotation);//sensibilidad del personaje 

    }
    void ApllySpeed()
    {

        rb.velocity = (transform.forward * speed * z) + (transform.right * speed * x) + new Vector3(0, rb.velocity.y,0) ;// la de new vector 3 coje la gravedad de unity que se puede ajustas desde preferencias
        //+(transform.up*gravityScale);//la gravedad comentada es no realista
        //rb.AddForce(transform.up * gravityScale);//esta es realista
    }
    

    
    void ApllyJumpForce()
    {
        if (jumpPressed)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

            rb.AddForce(transform.up * jumpforce);
            jumpPressed = false;
        }
    }
        private bool IsGrounded()
    {
        RaycastHit[] colliders = Physics.SphereCastAll(new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2,transform.position.z),sphereRadius,Vector3.up);
    
    for (int i = 0; i < colliders.Length; i++) //recorremos elemento a elemento
        {
            //comprobamos si elemento es suelo
            if (colliders[i].collider.gameObject.layer ==LayerMask.NameToLayer(groundname))
            {
                return true;
            }
        }
    return false;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, transform.position.z), sphereRadius);
    }
}
