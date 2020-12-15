using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    private WaitForFixedUpdate wffu;
    public int health = 0;
    public int blockAmount = 0;
    public int damageAmount = 0;
    public IntData healthData;
    public IntData maxHealth;
    public bool doesDamage;
    public bool changesMaxHealth;
    public Slider healthBar;
    public Text hpText;
    public AIBehaviour ai;
    public BoolData enemyTurn;
    private int spaceCount = 0;
    private bool checkSpace = false;
    public IntData enemyNum;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Damage());
        }
    }

    private void Update()
    {
        healthBar.value = healthData.value;
        hpText.text = healthData.value.ToString();
        if (checkSpace)
        {
            if (Input.GetKeyDown("space"))
            {
                spaceCount++;
            }
        }
    }

    public IEnumerator Damage()
    {
        checkSpace = true;
        yield return new WaitForSeconds(0.5f);
        checkSpace = false;
        print(spaceCount);
        if (spaceCount == 1)
        {
            health = blockAmount;
        }
        else
        {
            health = damageAmount;
        }

        if (doesDamage)
        {
            if (changesMaxHealth)
            {
                maxHealth.value -= health;
                healthBar.maxValue = maxHealth.value;
            }
            else if (!changesMaxHealth)
            {
                healthData.value -= health;
            }
        }
        else if (!doesDamage)
        {
            if (changesMaxHealth)
            {
                maxHealth.value += health;
                healthBar.maxValue = maxHealth.value;
            }
            else if (!changesMaxHealth)
            {
                healthData.value += health;
            }
        }

        if (healthData.value > maxHealth.value)
        {
            healthData.value = maxHealth.value;
        }

        if (healthData.value <= 0f)
        {
            enemyNum.value = 0;
            yield return new WaitForSeconds(1.2f);
            SceneManager.LoadScene(2);
        }
        
        spaceCount = 0;
        
        ai.canNavigate = false;
        ai.canPatrol = false;
        ai.seen = false;
        enemyTurn.value = false;
        ai.StopCoroutine(ai.Navigate());
        ai.StartCoroutine(ai.Patrol());
        gameObject.SetActive(false);
        yield return wffu;
    }
}