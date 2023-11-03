using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogEnemy : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    private Transform currentTarget;
    private bool isFacingRight = true;
    public float speed = 3f;

    private void Start()
    {
        currentTarget = target1;
    }

    private void Update()
    {
        if (transform.position == currentTarget.position)
        {
            currentTarget = (currentTarget == target1)?target2:target1;
            Flip();
        }
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
