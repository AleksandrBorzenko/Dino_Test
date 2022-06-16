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

    public void InitializePool()
    {
        _bulletPool = new Pool<Bullet>(_bulletPrefab,_poolCapacity,transform);
    }

    public void CreateBullet(Vector3 position)
    {
        var bullet = _bulletPool.GetFreeElement();
        bullet.transform.position = position;
    }
}
