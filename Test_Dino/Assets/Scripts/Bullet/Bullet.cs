using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bullet's main class
/// </summary>
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 3;
    [SerializeField] private float _speed = 0.3f;

    private float _currentLifeTime;

    private Vector3 _pointToMove;

    #region Public Methods

    /// <summary>
    /// Sets current lifetime to default
    /// </summary>
    public void SetDefaultParameters()
    {
        _pointToMove = Vector3.zero;
        _currentLifeTime = 0;
    }

    /// <summary>
    /// Sets the point where bullet will move
    /// </summary>
    /// <param name="point">Tap input position</param>
    public void SetPointToMove(Vector3 point)
    {
        _pointToMove = point;
    }

    #endregion

    private void Translate()
    {
        if (_pointToMove != Vector3.zero)
        {
            var percentage = _currentLifeTime / _lifeTime;
           // transform.position = Vector3.Lerp(_startPoint, _pointToMove, percentage);
           transform.position = Vector3.MoveTowards(transform.position, _pointToMove, _speed * percentage);
        }
    }


    private void Update()
    {
        if (_currentLifeTime < _lifeTime)
        {
            _currentLifeTime += Time.deltaTime;
            Translate();
        }
        else gameObject.SetActive(false);
    }
}
