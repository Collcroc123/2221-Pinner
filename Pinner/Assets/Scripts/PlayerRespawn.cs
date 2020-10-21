using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public IntData value;
    public GameObject spawnPoint;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (value.value <= 0)
        {
            controller.enabled = false;
            transform.position = spawnPoint.transform.position;
            value.value = 100;
            controller.enabled = true;
        }
    }
}