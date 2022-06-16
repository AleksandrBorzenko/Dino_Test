using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Main controller of game process
/// </summary>
public class GameController : MonoBehaviour
{
    [SerializeField] private WaypointsHolder waypointsHolder;

    private void Start()
    {
        waypointsHolder.InitializePointsOnScene();
        Debug.Log(waypointsHolder.waypoints.Count);
    }
}
