using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRespawn : MonoBehaviour
{
    public IntData value;
    public GameObject spawnPoint;
    private CharacterController controller;
    public IntData maxHealth;
    public Slider healthBar;
    private WaitForSeconds deathTime = new WaitForSeconds(3f);

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        value.value = maxHealth.value;
        healthBar.maxValue = maxHealth.value;
    }

    private void Update()
    {
        if (value.value <= 0)
        {
            StartCoroutine(death());
        }
        healthBar.value = value.value;
    }
    
    private IEnumerator death()
    {
        value.value = maxHealth.value;
        controller.enabled = false;
        yield return deathTime;
        transform.position = spawnPoint.transform.position;
        controller.enabled = true;
    }
}