using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBody : MonoBehaviour
{

    [HideInInspector] public UnityEvent<int> DamageTaken = new UnityEvent<int>();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Bullet bullet))
        {
            DamageTaken?.Invoke(bullet.damage);
        }
    }
}
