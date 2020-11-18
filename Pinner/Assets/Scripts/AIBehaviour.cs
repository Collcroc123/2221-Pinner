﻿using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    private WaitForFixedUpdate wffu;
    private WaitForSeconds waitFor;
    private WaitForSeconds focusFor;
    private Vector3 startPos;
    private bool canPatrol = true;
    private bool canNavigate;
    public Transform player;
    public float waitTime = 2.5f;
    public float focusTime = 1.5f;
    public float runSpeed = 8f;
    public float patrolSpeed = 4f;
    public int patrolRange = 5;
    
    private void Start()
    {
        startPos = transform.position;
        agent = GetComponent<NavMeshAgent>();
        waitFor = new WaitForSeconds(waitTime);
        focusFor = new WaitForSeconds(focusTime);
        StartCoroutine(Patrol());
    }

    private IEnumerator Navigate()
    {
        canPatrol = false;
        canNavigate = true;
        print("Focusing");
        yield return focusFor;
        while (canNavigate)
        {
            print("Chasing");
            agent.speed = runSpeed;
            yield return wffu;
            agent.destination = player.position;
        }
    }
    
    private IEnumerator Patrol()
    {
        canPatrol = true;
        canNavigate = false;
        while (canPatrol)
        {
            agent.speed = patrolSpeed;
            yield return wffu;
            if (agent.pathPending || !(agent.remainingDistance < 0.5f)) continue;
            print("Waiting");
            yield return waitFor;
            print("Patrolling");
            agent.destination = (Random.insideUnitSphere * patrolRange) + startPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canPatrol = false;
        canNavigate = false;
        StartCoroutine(Navigate());
    }

    private void OnTriggerExit(Collider other)
    {
        canPatrol = false;
        canNavigate = false;
        StartCoroutine(Patrol());
    }
}