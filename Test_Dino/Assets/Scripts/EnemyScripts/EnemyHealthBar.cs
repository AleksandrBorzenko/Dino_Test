using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UI health bar of enemy
/// </summary>
public class EnemyHealthBar : MonoBehaviour
{
    private Image _healthBar;

    private void Awake()
    {
        _healthBar = transform.GetChild(1).GetComponent<Image>();
    }
    /// <summary>
    /// Updates the UI health bar
    /// </summary>
    /// <param name="newHP">New HP</param>
    /// <param name="oldHP">Old HP</param>
    public void UpdateHealthBar(float newHP, float oldHP)
    {
        _healthBar.fillAmount = newHP/oldHP;
    }
}
