using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public IntData ammoCount;
    public IntData maxAmmo;
    public GameObject prefab;
    public Transform instancer;
    public Slider ammoBar;
    private WaitForSeconds reloadTime = new WaitForSeconds(0.01f);
    //public GameObject mouseObj;

    private void Start()
    {
        ammoBar.maxValue = maxAmmo.value;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammoCount.value > 0)
        {
            fire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(reload());
        }
        //transform.LookAt(mouseObj.transform);
        ammoBar.value = ammoCount.value;
    }

    private void fire()
    {
        Instantiate(prefab, instancer.position, instancer.rotation);
        ammoCount.value--;
    }

    private IEnumerator reload()
    {
        yield return reloadTime;
        ammoCount.value = maxAmmo.value;
    }
}
