using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player's place in each waypoint
/// </summary>
public class PlayerPlace : MonoBehaviour
{
    /// <summary>
    /// The transform parameter of place
    /// where player have to stay in waypoint
    /// </summary>
    public Transform playerPlaceInWaypoint => transform;
}
