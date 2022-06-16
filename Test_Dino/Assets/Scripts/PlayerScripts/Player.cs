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


    private void Awake()
    {
        _playerAnimator = new PlayerAnimator(GetComponentInChildren<Animator>());
        _playerPathSearcher = new PlayerPathSearcher(GetComponent<NavMeshAgent>());
    }

    public void TakeWaypoints(List<Waypoint> waypoints)
    {
        _currentWaypoints = new List<Waypoint>();
        _currentWaypoints.AddRange(waypoints.ToArray());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerPathSearcher.canMove = !_playerPathSearcher.canMove;
            _playerPathSearcher.SetDestination(_currentWaypoints[_playerPathSearcher.nextWaypointNumber].playerPlace.playerPlaceInWaypoint);
            Debug.Log(_playerPathSearcher.canMove);
        }
        if (_playerPathSearcher.canMove)
        {
            if (_playerPathSearcher.nextWaypointNumber < _currentWaypoints.Count)
            {
                _playerPathSearcher.Move(_currentWaypoints[_playerPathSearcher.nextWaypointNumber].playerPlace.playerPlaceInWaypoint);
            }
        }
    }

}
