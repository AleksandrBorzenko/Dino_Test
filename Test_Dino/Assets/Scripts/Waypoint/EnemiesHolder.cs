using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Holder for enemies in a waypoint
/// </summary>
public class EnemiesHolder : MonoBehaviour
{
    public List<Enemy> enemies { get; private set; } = new List<Enemy>();

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            enemies.Add(child.GetComponent<Enemy>());
        }
    }
}
