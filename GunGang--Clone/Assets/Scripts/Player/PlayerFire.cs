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
            StartCoroutine(IEBulletMaker());
        }
    }

    IEnumerator IEBulletMaker()
    {
        GameObject spawnedObj = null;
        
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            
            var posX = transform.position.x;
            var posZ = transform.position.z;
        
            // spawnedObj = Instantiate(bulletPrefab);
            // spawnedObj.transform.position = new Vector3(posX, 1f, posZ);
            
            spawnedObj = ObjectPooler.Instance.SpanwObject(bulletPrefab);
            spawnedObj.transform.position = new Vector3(posX, 1, posZ);
            
            Debug.Log("in if"+ spawnedObj);
        }
        
        yield return new WaitForSeconds(bulletExtinctionTime);
        
        //Destroy(spawnedObj);
        
        Debug.Log(spawnedObj);
        
        ObjectPooler.Instance.RemoveObject(spawnedObj);
    }

    #endregion
}
