using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 100;
    public int healthChange = 1;

    private void OnTriggerEnter(Collider other)
    {
        playerHealth -= healthChange;
    }
}
