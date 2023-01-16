using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlayer : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
 
    GroundCheck groundCheck = new GroundCheck();
    bool isGrounded;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        isGrounded = groundCheck.isGrounded;
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }


        if (isGrounded && rb.velocity.magnitude > 0.01)
        {
            anim.SetBool("isMoving", true);
            if (Input.GetKey(KeyCode.S))
            {
                anim.SetFloat("speed", rb.velocity.magnitude * -1);
            }
            else
            {
                anim.SetFloat("speed", rb.velocity.magnitude);
            }
            
            if (Input.GetKey(KeyCode.D))
            {
                anim.SetFloat("direction", 5);
            } else if (Input.GetKey(KeyCode.A))
            {
                anim.SetFloat("direction", -5);
            } else
            {
                anim.SetFloat("direction", 0);
            }



        } else
        {
            anim.SetBool("isMoving", false);
        }



    }
}
