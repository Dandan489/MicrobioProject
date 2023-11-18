using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingTrigger : MonoBehaviour
{
    public LightingControl lightingctrl;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Time.time - lightingctrl.lastHit >= lightingctrl.hitInterval && collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Mover>().RecieveDamage(lightingctrl.damage[lightingctrl.level]);
            lightingctrl.lastHit = Time.time;
        }
    }
}
