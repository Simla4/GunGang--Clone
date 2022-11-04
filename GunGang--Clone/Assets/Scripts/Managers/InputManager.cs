using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    #region Variables
    private Vector2 firstMousePos, inputDrag;
    private bool isGameStart = false;

    #endregion
    
    #region OtherMethods

    public void HandleInput()
    {
        if (isGameStart == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                EventManager.OnGameStart?.Invoke();
            }
        }
        
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