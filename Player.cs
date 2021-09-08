using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //player var
    public float moveSpeed;
    float xInput, yInput;
    
    //jump function var
    public bool grounded = true;
    public float hops = 2;
    public int jumpCount = 0;
    //Vector2 targetPos;
    //this controls the body
    Rigidbody2D rb;
    //this is for the sprite flip
    SpriteRenderer sp;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        sp = GetComponent<SpriteRenderer>();


    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 10f;
        
        if(Input.GetMouseButtonDown(0))
        {
            targetPos = mousePos;
        }

        //transform.position = mousePos;
        */

    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");


        transform.Translate(xInput * moveSpeed, 0, 0);
        //ClickToMove();
        PlatformerController();
        FlipPlayer();
        
        //works only if u press space on the ground OR if u press space in the air, and you have enough jumps
        if (Input.GetKey(KeyCode.Space) && grounded || Input.GetKey(KeyCode.Space) && jumpCount < 3)
        {
            jumpCount++;
            rb.AddForce(transform.up * hops, ForceMode2D.Impulse);
            grounded = false;
            

        }
    }

    /*void ClickToMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed);

    }
      */  
    void PlatformerController()
    {
        rb.velocity =  new Vector2(moveSpeed * xInput, rb.velocity.y);


    }

    void FlipPlayer()
    {
        if (rb.velocity.x < -0.1f)
        {
            sp.flipX = true;
        }
        else if(rb.velocity.x > 0.1f)
        {
            sp.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            grounded = true;
            jumpCount = 0;
        }
    }

}
