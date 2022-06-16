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

    private void Start()
    {
        _waypointsHolder.InitializePointsOnScene();
        _player.TakeWaypoints(_waypointsHolder.waypoints);
    }
}
