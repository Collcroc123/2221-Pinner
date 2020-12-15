using System;
using UnityEngine;

public class EnemySetter : MonoBehaviour
{
    public GameObject enemy;
    public IntData deadNum;
    public int enemyNum;

    private void Start()
    {
        if(deadNum.value == enemyNum)
        {
            enemy.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        deadNum.value = enemyNum;
        print("Working!");
    }
}
