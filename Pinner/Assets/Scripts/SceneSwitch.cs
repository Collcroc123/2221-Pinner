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
    
    public void Exit()
    {
        StartCoroutine(ExitGame());
    }

    IEnumerator AnimSwitch()
    {
        anim.SetTrigger("StartFade");
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(sceneNumber);
    }

    public IEnumerator ExitGame()
    {
        anim.SetTrigger("StartFade");
        yield return new WaitForSeconds(1.2f);
        Application.Quit();
    }
}