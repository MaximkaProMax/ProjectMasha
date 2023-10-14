using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sr;
    public Vector2 moveVector;
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        walk();  
        Flip();
        Jump();
        CheckingGround();
    }

    void walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

    void Flip()
    {
        if (moveVector.x > 0)
        {
            sr.flipX = false;
        }
        else if (moveVector.x < 0)
        {
            sr.flipX = true;
        }
    }

    public float jumpForce = 3f;

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround) 
        { 
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;

    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);

        anim.SetBool("onGround", onGround);
    }

}
