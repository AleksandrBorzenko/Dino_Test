using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Component of player which searches the path and moves him
/// </summary>
public class PlayerPathSearcher
{
    private readonly NavMeshAgent _navMeshAgent;

    public bool canMove;
    public int nextWaypointNumber = 1;

    /// <summary>
    /// Moves a player to specified position
    /// </summary>
    /// <param name="targetPosition">The position of waypoint</param>
    public void Move(Vector3 targetPosition)
    {
       /* if (nextWaypointNumber == 1)
        {
            _navMeshAgent.SetDestination(targetPosition);
            return;
        }*/
        if (_navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance)
        {
            _navMeshAgent.SetDestination(targetPosition);
        }
        else
        {
            canMove = false;
            nextWaypointNumber++;
        }
    }
    /// <summary>
    /// Set the first destination from start waypoint
    /// </summary>
    /// <param name="targetPosition">The position of waypoint</param>
    public void SetDestination(Vector3 targetPosition)
    {
        _navMeshAgent.SetDestination(targetPosition);
    }


    /// <summary>
    /// Constructor with initialing 
    /// </summary>
    /// <param name="navMeshAgent">NavMeshAgent from player script</param>
    public PlayerPathSearcher(NavMeshAgent navMeshAgent)
    {
        _navMeshAgent = navMeshAgent;
    }
}
