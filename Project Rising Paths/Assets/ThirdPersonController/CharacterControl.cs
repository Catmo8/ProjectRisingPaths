using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace third_person_controller
{
    public enum TransitionParameter
    {
        Move,
        MoveSpeed,
        Jump,
        ForceTransition,
        Grounded,
        TransitionIndex,
        LedgeGrabbed,
        WallJump,
    }
    public class CharacterControl : MonoBehaviour
    {
        //Virtual Input Manager stuff
        public Animator animator;
        public bool Move;
        public float MoveX;
        public float MoveY;
        public bool Jump;
        public bool Menu;

        //Ledge stuff
        public bool LedgeGrabbed;
        public Vector3 lastLedgeContact;

        //WallJump stuff
        public bool WallJump;
        public Vector3 lastWallJumpContact;

        public float MoveSpeed;
        public bool Grounded;
        public bool ForceTransition;

        public Transform cameraMainTransform;
        public Rigidbody rb;

        public GameObject colliderEdgePrefab;
        public List<GameObject> BottomSpheres = new List<GameObject>();
        public List<GameObject> FrontSpheres = new List<GameObject>();

        //Stair stuff
        //public GameObject stepRayUpper;
        //public GameObject stepRayLower;

        public float gravityMultiplier;
        public float pullMultiplier;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            if (Menu)
            {
                if (Cursor.lockState == CursorLockMode.Locked)
                    Cursor.lockState = CursorLockMode.None;
                else if (Cursor.lockState == CursorLockMode.None)
                    Cursor.lockState = CursorLockMode.Locked;
            }

        }

        private void Awake()
        {
            SetColliderSpheres();
        }

        private void SetColliderSpheres()
        {
            BoxCollider box = GetComponent<BoxCollider>();

            float bottom = box.bounds.center.y - box.bounds.extents.y;
            float top = box.bounds.center.y + box.bounds.extents.y;
            float front = box.bounds.center.z + box.bounds.extents.z;
            float back = box.bounds.center.z - box.bounds.extents.z;

            GameObject bottomFront = CreateEdgeSphere(new Vector3(0f, bottom, front));
            GameObject bottomBack = CreateEdgeSphere(new Vector3(0f, bottom, back));
            GameObject topFront = CreateEdgeSphere(new Vector3(0f, top, front));

            bottomFront.transform.SetParent(transform, true);
            bottomBack.transform.SetParent(transform, true);
            topFront.transform.SetParent(transform, true);

            bottomFront.layer = 7;
            bottomBack.layer = 7;
            topFront.layer = 7;

            BottomSpheres.Add(bottomFront);
            BottomSpheres.Add(bottomBack);

            FrontSpheres.Add(topFront);
            FrontSpheres.Add(bottomFront);

            float horSec = (bottomFront.transform.position - bottomBack.transform.position).magnitude / 5f;
            CreateMiddleSpheres(bottomFront, -transform.forward, horSec, 4, BottomSpheres);

            float verSec = (bottomFront.transform.position - topFront.transform.position).magnitude / 10f;
            CreateMiddleSpheres(bottomFront, transform.up, verSec, 9, FrontSpheres);
        }

        private void FixedUpdate()
        {
            if (rb.velocity.y  < 0f)
            {
                rb.velocity += (-Vector3.up * gravityMultiplier);

            }

            if (rb.velocity.y > 0f && !Jump)
            {
                rb.velocity += (-Vector3.up * pullMultiplier);
            }
        }

        public void CreateMiddleSpheres(GameObject start, Vector3 dir, float sec, int interations, List<GameObject> spheresLists)
        {
            for (int i = 0; i < interations; i++)
            {
                Vector3 pos = start.transform.position + (dir * sec * (i + 1));

                GameObject newObj = CreateEdgeSphere(pos);
                newObj.transform.parent = transform;
                newObj.layer = 7;
                spheresLists.Add(newObj);
            }
        }

        public GameObject CreateEdgeSphere(Vector3  pos)
        {
            GameObject obj = Instantiate(colliderEdgePrefab, pos, Quaternion.identity);
            return obj;
        }

    }
}
