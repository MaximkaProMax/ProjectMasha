using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapS : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Hero"))
        {
            rb.isKinematic = false;
        }
    }
}
