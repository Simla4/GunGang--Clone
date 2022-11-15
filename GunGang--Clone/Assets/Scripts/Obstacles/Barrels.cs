using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Barrels : MonoBehaviour, IObstacle
{
    #region Variables

    [SerializeField] private int barrelHealth;
    [SerializeField] private bool isBarretWithPlayer = false;

    [SerializeField] private TextMeshPro barrelValueTxt;

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
                Debug.Log("Barrel with player");
            
            }
            Destroy(gameObject);
        }
    }

    #endregion
    
}
