using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public IntData value;
    public GameObject spawnPoint;
    
    void Update()
    {
        if (value.value <= 0)
        {
            gameObject.transform.position = spawnPoint.transform.position;
        }
    }
}