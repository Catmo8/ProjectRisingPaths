using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace third_person_controller
{
    public class ManualInput : MonoBehaviour
    {
        private CharacterControl characterControl;

        private void Awake()
        {
            characterControl = this.gameObject.GetComponent<CharacterControl>();
        }

        void Update()
        {
            characterControl.Move = VirtualInputManger.Instance.Move;
            characterControl.MoveX = VirtualInputManger.Instance.MoveX;
            characterControl.MoveY = VirtualInputManger.Instance.MoveY;
            characterControl.Jump = VirtualInputManger.Instance.Jump;
        }
    }
}
