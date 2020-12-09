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
        anim.SetTrigger("StartFade");
        SceneManager.LoadScene(1);
    }
}
