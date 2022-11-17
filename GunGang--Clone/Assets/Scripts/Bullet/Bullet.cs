using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, ISpawn, IDespawn
{
    #region Variables

    public bool isReturnPool;

    #endregion
    
    #region Other Methods

    public void Spawn()
    {
        isReturnPool = false;
        gameObject.SetActive(true);
    }

    public void Despawn()
    {
        isReturnPool = true;
        transform.position = Vector3.zero;
    }

    #endregion
}
