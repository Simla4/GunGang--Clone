using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollison : MonoBehaviour
{
    #region Variables

    [SerializeField] private Bullet bullet;

    private Pool<Bullet> bulletPool;

    #endregion

    private void Start()
    {
        bulletPool = PoolManager.Instance.bulletPool;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDestroyable obstacle))
        {
            obstacle.WhenBulletHits();
            
            bulletPool.ReturnToPool(bullet);
        }
    }
}
