using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstAttackManager : MonoBehaviour
{
    public AIBehaviour artInt;
    public BoolData enemyTurn;
    public Animator anim;
    public GameObject enemy;
    public IntData deadNum;
    public int enemyNum;

    private void Start()
    {
        if(deadNum.value == enemyNum)
        {
            enemy.SetActive(false);
        }
        else
        {
            enemy.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        deadNum.value = enemyNum;
        if (artInt.seen == false)
        {
            enemyTurn.value = false;
        }
        else if (artInt.seen == true)
        {
            enemyTurn.value = true;
        }
        StartCoroutine(Switch());
    }

    IEnumerator Switch()
    {
        anim.SetTrigger("StartFade");
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(1);
    }
}