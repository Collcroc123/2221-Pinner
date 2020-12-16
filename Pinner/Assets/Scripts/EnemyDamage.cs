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
    public Animator anim;
    private float pSpeed;
    public bool boss = false;
    public IntData enemyKilled;
    //public ObjectData enemy;

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
                enemyKilled.value++;
                //enemy.value.SetActive(false);
                other.gameObject.SetActive(false);
                StartCoroutine(Scene());
            }
        }
    }

    IEnumerator Scene()
    {
        anim.SetTrigger("StartFade");
        yield return new WaitForSeconds(1.2f);
        if (boss)
        {
            SceneManager.LoadScene(11);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
}