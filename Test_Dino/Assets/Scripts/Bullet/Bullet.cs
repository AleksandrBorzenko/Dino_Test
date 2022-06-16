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

    private Vector3 _pointToMove;

    #region Public Methods
    /// <summary>
    /// Sets current lifetime to default
    /// </summary>
    public void SetDefaultParameters()
    {
        _pointToMove = Vector3.zero;
        _currentLifeTime = _lifeTime;
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
            transform.position = Vector3.MoveTowards(transform.position, _pointToMove, Time.deltaTime*_speed);
    }

    private void Update()
    {
        if (_currentLifeTime > 0)
        {
            Translate();
            _currentLifeTime -= Time.deltaTime;
        }
        else gameObject.SetActive(false);
    }
}
