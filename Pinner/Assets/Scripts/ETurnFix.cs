using System.Collections;
using UnityEngine;

public class ETurnFix : MonoBehaviour
{
    public BoolData enemyTurn;
    public IntData enemiesKilled;
    public BoolData key;
    public GameObject text;
    public IntData enemyNum;

    void Start()
    {
        StartCoroutine(waitTime());
        if (enemiesKilled.value >= 3)
        {
            key.value = true;
            text.SetActive(true);
        }
        else
        {
            key.value = false;
            text.SetActive(false);
        }
    }

    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(1f);
        enemyTurn.value = false;
        enemyNum.value = 0;
    }
}