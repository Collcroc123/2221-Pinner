﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    private WaitForFixedUpdate wffu;
    private WaitForSeconds waitFor;
    private float rotateSpeed = 90f;
    private float playerPower = 1f;
    private bool enterRotation = false;
    private bool enterSpeed = false;
    public float waitTime = 1f;
    public float lerpTime = 1f;
    public Slider powerBar;

    private void Start()
    {
        waitFor = new WaitForSeconds(waitTime);
    }

    void Update()
    {
        if (!enterRotation)
        {
            RotatePlayer();
        }
        else if (enterRotation)
        {
            if (!enterSpeed)
            {
                StartCoroutine(SpeedPlayer());
            }
            else if (enterSpeed)
            {
                //LaunchPlayer();
            }
        }
        
        //powerBar.value = playerPower;
    }

    void RotatePlayer()
    {
        var hInput = Input.GetAxis("Horizontal") * Time.deltaTime*rotateSpeed;
        transform.Rotate(0,-hInput,0);
        if (Input.GetButtonDown("Jump"))
        {
            enterRotation = true;
        }
    }

    IEnumerator SpeedPlayer()
    {
        if (playerPower < 256f)
        {
            while (playerPower < 256f)
            {
                playerPower *= 2f;
                if (Input.GetButtonDown("Jump"))
                {
                    enterSpeed = true;
                }
                print(playerPower);
                powerBar.value = Mathf.Lerp(playerPower/2, playerPower, lerpTime * Time.deltaTime);
                yield return waitFor;
            }
        }
        
        if (playerPower >= 256f)
        {
            while (playerPower > 1f)
            {
                playerPower /= 2f;
                if (Input.GetButtonDown("Jump"))
                {
                    enterSpeed = true;
                }
                print(playerPower);
                powerBar.value = Mathf.Lerp(playerPower*2, playerPower, lerpTime * Time.deltaTime);
                yield return waitFor;
            }
        }
        yield return wffu;
    }
    /*
    IEnumerator LaunchPlayer()
    {
    }*/
}
