using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

/// <summary>
/// Component of player which searches the path and moves him
/// </summary>
public class PlayerPathSearcher
{
    private readonly NavMeshAgent _navMeshAgent;

    /// <summary>
    /// The event called when the player got the destination
    /// </summary>
    public UnityEvent DestinationArrived = new UnityEvent();

    /// <summary>
    /// Moves a player to specified position
    /// </summary>
    /// <param name="targetPosition">The position of waypoint</param>
    public void Move(Vector3 targetPosition,Vector3 transformPosition)
    {
        if (Vector3.Distance(targetPosition,transformPosition) > _navMeshAgent.stoppingDistance)
        {
            _navMeshAgent.SetDestination(targetPosition);
        }
        else
        {
            DestinationArrived?.Invoke();
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
