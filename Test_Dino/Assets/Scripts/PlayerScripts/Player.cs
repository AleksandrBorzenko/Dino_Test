using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Player's facade
/// </summary>
public class Player : MonoBehaviour
{
    private PlayerAnimator _playerAnimator;
    private List<Waypoint> _currentWaypoints;
    private PlayerPathSearcher _playerPathSearcher;

    /// <summary>
    /// Singleton of a player
    /// </summary>
    public static Player instance { get; private set; }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            _playerAnimator = new PlayerAnimator(GetComponentInChildren<Animator>());
            _playerPathSearcher = new PlayerPathSearcher(GetComponent<NavMeshAgent>());
        }
    }

    public void TakeWaypoints(List<Waypoint> waypoints)
    {
        _currentWaypoints = new List<Waypoint>();
        _currentWaypoints.AddRange(waypoints.ToArray());
        Debug.Log(_currentWaypoints.Count);
    }

}
