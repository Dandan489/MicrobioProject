using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform player;
    public List<GameObject> enemyList;
    private float lastGenerateTime=0f;
    public float generationInterval = 2f;

    private int enemyLen;
    public GameObject parent;

    void Start()
    {
        enemyLen = enemyList.Count;
        player = GameObject.Find("Player").transform;
    }

    
    void Update()
    {
        if(Time.time - lastGenerateTime > generationInterval && !GameManager.instance.paused)
        {
            Spawn();
            lastGenerateTime = Time.time;
        }
    }

    void Spawn()
    {
        int pick = Random.Range(0, enemyLen);
        Vector3 spawnLocation = new Vector3();

        float deciderx;
        float decidery;
        do{
            deciderx = Random.Range(0f, 1f);
            decidery = Random.Range(0f, 1f);
        } while ((deciderx >= 0.33f && deciderx < 0.66f && decidery >= 0.33f && decidery < 0.66f));

        Debug.Log(new Vector2(deciderx, decidery));

        if (deciderx >= 0.66f)
        {
            spawnLocation.x = player.position.x + Random.Range(-2f, -1f) * 1.44f;
        }
        else if(deciderx >= 0.33f)
        {
            spawnLocation.x = player.position.x + Random.Range(-1f, 1f) * 1.44f;
        }
        else
        {
            spawnLocation.x = player.position.x + Random.Range(1f, 2f) * 1.44f;
        }

        
        if (decidery >= 0.66f)
        {
            spawnLocation.y = player.position.y + Random.Range(-2f, -1f) * 1.44f;
        }
        else if(decidery >= 0.33f)
        {
            spawnLocation.y = player.position.y + Random.Range(-1f, 1f) * 1.44f;
        }
        else
        {
            spawnLocation.y = player.position.y + Random.Range(1f, 2f) * 1.44f;
        }
        spawnLocation.z = 0;
        GameObject.Instantiate(enemyList[pick], spawnLocation, Quaternion.identity, parent.transform);
    }
}
