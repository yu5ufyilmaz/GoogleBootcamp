using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private List<Transform> waypoints;
    private int currentWaypoint = 0;
  
   
    void Start()
    {
        agent.SetDestination(waypoints[currentWaypoint].position);
    }
    
    void FixedUpdate()
    {
        if (agent.remainingDistance < 0.5f)
        {
            
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Count)
            {
                currentWaypoint = 0;
            }

            agent.SetDestination(waypoints[currentWaypoint].position);
        }   
    }
}
