using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float thrust = 100f;
    private bool isGrounded = false;
    // Start is called before the first frame update
    void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    

	private void FixedUpdate()
	{
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb2D.AddForce(transform.up * thrust, ForceMode2D.Impulse);

            
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
