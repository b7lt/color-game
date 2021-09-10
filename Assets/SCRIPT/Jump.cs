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

    // Start is called before the first frame update
    void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();

    }

    

	private void FixedUpdate()
	{
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb2D.AddForce(transform.up * thrust, ForceMode2D.Impulse);

            animator.SetTrigger("jumped");
            isGrounded = false;
        }
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer == 8)
		{
            isGrounded = true;
		}
	}
}
