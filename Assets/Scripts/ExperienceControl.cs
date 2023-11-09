using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceControl : MonoBehaviour
{
    public float expCount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.ExpGain(expCount);
            Destroy(gameObject);
        }
    }
}
