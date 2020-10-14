using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public int ammoCount;
    private int maxAmmo = 20;
    public GameObject prefab;
    public Transform instancer;
    public Slider ammoBar;
    private WaitForSeconds reloadTime = new WaitForSeconds(2f);

    private void Start()
    {
        ammoCount = maxAmmo;
        ammoBar.maxValue = maxAmmo;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammoCount > 0)
        {
            fire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(reload());
        }

        ammoBar.value = ammoCount;
    }

    private void fire()
    {
        Instantiate(prefab, instancer.position, instancer.rotation);
        ammoCount--;
        
        if (ammoCount == 0)
        {
            //StartCoroutine(reload());
        }
    }

    private IEnumerator reload()
    {
        yield return reloadTime;
        ammoCount = maxAmmo;
    }
}
