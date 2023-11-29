using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPatrol2 : MonoBehaviour
{
    public float speed;
    public float distance;

    private bool movingRight = true;
    public Transform groundDetection;
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingRight = false;
            }

            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }




    }
}