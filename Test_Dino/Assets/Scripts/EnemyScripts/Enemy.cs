using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Enemy facade
/// </summary>
public class Enemy : MonoBehaviour
{
    private PlayerAnimator _playerAnimator;

    private void Start()
    {
        _playerAnimator = new PlayerAnimator(GetComponent<Animator>());
        _playerAnimator.IdleAnim();
    }

}
