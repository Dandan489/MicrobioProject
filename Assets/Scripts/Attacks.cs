using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI levelUpText;

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

    public virtual void Restart(){
        level = -1;
        lastHit = 0f;
        enable = false;
        levelText.text = (level + 1).ToString() + " / " + (maxLevel + 1).ToString();
        levelUpText.text = "Level: " + (level + 1).ToString() + " / " + (maxLevel + 1).ToString();
    }
}
