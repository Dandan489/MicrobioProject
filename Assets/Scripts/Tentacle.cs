using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : Attacks
{
    public float attackinterval;
    public float stayinterval;
    public float lastAttack = 0f;
    public GameObject tentacleGO;

    public override void Enable()
    {
        base.Enable();
    }

    private void Update()
    {
        if (!GameManager.instance.paused && enable)
        {
            if (enable && Time.time - lastAttack > attackinterval)
            {
                Debug.Log("open");
                tentacleGO.SetActive(true);
                lastAttack = Time.time;
            }
            if (enable && Time.time - lastAttack > stayinterval)
            {
                Debug.Log("close");
                tentacleGO.SetActive(false);
            }
        }
    }
}
