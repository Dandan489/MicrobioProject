using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    private Transform player;
    public int currentIndexX = 0;
    public int currentIndexY = 0;
    public float size = 2.88f;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    
    void Update()
    {
        //Debug.Log(new Vector2(currentIndexX, currentIndexY));
        if (player.position.x >= size / 2 + size * currentIndexX)
        {
            currentIndexX++;
        }
        if (player.position.y >= size / 2 + size * currentIndexY)
        {
            currentIndexY++;
        }
        if (player.position.x <= -1 * size / 2 + size * currentIndexX)
        {
            currentIndexX--;
        }
        if (player.position.y <= -1 * size / 2 + size * currentIndexY)
        {
            currentIndexY--;
        }
    }
}
