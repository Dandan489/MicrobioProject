using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mover : MonoBehaviour
{
    public float speed = 5f;

    public void UpdateMotor(Vector3 movement)
    {
        gameObject.transform.position += movement;
    }
}
