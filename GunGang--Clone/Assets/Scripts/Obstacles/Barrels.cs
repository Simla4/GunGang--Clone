using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Barrels : MonoBehaviour, ICollideable, IDestroyable
{
    #region Variables

    [SerializeField] private int barrelHealth;
    [SerializeField] private bool isBarretWithPlayer = false;

    [SerializeField] private TextMeshPro barrelValueTxt;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private PlayerFire playerFire;

    #endregion

    #region Callbacks

    private void Start()
    {
        barrelValueTxt.text = barrelHealth.ToString();
    }

    #endregion
    
    #region Other Methods

    public void WhenBulletHits()
    {
        barrelHealth--;
        barrelValueTxt.text = barrelHealth.ToString();
        
        DestroyBarrel();
    }

    private void DestroyBarrel()
    {
        
        if (barrelHealth <= 0)
        {
            if (isBarretWithPlayer == true)
            {
                var playerTransform = GameManager.Instance.soldierList[0].transform;
                
                playerPrefab.transform.SetParent(playerTransform);
                playerFire.isPlayerMyTeam = true;

            }
            Destroy(gameObject);
        }
    }

    public void OnCollide()
    {
        
    }

    #endregion
    
}
