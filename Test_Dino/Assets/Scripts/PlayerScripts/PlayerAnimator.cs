using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

/// <summary>
/// The animation player's controller
/// </summary>
public class PlayerAnimator
{
    #region TriggersNames

    private const string idle = "ToIdle";
    private const string run = "Run";
    private const string shoot = "Shoot";

    #endregion

    private Animator _playerAnimator;

    /// <summary>
    /// Constructor for player's animator controller
    /// </summary>
    /// <param name="playerAnimator">The animator of player</param>
    public PlayerAnimator(Animator playerAnimator)
    {
        _playerAnimator = playerAnimator;
    }

    #region Public Functions

    
    /// <summary>
    /// Sets idle animation to player
    /// </summary>
    public void IdleAnim()
    {
        ResetAllTriggers();
        _playerAnimator.SetTrigger(idle);
    }
    /// <summary>
    /// Sets run animation to player
    /// </summary>
    public void RunAnim()
    {
        ResetAllTriggers();
        _playerAnimator.SetTrigger(run);
    }
    /// <summary>
    /// Sets shoot animation to player
    /// </summary>
    public void ShootAnim()
    {
        ResetAllTriggers();
        _playerAnimator.SetTrigger(shoot);
    }

    #endregion

    void ResetAllTriggers()
    {
        _playerAnimator.ResetTrigger(idle);
        _playerAnimator.ResetTrigger(run);
        _playerAnimator.ResetTrigger(shoot);
    }

}
