using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToxicGasControl : Attacks
{
    [SerializeField]
    private GameObject gas;

    private float lastRelease;
    [SerializeField]
    private float ReleaseInterval;

    public float lastTime;

    private void Start()
    {
        levelText.text = (level + 1).ToString() + " / " + (maxLevel + 1).ToString();
        levelUpText.text = "Level: " + (level + 1).ToString() + " / " + (maxLevel + 1).ToString();
    }

    public override void Enable()
    {
        base.Enable();
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
        if (GameManager.instance.paused || !enable) return;

        lastRelease += Time.deltaTime;
        if(lastRelease >= ReleaseInterval)
        {
            ReleaseGas();
            lastRelease = 0;
        }
    }

    private void ReleaseGas()
    {
        GameObject newgo;
        newgo = GameObject.Instantiate(gas, transform.position, Quaternion.identity);
        newgo.GetComponent<GasTrigger>().TGC = this;
    }
}
