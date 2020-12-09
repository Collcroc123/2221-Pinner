using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using NavMeshBuilder = UnityEditor.AI.NavMeshBuilder;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    private WaitForFixedUpdate wffu;
    private WaitForSeconds waitFor;
    private WaitForSeconds focusFor;
    private Vector3 startPos;
    public bool canPatrol = true;
    public bool canNavigate;
    public Transform player;
    public float waitTime = 2f;
    public float focusTime = 1f;
    public float runSpeed = 8f;
    public float patrolSpeed = 4f;
    public int patrolRange = 5;
    public bool seen = false;
    public bool attackMode = false;
    public Rigidbody rbPlayer;
    public BoolData enemyTurn;

    private void Start()
    {
        startPos = transform.position;
        agent = GetComponent<NavMeshAgent>();
        waitFor = new WaitForSeconds(waitTime);
        focusFor = new WaitForSeconds(focusTime);
        canPatrol = true;
        canNavigate = false;
        StartCoroutine(Patrol());
    }
    
    private IEnumerator Navigate()
    {
        canPatrol = false;
        canNavigate = true;
        yield return focusFor;
        while (canNavigate)
        {
            seen = true;
            agent.speed = runSpeed;
            yield return wffu;
            agent.destination = player.position;
        }
    }

    public IEnumerator Patrol()
    {
        canPatrol = true;
        canNavigate = false;
        while (canPatrol)
        {
            agent.speed = patrolSpeed;
            yield return wffu;
            if (agent.pathPending || !(agent.remainingDistance < 0.5f)) continue;
            yield return waitFor;
            agent.destination = (Random.insideUnitSphere * patrolRange) + startPos;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        canPatrol = false;
        canNavigate = false;
        if (attackMode || enemyTurn)
        {
            print("Starting Nav");
            StartCoroutine(Navigate());
        }
        else
        {
            StartCoroutine(Patrol());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canPatrol = false;
        canNavigate = false;
        seen = false;
        StartCoroutine(Patrol());
    }
}