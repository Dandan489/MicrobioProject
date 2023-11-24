using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : Attacks
{
    public GameObject tentacleGO;

    public override void Enable()
    {
        base.Enable();
        tentacleGO.SetActive(true);
    }
}
