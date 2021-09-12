using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb2D;
    Animator animator;
    //height
    public float thrust = 5f;
    public bool isGrounded = false;
    public bool falling;
    // Start is called before the first frame update
    void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();

    }



    private void Update()
    {
        animator.SetFloat("yVelocity", rb2D.velocity.y);

        /*       if (Input.GetKey(KeyCode.Space) && isGrounded)
        *       {
        *           rb2D.AddForce(transform.up * thrust, ForceMode2D.Impulse);
        *
        *           animator.SetTrigger("jumped");
        *           isGrounded = false;
               }*/
        Jumping();
        animator.SetBool("isGrounded", isGrounded);
        Debug.Log(rb2D.velocity.y);
    }

    public bool Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb2D.AddForce(transform.up * thrust, ForceMode2D.Impulse);

            animator.SetTrigger("jumped");
            isGrounded = false;
            return true;
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isGrounded = false;
        }
    }
}
