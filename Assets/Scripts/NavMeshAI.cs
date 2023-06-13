using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private List<Transform> waypoints;
    private int currentWaypoint = 0;
    private bool destinationPointSet = false;
    public Transform player;

    public float sightRange, attackRange;
    private bool playerInSightRange, playerInAttackRange;

    private void Start()
    {
        SetNextWaypoint();
    }

    private void Update()
    {
        playerInSightRange = Vector3.Distance(transform.position, player.position) <= sightRange;
        playerInAttackRange = Vector3.Distance(transform.position, player.position) <= attackRange;

        if (!playerInSightRange && !playerInAttackRange)
        {
            if (!destinationPointSet)
            {
                Patroling();
            }
        }
        else if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        else if (playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }
    }

    private void FixedUpdate()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!agent.pathPending)
            {
                if (destinationPointSet)
                {
                    destinationPointSet = false;
                    StartCoroutine(WaitBeforeNextMovement());
                }
            }
        }
    }

    private void SetNextWaypoint()
    {
        currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
        agent.SetDestination(waypoints[currentWaypoint].position);
        destinationPointSet = true;
    }

    private IEnumerator WaitBeforeNextMovement()
    {
        yield return new WaitForSeconds(2f); // Wait for 2 seconds before moving to the next waypoint
        SetNextWaypoint();
    }

    private void Patroling()
    {
        if (!destinationPointSet)
        {
            SetNextWaypoint();
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        transform.LookAt(player);
        // Perform attack actions here
    }
}
