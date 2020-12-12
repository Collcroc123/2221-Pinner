using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyDamage : MonoBehaviour
{
    private Rigidbody playerRB;
    public float enemyHealth = 50;
    public Slider enemySlider;
    
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        enemySlider.value = enemyHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyHealth -= playerRB.velocity.magnitude;
            if (enemyHealth <= 0.5f)
            {
                other.gameObject.SetActive(false);
                SceneManager.LoadScene(2);
            }
        }
    }
}