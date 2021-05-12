using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace third_person_controller
{
    public class GroundChecker : MonoBehaviour
    {
        public CapsuleCollider capCollider;
        public CharacterControl control;

        // Start is called before the first frame update
        void Start()
        {
            capCollider = GetComponent<CapsuleCollider>();
            control = GetComponentInParent<CharacterControl>();
        }

        private void FixedUpdate()
        {
            control.Grounded = false;
        }
        private void OnCollisionStay(Collision collision)
        {
            foreach(ContactPoint p in collision.contacts)
            {
                Vector3 bottom = capCollider.bounds.center - (Vector3.up * capCollider.bounds.extents.y);
                Vector3 curve = bottom + (Vector3.up * capCollider.radius);

                Debug.DrawLine(curve, p.point, Color.blue, 0.5f);
                Vector3 dir = curve - p.point;

                if (dir.y > 0f)
                {
                    control.Grounded = true;
                }
            }
            
        }
    }
}
