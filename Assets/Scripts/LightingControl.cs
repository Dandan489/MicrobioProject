using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightingControl : Attacks

{
    private float degree;
    public float speed = 5f;
    public float distance = 4f;

    public List<GameObject> lightingGO = new List<GameObject>();
    public List<int> lightingCnt = new List<int>();

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI levelUpText;

    private void Start()
    {
        levelText.text = (level + 1).ToString() + " / " + (maxLevel + 1).ToString();
        levelUpText.text = "Level: " + (level + 1).ToString() + " / " + (maxLevel + 1).ToString();
    }

    public override void Enable()
    {
        base.Enable();
        for (int i = 0; i < lightingCnt[level]; i++)
        {
            lightingGO[i].SetActive(true);
        }
        degree = 0f;
        levelText.text = (level + 1).ToString() + " / " + (maxLevel + 1).ToString();
        levelUpText.text = "Level: " + (level + 1).ToString() + " / " + (maxLevel + 1).ToString();
    }

    public override void LevelUp()
    {
        if (level == -1)
        {
            Enable();
            return;
        }
        base.LevelUp();
        for (int i = 0; i < lightingCnt[level]; i++)
        {
            lightingGO[i].SetActive(true);
        }
        levelText.text = (level + 1).ToString() + " / " + (maxLevel + 1).ToString();
        levelUpText.text = "Level: " + (level + 1).ToString() + " / " + (maxLevel + 1).ToString();

        if(level == maxLevel)
        {
            updateButton.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (!enable) return;
        if (!GameManager.instance.paused)
        {
            degree = (degree + speed) % 360;
            float diff = 360f / lightingCnt[level];
            float totaldiff = 0f;
            for (int i=0; i<lightingCnt[level]; i++)
            {
                float calcdeg = (degree + totaldiff) % 360f;
                float radian = 2 * Mathf.PI * calcdeg / 360f;
                lightingGO[i].GetComponent<Transform>().localPosition = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0) * distance;
                totaldiff += diff;
            }
        }
    }
}
