using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 move;
    public float speed = 5f;

    void Start()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
    }

    void FixedUpdate()
    {
        move.x = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        move.y = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
        move.z = 0;
        if(move.x!=0 && move.y!=0){
            move.x/=(float)Math.Sqrt(2);
            move.y/=(float)Math.Sqrt(2);
        }
        UpdateMotor(move);
    }

    private void UpdateMotor(Vector3 movement)
    {
        gameObject.transform.position += movement;
    }
}
