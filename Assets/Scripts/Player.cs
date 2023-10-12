using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float jumpForce = 0.8f;
    private bool isGrounded = false;
    bool Ground = false;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private States State
    {
        get { return (States)anim.GetInteger("State"); }
        set { anim.SetInteger("State", (int)value); }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Run()
    {
        if (isGrounded) State = States.Run;

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        sprite.flipX = dir.x < 0.0f;
    }

    void FixedUpdate()
    {
        Grounded();
    }

    private void Update()
    {
        if (isGrounded) State = States.Idle;

        if (Input.GetButton("Horizontal"))
            Run();
        if (Ground && Input.GetButton("Jump"))
            Jump();
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Grounded()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 1f);
        Ground = collider.Length > 1;

        if (!isGrounded) State = States.Jump;
    }
}

    public enum States
    {
        Idle,
        Run,
        Jump
    }