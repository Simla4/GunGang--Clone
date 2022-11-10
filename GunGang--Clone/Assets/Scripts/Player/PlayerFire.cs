using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    #region Variables

    [SerializeField] private bool isPlayerMyTeam = false;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletExtinctionTime = 1f;
    [SerializeField] private float nextFire = 0.5f;

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
            StartCoroutine(IEBulletMaker());
        }
    }

    IEnumerator IEBulletMaker()
    {
               
        Debug.Log("Fire");

        var posX = transform.position.x;
        var posZ = transform.position.z;
        
        var spanedObj =  Instantiate(bulletPrefab);

        spanedObj.transform.position = new Vector3(posX, 1f, posZ);
        
        yield return new WaitForSeconds(bulletExtinctionTime);
        
        Destroy(spanedObj);
    }

    #endregion
}
