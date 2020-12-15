using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonDoor : MonoBehaviour
{
    public BoolData key;
    public GameObject closedDoors;
    public GameObject openDoors;

    private void Start()
    {
        closedDoors.SetActive(true);
        openDoors.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (key.value)
        {
            closedDoors.SetActive(false);
            openDoors.SetActive(true);
        }
    }
}
