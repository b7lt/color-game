using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 0f;
    public float maxSpeed = 4f;
    public float acceleration = 5f;
    public float deceleration = 5f;
    SpriteRenderer sr;

   // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && speed >  -maxSpeed)
		{
            speed = speed - (acceleration + 1) * Time.deltaTime;
		}
        else if (Input.GetKey(KeyCode.RightArrow) && speed < maxSpeed)
		{
            speed = speed + (acceleration + 1)* Time.deltaTime;
		}
		else
		{
            if (speed > deceleration * Time.deltaTime)
			{
                speed = speed - (deceleration + 1)* Time.deltaTime;
			}
            else if (speed<-deceleration * Time.deltaTime)
			{
                speed = speed + (deceleration + 1) * Time.deltaTime;
			}
			else
			{
                speed = 0;
			}
		}
        speed = Mathf.Lerp(speed, -maxSpeed, maxSpeed);
        transform.position = new Vector2 (transform.position.x + speed * Time.deltaTime, transform.position.y);
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
