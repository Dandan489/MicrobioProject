using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public bool enable = false;
    public int level = -1;
    public List<float> damage = new List<float>();

    public float lastHit = 0f;
    public float hitInterval = 1f;
    public GameObject player;

    public virtual void Enable()
    {
        enable = true;
        level = 0;
    }
}
