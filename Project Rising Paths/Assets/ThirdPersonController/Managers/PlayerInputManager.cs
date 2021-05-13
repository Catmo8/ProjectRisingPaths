using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace third_person_controller
{
    public class PlayerInputManager : MonoBehaviour
    {
        [SerializeField, Tooltip("Input action Vector2 movement")]
        private InputActionReference movementControl = null;

        [SerializeField, Tooltip("Input action for button/float jump")]
        private InputActionReference jumpControl = null;

        [SerializeField, Tooltip("Input action for accessing menu")]
        private InputActionReference menuControl = null;

        #region setup
        private void OnEnable()
        {
            if (movementControl != null) movementControl.action.Enable();
            if (jumpControl != null) jumpControl.action.Enable();
            if (menuControl != null) menuControl.action.Enable();
        }

        private void OnDisable()
        {
            if (movementControl != null) movementControl.action.Disable();
            if (jumpControl != null) jumpControl.action.Disable();
            if (menuControl != null) menuControl.action.Disable();
        }
        #endregion setup

        void Update()
        {
            Vector3 movement = movementControl.action.ReadValue<Vector2>();
            if (movement.x != 0 || movement.y != 0)
            {
                VirtualInputManger.Instance.Move = true;
                VirtualInputManger.Instance.MoveX = movement.x;
                VirtualInputManger.Instance.MoveY = movement.y;
            }
            else
            {
                VirtualInputManger.Instance.Move = false;
                VirtualInputManger.Instance.MoveX = 0f;
                VirtualInputManger.Instance.MoveY = 0f;
            }

            if(jumpControl.action.triggered)
            {
                VirtualInputManger.Instance.Jump = true;
            }
            else
            {
                VirtualInputManger.Instance.Jump = false;
            }

            if(menuControl.action.triggered)
            {
                VirtualInputManger.Instance.Menu = true;
            }
            else
            {
                VirtualInputManger.Instance.Menu = false;
            }
        }
    }
}
