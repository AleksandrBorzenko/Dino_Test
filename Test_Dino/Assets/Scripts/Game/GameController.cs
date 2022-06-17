using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Main controller of game process
/// </summary>
public class GameController : MonoBehaviour
{
    [SerializeField] private WaypointsHolder _waypointsHolder;
    [SerializeField] private Player _player;
    [SerializeField] private TouchScreen _touchScreen;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private Camera _mainCamera;


    private void Start()
    {
        _waypointsHolder.InitializePointsOnScene();
        _player.TakeWaypoints(_waypointsHolder.waypoints);
        _touchScreen.GameStarted.AddListener(StartGame);
        _bulletPool.InitializePool();

        foreach (var waypoint in _waypointsHolder.waypoints)
        {
            waypoint.WaypointCleaned.AddListener(RemoveWaypoint);
        }
    }

    private void RemoveWaypoint(Waypoint waypoint)
    {
        waypoint.WaypointCleaned.RemoveListener(RemoveWaypoint);
        _waypointsHolder.waypoints.Remove(waypoint);
        _player.StartMoving();
        _player.SetCanShootFalse();

    }

    private void StartGame()
    {
        _player.StartMoving();
    }

    private bool IsMouseOverUI()
    {
#if UNITY_EDITOR
        return EventSystem.current.IsPointerOverGameObject();

#elif UNITY_ANDROID
            return EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
#endif
    }

    private void Update()
    {
        if (_player.canShoot)
        {
            if (Input.GetMouseButtonDown(0) && !IsMouseOverUI())
            {
                RaycastHit hit;
                if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    _bulletPool.CreateBullet(_player.fingerForBullet.position, hit.point);
                    _player.Shoot();
                }
            }
        }
    }
    



    private void OnDestroy()
    {
        _touchScreen.GameStarted.RemoveListener(StartGame);
    }


}
