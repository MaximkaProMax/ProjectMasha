using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float moveSpeed = 5f;  // Скорость движения
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || IsGrounded())
        {
            rb.velocity = Vector2.up * jumpForce;

            // Добавляем движение вправо при прыжке
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

        // Устанавливаем анимацию прыжка
        animator.SetBool("IsJumping", !IsGrounded());
    }

    public void JumpButton()
    {
        rb.velocity = Vector2.up * jumpForce;

        // Добавляем движение вправо при прыжке
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }
}
