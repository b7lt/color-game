using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 0f;
    public float maxSpeed = 4f;
    public float acceleration = 30f;
    public float deceleration = 50f;
    SpriteRenderer sr;
    public Animator animator;
   // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left") && speed >  -maxSpeed)
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
