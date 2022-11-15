using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollison : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IObstacle obstacle))
        {
            obstacle.WhenBulletHits();
            
            ObjectPooler.Instance.RemoveObject(gameObject, 0);
        }
    }
}
