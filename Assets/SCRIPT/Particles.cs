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
     

        if (!jumped && !particles[0].isPlaying)
		{
            particles[0].Play();
            Debug.Log("playing");

        }
        if (jumped || movementScript.speed == 0)
		{
            particles[0].Stop();
            Debug.Log("stop");

        }


        if (jumpScript.isGrounded == false)
        {
            if (jumped == false && rb.velocity.y > 0)
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
