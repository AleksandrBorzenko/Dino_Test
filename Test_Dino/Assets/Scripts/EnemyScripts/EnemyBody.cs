using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBody : MonoBehaviour
{
    /// <summary>
    /// Event which is called when the player destroys an enemy
    /// </summary>
    [HideInInspector] public UnityEvent<EnemyBody> EnemyDestroyed = new UnityEvent<EnemyBody>();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Bullet bullet))
        {
            EnemyDestroyed?.Invoke(this);
            transform.parent.gameObject.SetActive(false);
        }
    }
}
