using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int healthAmount = 0;
    public IntData health;
    public bool doesDamage;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (doesDamage)
            {
                print("Took Damage!");
                health.value -= healthAmount;
            }
            else
            {
                print("Healed!");
                health.value += healthAmount;
            }
        
            if (health.value > 100)
            {
                health.value = 100;
            }
        }
    }
}
