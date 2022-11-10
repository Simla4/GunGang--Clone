using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    #region Variables

    [SerializeField] private float bulletSpeed = 8f;

    #endregion

    #region Callbacks

    void Update()
    {
        transform.position += Vector3.forward * (Time.deltaTime * bulletSpeed);
    }

    #endregion
}
