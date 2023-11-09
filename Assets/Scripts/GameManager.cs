using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI expText;
    public float totalExp=0f;
    private int level=0;
    public List<float> levelUp = new List<float> {10,20,30,40,50};
    public GameObject expBar;

    public float timer=0f;
    public TextMeshProUGUI timerText;
    public bool paused = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        paused = false;
        timer = 0f;
        totalExp = 0f;
        expBar.transform.localScale = new Vector3(totalExp / levelUp[level], 1, 1);
        expText.text = "EXP:" + totalExp.ToString() + "/" + levelUp[level].ToString();
    }

    private void Update()
    {
        if (!paused)
        {
            TimeUpdate();
        }
        
    }

    public void ExpGain(float expCount)
    {
        totalExp += expCount;
        if (totalExp >= levelUp[level])
        {
            totalExp -= levelUp[level];
            level++;
        }
        expBar.transform.localScale = new Vector3(totalExp / levelUp[level], 1, 1);
        expText.text = "EXP:" + totalExp.ToString() + "/" + levelUp[level].ToString();
    }

    private void TimeUpdate()
    {
        timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
