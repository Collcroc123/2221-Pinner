using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int sceneNumber = 0;
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
