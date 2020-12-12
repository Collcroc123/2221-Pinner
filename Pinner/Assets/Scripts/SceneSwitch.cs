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
        anim.SetTrigger("StartFade");
        SceneManager.LoadScene(sceneNumber);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}