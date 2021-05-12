using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace third_person_controller
{
    public class VirtualInputManger : Singleton<VirtualInputManger>
    {
        public bool Move;
        public float MoveX;
        public float MoveY;
        public bool Jump;
        public bool Menu;
    }
}
