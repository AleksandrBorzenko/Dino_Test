using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

/// <summary>
/// Player's facade
/// </summary>
public class Player : MonoBehaviour,IVital
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
    /// <summary>
    /// Can the player shoot
    /// </summary>
    public bool canShoot { get; private set; }

    /// <summary>
    /// Health of player
    /// </summary>
    public int health { get; private set; } = 1;

    /// <summary>
    /// Player's damage
    /// </summary>
    public int damage => 1;


    /// <summary>
    /// Calls when the waypoint is empty from enemies
    /// </summary>
    public UnityEvent WaypointClean = new UnityEvent();
    /// <summary>
    /// Calls if the waypoint is last
    /// </summary>
    public UnityEvent LastWaypoint = new UnityEvent();


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
        if (_currentWaypoints[_nextWaypointNumber-1].enemiesHolder.enemies.Count==0 && _nextWaypointNumber!=_currentWaypoints.Count)
        {
            WaypointClean?.Invoke();
        }
        else if(_nextWaypointNumber == _currentWaypoints.Count)
            LastWaypoint?.Invoke();
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
        canShoot = false;
        _playerAnimator.RunAnim();
    }
    /// <summary>
    /// Play shoot animation
    /// </summary>
    public void Shoot()
    {
        _playerAnimator.ShootAnim();
    }

    public void TakeDamage(int damage)
    {
        if(health>0)
            health -= damage;
    }

}
