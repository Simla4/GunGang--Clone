using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    public Pool<Bullet> bulletPool { get; } = new Pool<Bullet>();
    [SerializeField] private Bullet bulletPrefab;

    private void Awake()
    {
        bulletPool.Initialize(bulletPrefab);
    }
}
