using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Barrels : MonoBehaviour
{
    #region Variables

    [SerializeField] private int barrelHealth;

    [SerializeField] private TextMeshPro barrelValueTxt;

    #endregion

    #region Callbacks

    private void OnEnable()
    {
        EventManager.OnBulletCollison += ChangeBarrelValue;
    }

    private void OnDisable()
    {
        EventManager.OnBulletCollison -= ChangeBarrelValue;
    }

    #endregion

    #region Other Methods

    private void ChangeBarrelValue()
    {
        barrelHealth--;
        barrelValueTxt.text = barrelHealth.ToString();
    }

    #endregion
    
}
