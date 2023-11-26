using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletCorner : Attacks
{
    public GameObject bullet;

    public float attackinterval;
    private float lastAttack = 0f;
    public List<int> bulletcount = new List<int>();
    public float bulletspeed;

    private void Start()
    {
        levelText.text = (level + 1).ToString() + " / " + (maxLevel + 1).ToString();
        levelUpText.text = "Level: " + (level + 1).ToString() + " / " + (maxLevel + 1).ToString();
    }

    public override void Enable()
    {
        base.Enable();
        levelText.text = (level + 1).ToString() + " / " + (maxLevel+1).ToString();
        levelUpText.text = "Level: " + (level + 1).ToString() + " / " + (maxLevel + 1).ToString();
    }

    public override void LevelUp()
    {
        if(level == -1)
        {
            Enable();
            return;
        }
        base.LevelUp();
        levelText.text = (level + 1).ToString() + " / " + (maxLevel + 1).ToString();
        levelUpText.text = "Level: " + (level + 1).ToString() + " / " + (maxLevel + 1).ToString();
        if(level == maxLevel)
        {
            updateButton.gameObject.SetActive(false);
        }
    }

    public override void Restart()
    {
        base.Restart();
    }

    private void Update()
    {
        if (!GameManager.instance.paused && enable)
        {
            lastAttack += Time.deltaTime;
            if (lastAttack >= attackinterval)
            {
                GameObject spawn;
                float degree = 360f/(float)bulletcount[level];
                float curdeg = degree/2;

                float radian;

                for (int i = 0; i < bulletcount[level]; i++)
                {
                    radian = 2 * Mathf.PI * curdeg / 360f;
                    spawn = GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
                    spawn.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)) * bulletspeed;
                    spawn.GetComponent<BulletTrigger>().damage = damage[level];
                    curdeg = (curdeg + degree) % 360f;
                }

                lastAttack = 0;
            }
        }
    }
}
