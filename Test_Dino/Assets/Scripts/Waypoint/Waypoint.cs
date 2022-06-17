using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    /// Enemies holder component in waypoint
    /// </summary>
    [HideInInspector] public EnemiesHolder enemiesHolder { get; private set; }
    /// <summary>
    /// Triggers an event if waypoint is cleaned from enemies
    /// </summary>
    public UnityEvent<Waypoint> WaypointCleaned = new UnityEvent<Waypoint>();

    /// <summary>
    /// Initialize a waypoint
    /// </summary>
    public void InitializeWaypoint()
    {
        playerPlace = GetComponentInChildren<PlayerPlace>();
        enemiesHolder = GetComponentInChildren<EnemiesHolder>();

        foreach (var enemy in enemiesHolder.enemies)
        {
            enemy.enemyBody.EnemyDestroyed.AddListener(CheckLeftEnemies);
        }
    }

    private void CheckLeftEnemies(Enemy enemy)
    {
        enemy.enemyBody.EnemyDestroyed.RemoveListener(CheckLeftEnemies);
        if(enemiesHolder.RemoveEnemyAndCheckIsLast(enemy))
            WaypointCleaned?.Invoke(this);
    }
}
