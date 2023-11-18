using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainUpdater : MonoBehaviour
{
    public TerrainGenerator tg;
    public float xOffset;
    public float yOffset;

    public void IndexChange()
    {
        transform.position = new Vector3((xOffset + tg.currentIndexX) * 2.88f, (yOffset + tg.currentIndexY) * 2.88f, 0);
    }
}
