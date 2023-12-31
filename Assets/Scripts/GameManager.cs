using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI expText;
    public float totalExp=0f;
    public int level=0;
    public List<float> levelUp = new List<float> {10,20,30,40,50};
    public GameObject expBar;
    private int totalLevel;
    private bool maxedLevel = false;

    public float timer=0f;
    private float besttime;
    public TextMeshProUGUI timerText;
    public bool paused = false;

    public GameObject pauseMenu;
    public GameObject levelMenu;
    public GameObject EndMenu;

    public EnemySpawner enemySpawner;
    public ExpControl expCtrl;
    public Player player;

    public Tentacle tenta;
    public BulletCorner bultC;
    public ToxicGasControl TGC;
    public LightingControl LCtrl;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Unpause();
        timer = 0f;
        totalExp = 0f;
        expBar.transform.localScale = new Vector3(totalExp / levelUp[level], 1, 1);
        expText.text = "EXP:" + totalExp.ToString() + "/" + levelUp[level].ToString();

        totalLevel = levelUp.Count;

        tenta.Enable();
    }

    private void Update()
    {
        if (!paused)
        {
            TimeUpdate();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OpenPauseMenu();
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
            {
                Unpause();
            }
        }
        
        
    }

    public void ExpGain(float expCount)
    {
        if (!maxedLevel)
        {
            totalExp += expCount;
            if (totalExp >= levelUp[level])
            {
                if (level == totalLevel - 1)
                {
                    expBar.transform.localScale = new Vector3(totalExp / levelUp[level], 1, 1);
                    expText.text = "EXP:" + totalExp.ToString() + "/" + levelUp[level].ToString();
                    LevelUp();
                    maxedLevel = true;
                    return;

                }
                totalExp -= levelUp[level];
                level++;
                LevelUp();
            }
            expBar.transform.localScale = new Vector3(totalExp / levelUp[level], 1, 1);
            expText.text = "EXP:" + totalExp.ToString() + "/" + levelUp[level].ToString();
        }
    }

    private void TimeUpdate()
    {
        timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void OpenPauseMenu()
    {
        levelMenu.SetActive(false);
        pauseMenu.SetActive(true);
        paused = true;
    }

    public void Unpause()
    {
        levelMenu.SetActive(false);
        pauseMenu.SetActive(false);
        paused = false;
    }

    public void LevelUp()
    {
        pauseMenu.SetActive(false);
        levelMenu.SetActive(true);
        paused = true;
    }

    public void EndGame(){
        if(timer > besttime){
            besttime = timer;
        }
        EndMenu.SetActive(true);
        paused = true;
    }

    public void Restart(){
        timer = 0f;
        totalExp = 0f;
        level = 0;
        maxedLevel = false;
        expBar.transform.localScale = new Vector3(totalExp / levelUp[level], 1, 1);
        expText.text = "EXP:" + totalExp.ToString() + "/" + levelUp[level].ToString();
        expCtrl.Restart();
        enemySpawner.Restart();
        player.Restart();
        EndMenu.SetActive(false);
        bultC.Restart();
        LCtrl.Restart();
        TGC.Restart();
        paused = false;
    }
}
