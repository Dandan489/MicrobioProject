using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasTrigger : MonoBehaviour
{
    public ToxicGasControl TGC;
    private bool canHit = true;
    private float time = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!canHit) return;

        if(collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Mover>().RecieveDamage(TGC.damage[TGC.level]);
        }
    }
    
    private void Update()
    {
        if (GameManager.instance.paused) return;

        time += Time.deltaTime;
        TGC.lastHit += Time.deltaTime;
        if(TGC.lastHit >= TGC.hitInterval)
        {
            canHit = true;
        }

        if(time >= TGC.lastTime)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
