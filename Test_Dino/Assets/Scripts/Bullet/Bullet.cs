using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bullet's main class
/// </summary>
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 3;
    [SerializeField] private float _speed = 20f;

    private float _currentLifeTime;
    private float _stopDistance=0.01f;

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
        if (Vector3.Distance(transform.position, _pointToMove) > _stopDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointToMove, _speed * Time.deltaTime);
        }
        else
        {
            transform.position = _pointToMove;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
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
