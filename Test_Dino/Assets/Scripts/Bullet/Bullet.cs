using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Bullet's main class
/// </summary>
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 3;
    [SerializeField] private float _speed = 3;

    private float _currentLifeTime;


    #region Public Methods
    /// <summary>
    /// Sets current lifetime to default
    /// </summary>
    public void SetCurrentLifeTimeToMax()
    {
        _currentLifeTime = _lifeTime;
    }
    /// <summary>
    /// Bullet translates to point
    /// </summary>
    /// <param name="point">Tap input position</param>
    public void TranslateToPoint(Vector3 point)
    {
        transform.Translate(point);
    }

    #endregion

    

    private void Update()
    {
        if (_currentLifeTime > 0) _currentLifeTime -= Time.deltaTime;
        else gameObject.SetActive(false);
    }
}
