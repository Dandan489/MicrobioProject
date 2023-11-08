using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    private Transform target;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    
    void FixedUpdate()
    {
        Vector3 dire = (target.position - transform.position);
        dire = Vector3.Normalize(dire) * speed * Time.fixedDeltaTime;
        UpdateMotor(dire);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Time.time - lastHit >= atkSpeed && collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Mover>().RecieveDamage(damage);
            lastHit = Time.time;
        }
    }

    protected override void Death()
    {
        base.Death();
        Destroy(gameObject);
    }
}
