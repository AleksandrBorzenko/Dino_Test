using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Holder for enemies in a waypoint
/// </summary>
public class EnemiesHolder : MonoBehaviour
{
    /// <summary>
    /// List of enemies in a waypoint
    /// </summary>
    public List<Enemy> enemies { get; private set; } = new List<Enemy>();

    private void Awake()
    {
        if (transform.childCount==0) return;
        
        foreach (Transform child in transform)
        {
            enemies.Add(child.GetComponent<Enemy>());
        }
    }
    /// <summary>
    /// Remove enemy and check if it's last enemy in waypoint
    /// </summary>
    /// <param name="enemy">Enemy to remove</param>
    /// <returns>True if no enemies, false if enemies are in a waypoint</returns>
    public bool RemoveEnemyAndCheckIsLast(Enemy enemy)
    {
        enemies.Remove(enemy);
        if (enemies.Count == 0)
            return true;
        return false;
    }
}
