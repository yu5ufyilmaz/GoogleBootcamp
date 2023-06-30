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

    private bool isPlayerDead = false;
    private float chaseSpeed = 5f;
    private float normalSpeed = 3.5f;

    private Animator _animator;    

    private void Start()
    {
        _animator = GetComponent<Animator>();
        SetNextWaypoint();
    }

    private void Update()
    {
        if (!isPlayerDead)
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
                if (!IsPlayerBehindObstacle())
                {
                    ChasePlayer();
                }
                else
                {
                    if (!destinationPointSet)
                    {
                        Patroling();
                    }
                }
            }
            else if (playerInSightRange && playerInAttackRange)
            {
                AttackPlayer();
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isPlayerDead && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!agent.pathPending && destinationPointSet)
            {
                destinationPointSet = false;
                StartCoroutine(WaitBeforeNextMovement());
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
        yield return new WaitForSeconds(2f); 
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
        agent.speed = chaseSpeed; 
        _animator.SetFloat("Speed",chaseSpeed);
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        transform.LookAt(player);
        // Perform attack actions here

        isPlayerDead = true;
        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(1.5f); 

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    private bool IsPlayerBehindObstacle()
    {
        Vector3 direction = player.position - transform.position;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, sightRange))
        {
            if (hit.collider.CompareTag("Obstacle"))
            {
                return true;
            }
        }

        return false;
    }
}
