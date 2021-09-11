using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    ParticleSystem[] particles;
    Movement movementScript;
    Jump jumpScript;
    Rigidbody2D rb;
    bool jumped;
    // Start is called before the first frame update
    void Start()
    {
        particles = gameObject.GetComponentsInChildren<ParticleSystem>();
        movementScript = gameObject.GetComponent<Movement>();
        jumpScript = gameObject.GetComponent<Jump>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if ( movementScript.speed != 0 && jumpScript.Jumping())
		{
            particles[0].Play();
            Debug.Log("work");
		}

		else
		{
            particles[0].Stop();

        }
        if(jumpScript.isGrounded == false)
        {
            if (jumped == false)
            {
                particles[1].Play();
                jumped = true;
            }
            
        }
        else
        {
            jumped = false;
        }
    }


    
}
