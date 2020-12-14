using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyDamage : MonoBehaviour
{
    private Rigidbody playerRB;
    public float enemyHealth = 100;
    public Slider enemySlider;
    public Text enemyHPText;
    private float pSpeed;
    
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        enemySlider.value = enemyHealth;
        enemyHPText.text = enemyHealth.ToString();
        pSpeed = playerRB.velocity.magnitude;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (pSpeed <= 1f)
            {
                enemyHealth -= 0f;
            }
            else if (pSpeed < 10f)
            {
                enemyHealth -= 10f;
            }
            else
            {
                enemyHealth -= pSpeed;
            }
            print(pSpeed);
            if (enemyHealth <= 0.5f)
            {
                other.gameObject.SetActive(false);
                StartCoroutine(Scene());
            }
        }
    }

    IEnumerator Scene()
    {
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(2);
    }
}