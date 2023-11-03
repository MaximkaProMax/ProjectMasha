using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGround : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 currentPosition;
    bool movingBack;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Hero") && movingBack == false)
        {
            Invoke("FallGround", 1f);
        }
    }

    void FallGround()
    {
        rb.isKinematic = false;
        Invoke("BackGround", 1f);
    }

    void BackGround()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        movingBack = true;
    }

    private void Update()
    {
        if (movingBack == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, currentPosition, 20f * Time.deltaTime);
        }

        if (transform.position.y == currentPosition.y)
        {
            movingBack  = false;
        }
    }
}
