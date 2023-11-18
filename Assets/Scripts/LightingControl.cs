using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingControl : Attacks

{
    public GameObject lightingGO;

    private float degree;
    public float speed = 5f;
    public float distance = 4f;

    private void Start()
    {
        lightingGO.SetActive(false);
    }

    public override void Enable()
    {
        base.Enable();
        lightingGO.SetActive(true);
        degree = 0;
    }

    private void FixedUpdate()
    {
        if (!GameManager.instance.paused)
        {
            degree = (degree + speed) % 360;
            lightingGO.GetComponent<Transform>().localPosition = new Vector3(distance * Mathf.Cos(degree), distance * Mathf.Sin(degree), 0);
        }
    }
}
