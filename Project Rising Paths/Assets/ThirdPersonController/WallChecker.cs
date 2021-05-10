using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace third_person_controller
{
    public class WallChecker : MonoBehaviour
    {
        public GameObject collidingObject;
        public LayerMask canWallJump;
        public CharacterControl control;

        // Start is called before the first frame update
        void Start()
        {
            control = GetComponentInParent<CharacterControl>();
        }

        private void OnCollisionStay(Collision collision)
        {
            collidingObject = collision.gameObject;
            if (((1 << collidingObject.layer) & canWallJump) != 0)
            {
                control.lastWallJumpContact = collision.GetContact(0).normal;
            }
        }
    }
}
