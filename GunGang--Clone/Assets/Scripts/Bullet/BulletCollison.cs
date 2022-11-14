using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollison : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            EventManager.OnBulletCollison?.Invoke();
        }
    }
}
