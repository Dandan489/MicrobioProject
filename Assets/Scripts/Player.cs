using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player : Mover
{
    private Vector3 move;
    void Start()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
    }

    void FixedUpdate(){
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");
        move.z = 0;
        move = Vector3.Normalize(move) * speed * Time.fixedDeltaTime;
        UpdateMotor(move);
    }
}
