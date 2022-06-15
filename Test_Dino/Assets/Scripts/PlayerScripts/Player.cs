using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player's facade
/// </summary>
public class Player : MonoBehaviour
{
    private PlayerAnimator _playerAnimator;
    /// <summary>
    /// Singleton of a player
    /// </summary>
    public static Player instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            _playerAnimator = new PlayerAnimator(GetComponentInChildren<Animator>());
        }
    }

}
