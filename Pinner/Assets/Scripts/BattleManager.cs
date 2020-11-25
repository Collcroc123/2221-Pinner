using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public AIBehaviour artInt;
    public BoolData firstHit;

    private void OnTriggerEnter(Collider other)
    {
        if (artInt.seen == false)
        {
            firstHit.value = true;
        }
        else if (artInt.seen == true)
        {
            firstHit.value = false;
        }
        SceneManager.LoadScene(1);
    }
}
