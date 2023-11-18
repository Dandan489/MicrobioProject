using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    private Transform player;
    public int currentIndexX = 0;
    public int currentIndexY = 0;
    public float size = 2.88f;

    public List<TerrainUpdater> terrains = new List<TerrainUpdater>();

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    
    void Update()
    {
        bool updated = false;
        //Debug.Log(new Vector2(currentIndexX, currentIndexY));
        if (player.position.x >= size / 2 + size * currentIndexX)
        {
            currentIndexX++;
            updated = true;
        }
        if (player.position.y >= size / 2 + size * currentIndexY)
        {
            currentIndexY++;
            updated = true;
        }
        if (player.position.x <= -1 * size / 2 + size * currentIndexX)
        {
            currentIndexX--;
            updated = true;
        }
        if (player.position.y <= -1 * size / 2 + size * currentIndexY)
        {
            currentIndexY--;
            updated = true;
        }

        if (updated)
        {
            foreach (TerrainUpdater tu in terrains)
            {
                tu.IndexChange();
            }
        }
    }
}
