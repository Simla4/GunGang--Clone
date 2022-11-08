using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    #region Variables
    private Vector2 firstMousePos, inputDrag;
    private bool isGameStart = false;

    #endregion

    #region Callbacks

    private void Update()
    {
        StartGameInput();
        PlayerFireInput();
    }

    #endregion
    
    #region OtherMethods

    private void PlayerFireInput()
    {
        if (isGameStart == true)
        {
            if (Input.GetMouseButton(0))
            {
                EventManager.OnPlayerFire?.Invoke();
            }
        }
    }

    private void StartGameInput()
    {
        
        if (isGameStart == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                EventManager.OnGameStart?.Invoke();
                isGameStart = true;
            }
        }
        
    }
    public void HandleInput()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            firstMousePos = Input.mousePosition;
        }
        if(Input.GetMouseButton(0))
        {
            var deltaPos = (Vector2)Input.mousePosition - firstMousePos;
            inputDrag = deltaPos;
            firstMousePos = Input.mousePosition;
        }
        else
        {
            inputDrag = Vector2.zero;
        }
    }

    public Vector2 GetInputDrag()
    {
        return inputDrag;
    }

    #endregion
}