using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class which represents each waypoint on scene
/// </summary>
public class Waypoint : MonoBehaviour
{
    /// <summary>
    /// Player's place component in waypoint
    /// </summary>
    [HideInInspector] public PlayerPlace playerPlace;
    /// <summary>
    /// Initialize a waypoint
    /// </summary>
    public void InitializeWaypoint()
    {
        playerPlace = GetComponentInChildren<PlayerPlace>();
    }
}
