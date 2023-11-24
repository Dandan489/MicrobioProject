using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public bool enable = false;
    public int level = -1;
    public int maxLevel = 1;
    public List<float> damage = new List<float>();

    public float lastHit = 0f;
    public float hitInterval = 1f;
    public GameObject player;

    [SerializeField]
    protected GameObject updateButton;

    public virtual void Enable()
    {
        enable = true;
        level = 0;
    }

    public virtual void LevelUp()
    {
        if (level == maxLevel) return;
        level++;
    }
}
