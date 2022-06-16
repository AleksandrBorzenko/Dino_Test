using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Component of player which searches the path and moves him
/// </summary>
public class PlayerPathSearcher
{
    private NavMeshAgent _navMeshAgent;
    /// <summary>
    /// Moves a player to specified position
    /// </summary>
    /// <param name="targetPosition">The position of waypoint</param>
    public void Move(Vector3 targetPosition)
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
