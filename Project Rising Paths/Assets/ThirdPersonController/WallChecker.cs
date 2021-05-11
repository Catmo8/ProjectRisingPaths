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
                if (collision.GetContact(0).normal.y < 0.1f)
                {
                    control.lastWallJumpContact = collision.GetContact(0).normal;
                    Debug.DrawRay(collision.GetContact(0).point,control.lastWallJumpContact,  Color.green, 30f);
                }
            }
        }
    }
}
