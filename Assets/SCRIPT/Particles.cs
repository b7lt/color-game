using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    ParticleSystem dust;
    Movement movementScript;
    Jump jumpScript;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        dust = GetComponentInChildren<ParticleSystem>();
        movementScript = gameObject.GetComponent<Movement>();
        jumpScript = gameObject.GetComponent<Jump>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ( movementScript.speed != 0 && jumpScript.isGrounded)
		{
            dust.Play();
            Debug.Log("work");
		}

		else
		{
            dust.Stop();

        }
    }


    
}
