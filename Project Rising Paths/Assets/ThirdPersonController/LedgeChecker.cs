using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace third_person_controller
{
    public class LedgeChecker : MonoBehaviour
    {
        public GameObject collidingObject;
        public LayerMask canLedgeGrab;
        public float distanceBelowLedge;
        public CharacterControl control;

        // Start is called before the first frame update
        void Start()
        {
            control = GetComponentInParent<CharacterControl>();
            control.LedgeGrabbed = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            collidingObject = collision.gameObject;
            if (((1 << collidingObject.layer) & canLedgeGrab) != 0)
            {
                ContactPoint contact = collision.GetContact(0);
                if(collision.collider.bounds.max.y - contact.point.y <= distanceBelowLedge)
                {
                    control.LedgeGrabbed = true;
                    control.lastLedgeContact = contact.point;
                    Debug.Log("Collider Contact Point : " + contact.point);
                    Debug.Log("Collider bound Maximum : " + collision.collider.bounds.max);
                }
            }
            
        }
        private void OnCollisionExit(Collision collision)
        {
            control.LedgeGrabbed = false;
        }
    }
}
