using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Enemy facade
/// </summary>
public class Enemy : MonoBehaviour, IVital
{
    private const int _maxRandomHealth = 5;
    private const int _minRandomHealth = 1;

    public int currentMaxHealth { get; private set; }

    private EnemyHealthBar _healthBar;

    /// <summary>
    /// Enemy body component
    /// </summary>
    public EnemyBody enemyBody { get; private set; }

    /// <summary>
    /// The health points of enemy
    /// </summary>
    public int health { get; private set; }

    /// <summary>
    /// The damage of enemy
    /// </summary>
    public int damage => 1;

    private PlayerAnimator _playerAnimator;

    /// <summary>
    /// Event which is called when the player destroys an enemy
    /// </summary>
    [HideInInspector] public UnityEvent<Enemy> EnemyDestroyed = new UnityEvent<Enemy>();

    private void Awake()
    {
        _playerAnimator = new PlayerAnimator(GetComponent<Animator>());
        _playerAnimator.IdleAnim();
        enemyBody = GetComponentInChildren<EnemyBody>();
        enemyBody.DamageTaken.AddListener(TakeDamage);

        currentMaxHealth = Random.Range(_minRandomHealth, _maxRandomHealth);
        health = currentMaxHealth;
        _healthBar = GetComponentInChildren<EnemyHealthBar>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        _healthBar.UpdateHealthBar(health, currentMaxHealth);
        if (health <= 0)
        {
            EnemyDestroyed?.Invoke(this);
            gameObject.SetActive(false);
        }
    }


    private void OnDisable()
    {
        enemyBody.DamageTaken.RemoveListener(TakeDamage);
    }
}
