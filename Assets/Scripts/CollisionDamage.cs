using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int collisionDamage = 1;
    public string collisionTag;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        { 
            Health health = coll.gameObject.GetComponent<Health>();
            health.TakeHit(collisionDamage);
        }
    }
}
