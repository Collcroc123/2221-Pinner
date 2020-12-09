using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetector : MonoBehaviour
{
    public AIBehaviour ai;
    public BoolData enemyTurn;

    private void OnTriggerEnter(Collider other)
    {
        ai.canNavigate = false;
        ai.canPatrol = false;
        ai.seen = false;
        enemyTurn.value = false;
        ai.StartCoroutine(ai.Patrol());
    }
}
