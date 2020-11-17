using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
    public bool canNavigate = false;
    public bool canPatrol = true;
    private WaitForFixedUpdate wffu;
    public float holdTime = 2f;
    private WaitForSeconds wfs;
    public List<Transform> patrolPoints;
    private Vector3 startPos;
    public int patrolRange = 5;

    private void Start()
    {
        startPos = transform.position;
        i = 0;
        agent = GetComponent<NavMeshAgent>();
        wfs = new WaitForSeconds(holdTime);
        StartCoroutine(Patrol());
    }

    private IEnumerator Navigate()
    {
        canNavigate = true;
        canPatrol = false;
        yield return wfs;
        while (canNavigate)
        {
            yield return wffu;
            agent.destination = player.position;
            print("walking");
        }
    }

    private int i = 0;
    private IEnumerator Patrol()
    {
        canPatrol = true;
        canNavigate = false;
        while (canPatrol)
        {
            yield return wffu;
            if (agent.pathPending || !(agent.remainingDistance < 0.5f)) continue;
            //agent.destination = patrolPoints[i].position;
            //i = (i + 1) % patrolPoints.Count;
            agent.destination = (Random.insideUnitSphere * patrolRange) + startPos;
            yield return wfs;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canNavigate = false;
        canPatrol = false;
        StartCoroutine(Navigate());
    }

    private void OnTriggerExit(Collider other)
    {
        canNavigate = false;
        canPatrol = false;
        StartCoroutine(Patrol());
    }
}
