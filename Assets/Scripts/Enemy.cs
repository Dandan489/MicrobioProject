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
}
