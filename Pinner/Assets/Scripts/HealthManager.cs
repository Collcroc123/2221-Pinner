using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int healthAmount = 0;
    public IntData health;
    public bool doesDamage;
    public bool changesMaxHealth;
    public IntData maxHealth;
    public Slider healthBar;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (doesDamage)
            {
                if (changesMaxHealth)
                {
                    maxHealth.value -= healthAmount;
                    healthBar.maxValue = maxHealth.value;
                }
                else if (!changesMaxHealth)
                {
                    health.value -= healthAmount;
                }
            }
            else if (!doesDamage)
            {
                if (changesMaxHealth)
                {
                    maxHealth.value += healthAmount;
                    healthBar.maxValue = maxHealth.value;
                }
                else if (!changesMaxHealth)
                {
                    health.value += healthAmount;
                }
            }

            if (health.value > maxHealth.value)
            {
                health.value = maxHealth.value;
            }
        }
    }
}
