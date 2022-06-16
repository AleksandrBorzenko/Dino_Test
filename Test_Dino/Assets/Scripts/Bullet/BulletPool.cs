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
    /// Create bullet from pool in specified position
    /// </summary>
    /// <param name="position">Specified position</param>
    public void CreateBullet(Vector3 position)
    {
        var bullet = _bulletPool.GetFreeElement();
        bullet.transform.position = position;
        bullet.SetCurrentLifeTimeToMax();
    }

    #endregion
}
