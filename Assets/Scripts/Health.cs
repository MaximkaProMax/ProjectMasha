using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public void TakeHit(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Vector3 newPosition = new Vector3(-6.04f, 1.05f, transform.position.z);
            transform.position = newPosition;
            health = maxHealth;
        }
    }

    public void SetHealth(int bonusHealth)
    {
        health += bonusHealth;

        if (health > maxHealth)
        { 
            health = maxHealth;
        }

    }

}
