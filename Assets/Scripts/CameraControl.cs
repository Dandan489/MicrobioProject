using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Transform player;
    
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    
    void FixedUpdate()
    {
        Vector3 campos;
        campos.x = player.position.x;
        campos.y = player.position.y;
        campos.z = -10;
        gameObject.transform.position = campos;
    }
}
