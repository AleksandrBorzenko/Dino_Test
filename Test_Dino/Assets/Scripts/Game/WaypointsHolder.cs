using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsHolder : MonoBehaviour
{
    /// <summary>
    /// List of waypoints on scene
    /// </summary>
    public List<Waypoint> waypoints { get; } = new List<Waypoint>();
    /// <summary>
    /// Initialize all waypoints on scene
    /// </summary>
    public void InitializePointsOnScene()
    {
        foreach (Transform child in transform)
        {
            var waypoint = child.GetComponent<Waypoint>();
            waypoint.InitializeWaypoint();
            waypoints.Add(waypoint);
        }
    }
}
