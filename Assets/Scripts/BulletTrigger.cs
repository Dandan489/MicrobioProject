using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    public float damage;
    private Vector2 velocity;
    private float spawnTime;

    private void Start()
    {
        velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        spawnTime = Time.time;
    }

    private void Update()
    {
        if (GameManager.instance.paused)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
        }

        if (Time.time - spawnTime >= 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Mover>().RecieveDamage(damage);
            Destroy(gameObject);
        }
            
    }
}
