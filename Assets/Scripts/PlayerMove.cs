using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMove : MonoBehaviour
{
    PhotonView view;
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sr;
    public Vector2 moveVector;
    public float speed = 10f;

    public Joystick joystick;

    void Start()
    {
        view = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        walk();  
        Flip();
        Jump();
        CheckingGround();   
        
        if (view.IsMine)
        {
            Vector2 moveInput = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 moveAmount = moveInput.normalized * speed * Time.deltaTime;
            transform.position += (Vector3)moveAmount;
        }
    }
    
    void walk()
    {
        moveVector.x = joystick.Horizontal;
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