using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int sceneNumber = 0;
    public void OnTriggerEnter(Collider other)
    {
        Switch();
    }

    public void Switch()
    {
        SceneManager.LoadScene(sceneNumber);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
