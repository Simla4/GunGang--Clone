using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    #region Variables

    [SerializeField] private bool isPlayerMyTeam = false;
    [SerializeField] private float bulletExtinctionTime = 1f;
    [SerializeField] private float fireRate = 0.5f;

    private float nextFire = 0f;

    #endregion

    #region Callbacks

    private void OnEnable()
    {
        EventManager.OnPlayerFire += Fire;
    }

    private void OnDisable()
    {
        EventManager.OnPlayerFire -= Fire;
    }

    #endregion

    #region OtherMethods

    // ReSharper disable Unity.PerformanceAnalysis
    private void Fire()
    {
        if (isPlayerMyTeam == true)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                
                StartCoroutine(IEBulletMaker());
            }
        }
    }

    IEnumerator IEBulletMaker()
    {
        
        var posX = transform.position.x;
        var posZ = transform.position.z;
        
            
        var spawnedObj = ObjectPooler.Instance.SpanwObject(0);
        spawnedObj.transform.position = new Vector3(posX, 1, posZ);
        
        yield return new WaitForSeconds(bulletExtinctionTime);
        
        ObjectPooler.Instance.RemoveObject(spawnedObj, 0);
    }

    #endregion
}
