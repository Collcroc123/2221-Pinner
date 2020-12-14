using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstAttackManager : MonoBehaviour
{
    public AIBehaviour artInt;
    public BoolData enemyTurn;
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
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