using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Enemy facade
/// </summary>
public class Enemy : MonoBehaviour
{
    /// <summary>
    /// Enemy body component
    /// </summary>
    public EnemyBody enemyBody { get; private set; }

    private PlayerAnimator _playerAnimator;
    private void Awake()
    {
        _playerAnimator = new PlayerAnimator(GetComponent<Animator>());
        _playerAnimator.IdleAnim();
        enemyBody = GetComponentInChildren<EnemyBody>();
    }

}
