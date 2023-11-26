using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpControl : MonoBehaviour
{
    public void Restart(){
        foreach(Transform child in transform){
            GameObject.Destroy(child.gameObject);
        }
    }
}
