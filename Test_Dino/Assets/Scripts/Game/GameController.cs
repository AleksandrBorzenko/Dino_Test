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

    private void Start()
    {
        _waypointsHolder.InitializePointsOnScene();
        _player.TakeWaypoints(_waypointsHolder.waypoints);
        _touchScreen.GameStarted.AddListener(StartGame);
    }

    private void StartGame()
    {
        throw new NotImplementedException();
    }

    private void OnDestroy()
    {
        _touchScreen.GameStarted.RemoveListener(StartGame);
    }
}
