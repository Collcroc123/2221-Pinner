using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public Animator anim;
    public int sceneNumber = 0;
    public void OnTriggerEnter(Collider other)
    {
        Switch();
    }

    public void Switch()
    {
        StartCoroutine(AnimSwitch());
    }

    IEnumerator AnimSwitch()
    {
        anim.SetTrigger("StartFade");
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(sceneNumber);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}