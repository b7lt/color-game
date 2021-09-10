using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 0f;
    //max speed
    public float maxSpeed = 4f;
    //faster # = faster acceleration / same for deceleration 
    public float acceleration = 30f;
    public float deceleration = 50f;

    SpriteRenderer sr;
    Animator animator;
    Rigidbody2D rb;
   // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //movement
        if (Input.GetKey("left") && speed > -maxSpeed)
		{
            speed = speed - acceleration * Time.deltaTime;
        }
        else if (Input.GetKey("right") && speed < maxSpeed)
		{
            speed = speed + acceleration * Time.deltaTime;
        }
		else
		{
            if (speed > deceleration * Time.deltaTime)
			{
                speed = speed - deceleration * Time.deltaTime;
                
			}
            else if (speed<-deceleration * Time.deltaTime)
			{
                speed = speed + deceleration * Time.deltaTime;
                
			}
			else
			{
                speed = 0;

			}
		}
        
       
        transform.position = new Vector2 (transform.position.x + speed * Time.deltaTime, transform.position.y);
        animator.SetFloat("Speed", Mathf.Abs(speed));
        FlipPlayer();
    }

    //flip character
    void FlipPlayer()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        if (xMovement < -0.1f)
        {
            sr.flipX = true;
            
        }
        else if (xMovement > 0.1f)
        {
            sr.flipX = false;
            
        }
    }


}
