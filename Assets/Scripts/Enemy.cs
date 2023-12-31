using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    private Transform target;
    public GameObject exp;
    public Transform expParent;

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
        if (GameManager.instance.paused)
        {
            lastHit = Time.time;
        }
    }

    protected override void Death()
    {
        base.Death();
        Instantiate(exp, transform.position, Quaternion.identity, expParent.transform);
        Destroy(gameObject);
    }
}
