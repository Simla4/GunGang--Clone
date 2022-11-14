using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    #region Variables

    

    #endregion

    #region Callbacks

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IObstacle obstacle))
        {
            obstacle.Dissapear();
        }
    }

    #endregion
}
