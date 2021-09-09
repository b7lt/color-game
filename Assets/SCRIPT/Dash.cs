using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D rb;
	private float dashTime;
	public float startDashTime;
	private int direction;
	public float dashSpeed;
	public int counter = 2;
	public int waitTime = 3;
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		dashTime = startDashTime;
	}
	private void Update()
    {
		Debug.Log(counter);
		dashing();

		
    }
	
	
	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.layer == 8)
		{
			counter = 2;
		}
	}

	private void dashing()
	{
		if (direction == 0)
		{
			if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.LeftShift))
			{
				direction = 1;
				counter--;
			}
			else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.LeftShift))
			{
				direction = 2;
				counter--;
			}
			else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.LeftShift))
			{
				direction = 3;
				counter--;
			}
			else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.LeftShift))
			{
				direction = 4;
				counter--;
			}
		}
		else
		{
			if (counter > 0)
			{
				if (dashTime <= 0)
				{
					direction = 0;
					dashTime = startDashTime;
					rb.velocity = Vector2.zero;
				}
				else
				{
					dashTime -= Time.deltaTime;

					if (direction == 1)
					{
						rb.velocity = Vector2.left * dashSpeed;
					}
					else if (direction == 2)
					{
						rb.velocity = Vector2.right * dashSpeed;
					}
					else if (direction == 3)
					{
						rb.velocity = Vector2.up * dashSpeed;
					}
					else if (direction == 4)
					{
						rb.velocity = Vector2.down * dashSpeed;
					}
				}
			}
		}
	}

}
