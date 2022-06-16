using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Main controller of game process
/// </summary>
public class GameController : MonoBehaviour
{
    [SerializeField] private WaypointsHolder _waypointsHolder;
    [SerializeField] private Player _player;
    [SerializeField] private TouchScreen _touchScreen;

    [SerializeField] private BulletPool _bulletPool;

    private void Start()
    {
        _waypointsHolder.InitializePointsOnScene();
        _player.TakeWaypoints(_waypointsHolder.waypoints);
        _touchScreen.GameStarted.AddListener(StartGame);
        _bulletPool.InitializePool();
    }

    private void StartGame()
    {
        _player.StartMoving();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            _bulletPool.CreateBullet();
    }

    private void OnDestroy()
    {
        _touchScreen.GameStarted.RemoveListener(StartGame);
    }
}
