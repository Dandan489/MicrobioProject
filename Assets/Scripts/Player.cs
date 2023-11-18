using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player : Mover
{
    private Vector3 move;
    private Vector3 mousePos;
    private Camera cam;
    public Rigidbody2D arrow;
    public Transform arrowGO;

    public Rigidbody2D tent;
    public Transform tentGO;
    void Start()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
        move.z = 0;
        cam = Camera.main;
    }

    private void Update()
    {
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");
        move = Vector3.Normalize(move) * speed * Time.fixedDeltaTime;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        UpdateMotor(move);
        if (!GameManager.instance.paused)
        {
            Vector3 dire = mousePos - transform.position;
            dire.z = 0;
            float angle = Mathf.Atan2(dire.y, dire.x) * Mathf.Rad2Deg + 90f;

            arrow.rotation = angle;
            arrowGO.position = transform.position + 0.2f * dire.normalized;

            tent.rotation = angle-134f;
            tentGO.position = transform.position + 0.4f * dire.normalized;
        }
    }

    protected override void Death()
    {
        base.Death();
        Destroy(gameObject);
    }
}
