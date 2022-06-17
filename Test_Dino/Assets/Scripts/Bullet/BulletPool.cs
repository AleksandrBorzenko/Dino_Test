using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A bullet objects pool
/// </summary>
public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _poolCapacity;

    private Pool<Bullet> _bulletPool;
    /// <summary>
    /// Initializing a bullet pool
    /// </summary>

    #region Public Methods

    public void InitializePool()
    {
        _bulletPool = new Pool<Bullet>(_bulletPrefab, _poolCapacity, transform);
    }
    /// <summary>
    /// Create bullet from pool in specified startPosition
    /// </summary>
    /// <param name="startPosition">Specified startPosition</param>
    public void CreateBullet(Vector3 startPosition, Vector3 targetPosition, int damage)
    {
        var bullet = _bulletPool.GetFreeElement();
        bullet.transform.position = startPosition;
        bullet.SetDefaultParameters(damage);
        bullet.SetPointToMove(targetPosition);
    }

    #endregion
}
