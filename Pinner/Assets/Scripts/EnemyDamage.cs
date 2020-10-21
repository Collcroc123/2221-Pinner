using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int enemyDamage = 5;
    public IntData value;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(enemyDamage);
    }
}
