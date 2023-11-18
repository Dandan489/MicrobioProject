using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleTrigger : MonoBehaviour
{
    public Tentacle tent;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Time.time - tent.lastHit >= tent.hitInterval && collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Mover>().RecieveDamage(tent.damage[tent.level]);
            tent.lastHit = Time.time;
        }
    }
}
