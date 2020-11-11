using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRespawn : MonoBehaviour
{
    public IntData health;
    public GameObject spawnPoint;
    private CharacterController controller;
    public IntData maxHealth;
    public Slider healthBar;
    private WaitForSeconds deathTime = new WaitForSeconds(3f);
    private WaitForSeconds spawnTime = new WaitForSeconds(0.1f);

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        health.value = maxHealth.value;
        healthBar.maxValue = maxHealth.value;
    }

    private void Update()
    {
        if (health.value <= 0)
        {
            StartCoroutine(death());
        }
        healthBar.value = health.value;
    }

    private IEnumerator spawn()
    {
        controller.enabled = false;
        yield return spawnTime;
        transform.position = spawnPoint.transform.position;
        controller.enabled = true;
    }
    
    private IEnumerator death()
    {
        health.value = maxHealth.value;
        controller.enabled = false;
        yield return deathTime;
        transform.position = spawnPoint.transform.position;
        controller.enabled = true;
    }
}