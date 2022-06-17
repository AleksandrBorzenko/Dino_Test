using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Bullet bullet))
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}
