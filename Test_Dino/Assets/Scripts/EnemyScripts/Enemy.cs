using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Enemy facade
/// </summary>
public class Enemy : MonoBehaviour, IVital
{
    private const int _maxHealth = 5;
    private const int _minHealth = 1;

    /// <summary>
    /// Enemy body component
    /// </summary>
    public EnemyBody enemyBody { get; private set; }
    /// <summary>
    /// The health points of enemy
    /// </summary>
    public int health { get; private set; }

    private PlayerAnimator _playerAnimator;
    private void Awake()
    {
        _playerAnimator = new PlayerAnimator(GetComponent<Animator>());
        _playerAnimator.IdleAnim();
        enemyBody = GetComponentInChildren<EnemyBody>();
        health = Random.Range(_minHealth, _maxHealth);
    }

}
