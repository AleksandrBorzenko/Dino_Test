using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    private bool _canMove;
    private int _nextWaypointNumber = 1;
    private float _rotationOffset = 0.5f;
    private float _rotationMultiplier = 1f;

    private void Awake()
    {
        _playerAnimator = new PlayerAnimator(GetComponentInChildren<Animator>());
        _playerPathSearcher = new PlayerPathSearcher(GetComponent<NavMeshAgent>());
        _playerPathSearcher.DestinationArrived.AddListener(StopAndSetNextDestination);
    }

    private void StopAndSetNextDestination()
    {
        _playerAnimator.IdleAnim();
        StartCoroutine(RotatePlayer());
        _canMove = false;
        _nextWaypointNumber++;
        Debug.Log("Arrived");
    }

    private IEnumerator RotatePlayer()
    {
        var currentWaypoint = _nextWaypointNumber;
        Quaternion startRot = transform.rotation;
        float startTime = Time.timeSinceLevelLoad;
        while (Quaternion.Angle(_currentWaypoints[currentWaypoint].playerPlace.playerYRotationInWaypoint,transform.rotation) > _rotationOffset)
        {
            /*transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(transform.rotation.x,
                _currentWaypoints[currentWaypoint].playerPlace.playerYRotationInWaypoint, transform.rotation.z,
                transform.rotation.w), _rotationMultiplier);*/
            transform.rotation = Quaternion.Lerp(startRot, _currentWaypoints[currentWaypoint].playerPlace.playerYRotationInWaypoint,
                _rotationMultiplier*Time.timeSinceLevelLoad- startTime);
            Debug.Log("Rotating");
            yield return null;
        }

        transform.rotation = new Quaternion(transform.rotation.x,
            _currentWaypoints[currentWaypoint].playerPlace.playerYRotationInWaypoint.y, transform.rotation.z,
            transform.rotation.w);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _canMove = !_canMove;
            _playerAnimator.RunAnim();
            Debug.Log(_canMove);
        }
        if (_canMove)
        {
            if (_nextWaypointNumber < _currentWaypoints.Count)
            {
                _playerPathSearcher.Move(_currentWaypoints[_nextWaypointNumber].playerPlace.playerPlaceInWaypoint,transform.position);
            }
        }
    }

    public void TakeWaypoints(List<Waypoint> waypoints)
    {
        _currentWaypoints = new List<Waypoint>();
        _currentWaypoints.AddRange(waypoints.ToArray());
    }

}
