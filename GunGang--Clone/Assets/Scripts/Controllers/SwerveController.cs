using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveController : MonoBehaviour
{
    #region Variables

    [SerializeField] Transform sideMovementRoot;

    [SerializeField] private float sideMovementSensitivity;
    [SerializeField] private float leftLimit, rightLimit;    

    #endregion

    #region Callbacks
    private void Update()
    {
        InputManager.Instance.HandleInput();
        HandleSideMovement();
    }

    #endregion

    #region OtherMethods

    private void HandleSideMovement()
    {
        var localPos = sideMovementRoot.localPosition;
        var inputDrag = InputManager.Instance.GetInputDrag();
        
        localPos += Vector3.right * inputDrag.x * sideMovementSensitivity;

        localPos.x = Mathf.Clamp(localPos.x, leftLimit, rightLimit);

        sideMovementRoot.localPosition = localPos;
    
    }

    #endregion
}