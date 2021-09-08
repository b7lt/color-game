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
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		dashTime = startDashTime;
	}
	private void Update()
    {
		Debug.Log(direction);
		if(direction == 0)
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				direction = 1;
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				direction = 2;
			}
			else if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				direction = 3;
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				direction = 4;
			}
		}
		else
		{
			if(dashTime <=0)
			{
				direction = 0;
				dashTime = startDashTime;
				rb.velocity = Vector2.zero;
			}
			else
			{
				dashTime -= Time.deltaTime;

				if(direction == 1)
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
