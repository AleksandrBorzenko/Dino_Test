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
    /// <summary>
    /// Finger's transform for bullet start position
    /// </summary>
    public Transform fingerForBullet;

    private PlayerAnimator _playerAnimator;
    private List<Waypoint> _currentWaypoints;
    private PlayerPathSearcher _playerPathSearcher;
    private int _nextWaypointNumber = 1;
    private float _rotationOffset = 0.5f;
    private float _rotationMultiplier = 1f;

    /// <summary>
    /// Can a player move or not
    /// </summary>
    public bool canMove { get; private set; }
    public bool canShoot { get; private set; }

    private void Awake()
    {
        _playerAnimator = new PlayerAnimator(GetComponentInChildren<Animator>());
        _playerPathSearcher = new PlayerPathSearcher(GetComponent<NavMeshAgent>());
        _playerPathSearcher.DestinationArrived.AddListener(StopAndSetNextDestination);
    }

    private void StopAndSetNextDestination()
    {
        canShoot = true;
        _playerAnimator.IdleAnim();
        StartCoroutine(RotatePlayer());
        canMove = false;
        _nextWaypointNumber++;
    }

    private IEnumerator RotatePlayer()
    {
        var currentWaypoint = _nextWaypointNumber;
        Quaternion startRot = transform.rotation;
        float startTime = Time.timeSinceLevelLoad;
        while (Quaternion.Angle(_currentWaypoints[currentWaypoint].playerPlace.playerYRotationInWaypoint,transform.rotation) > _rotationOffset)
        {
            transform.rotation = Quaternion.Lerp(startRot, _currentWaypoints[currentWaypoint].playerPlace.playerYRotationInWaypoint,
                _rotationMultiplier*Time.timeSinceLevelLoad- startTime);
            yield return null;
        }

        transform.rotation = new Quaternion(transform.rotation.x,
            _currentWaypoints[currentWaypoint].playerPlace.playerYRotationInWaypoint.y, transform.rotation.z,
            transform.rotation.w);
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            canMove = !canMove;
            _playerAnimator.RunAnim();
            Debug.Log(canMove);
        }*/
        if (canMove)
        {
            if (_nextWaypointNumber < _currentWaypoints.Count)
            {
                _playerPathSearcher.Move(_currentWaypoints[_nextWaypointNumber].playerPlace.playerPlaceInWaypoint,transform.position);
            }
        }
    }
    /// <summary>
    /// Receive waypoints list
    /// </summary>
    /// <param name="waypoints">List of waypoints on scene</param>
    public void TakeWaypoints(List<Waypoint> waypoints)
    {
        _currentWaypoints = new List<Waypoint>();
        _currentWaypoints.AddRange(waypoints.ToArray());
    }
    /// <summary>
    /// A player starts moving
    /// </summary>
    public void StartMoving()
    {
        canMove = true;
        _playerAnimator.RunAnim();
    }
    /// <summary>
    /// Play shoot animation
    /// </summary>
    public void Shoot()
    {
        _playerAnimator.ShootAnim();
    }
    /// <summary>
    /// Prohibit shooting
    /// </summary>
    public void SetCanShootFalse()
    {
        canShoot = false;
    }
}
