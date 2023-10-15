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
        if(Time.time - lastGenerateTime > generationInterval)
        {
            Spawn();
            lastGenerateTime = Time.time;
        }
    }

    void Spawn()
    {
        int pick = Random.Range(0, enemyLen);
        Vector3 spawnLocation = new Vector3();

        float decider = Random.Range(0f, 1f);
        if (decider >= 0.5f)
        {
            spawnLocation.x = player.position.x + Random.Range(-50, -30);
        }
        else
        {
            spawnLocation.x = player.position.x + Random.Range(30, 50);
        }

        decider = Random.Range(0f, 1f);
        if (decider >= 0.5f)
        {
            spawnLocation.y = player.position.y + Random.Range(-50, -30);
        }
        else
        {
            spawnLocation.y = player.position.y + Random.Range(30, 50);
        }
        spawnLocation.z = 0;
        GameObject.Instantiate(enemyList[pick], spawnLocation, Quaternion.identity, parent.transform);
    }
}
