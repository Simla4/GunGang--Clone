using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class GameManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private PathFollower pathFollower;

    [SerializeField] private float speed = 5f;

    #endregion

    #region Callbacks

    private void OnEnable()
    {
        EventManager.OnGameStart += TapToStart;
    }

    private void OnDisable()
    {
        EventManager.OnGameStart -= TapToStart;
    }

    #endregion

    #region OtherMethods

    private void TapToStart()
    {
        pathFollower.speed = speed;
    }

    #endregion
}
