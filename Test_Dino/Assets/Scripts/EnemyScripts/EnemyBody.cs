using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBody : MonoBehaviour
{
    /// <summary>
    /// Event which is called when the player destroys an enemy
    /// </summary>
    [HideInInspector] public UnityEvent<Enemy> EnemyDestroyed = new UnityEvent<Enemy>();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Bullet bullet))
        {
            EnemyDestroyed?.Invoke(transform.parent.GetComponent<Enemy>());
            transform.parent.gameObject.SetActive(false);
        }
    }
}
