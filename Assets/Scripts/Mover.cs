using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mover : MonoBehaviour
{
    public float health;
    public float totalhealth;
    public float damage;
    public float atkSpeed;
    protected float lastHit=0f;
    public float speed = 5f;

    public GameObject healthBar;

    private void Start()
    {
        health = totalhealth;
    }

    public void UpdateMotor(Vector3 movement)
    {
        if (!GameManager.instance.paused)
        {
            gameObject.transform.position += movement;
        }
    }

    public void RecieveDamage(float damageCount)
    {
        if (!GameManager.instance.paused)
        {
            health -= damageCount;
            if (health <= 0)
            {
                Death();
            }

            if (gameObject.tag == "Player")
            {
                healthBar.transform.localScale = new Vector3(health / totalhealth, 0.45f, 1);
            }
        }
    }

    protected virtual void Death()
    {
        Debug.Log("ded");
    }
}
