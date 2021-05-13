using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace third_person_controller
{
    public class NetworkPlayer : MonoBehaviour
    {
        public Transform body;
        public Animator animator;

        private PhotonView photonView;

        private CharacterControl runner;
        private Transform bodyObject;

        // Start is called before the first frame update
        void Start()
        {
            photonView = GetComponent<PhotonView>();
            runner = FindObjectOfType<CharacterControl>();
            bodyObject = runner.transform.Find("Gremilin");

            if (photonView.IsMine)
            {
                foreach (var item in GetComponentsInChildren<Renderer>())
                {
                    item.enabled = false;
                }
            }

        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine)
            {
                MapPosition(body, bodyObject);
                UpdateAnimator(animator);
            }
        }
        void MapPosition(Transform target, Transform bodyTransform)
        {
            target.position = bodyTransform.position;
            target.rotation = bodyTransform.rotation;
            target.localScale = bodyTransform.localScale;
        }

        void UpdateAnimator(Animator animator)
        {
            animator.SetBool(TransitionParameter.Move.ToString(), runner.Move);
            animator.SetFloat(TransitionParameter.MoveSpeed.ToString(), runner.MoveSpeed);
            animator.SetBool(TransitionParameter.Jump.ToString(), runner.Jump);
            animator.SetBool(TransitionParameter.ForceTransition.ToString(), runner.ForceTransition);
            animator.SetBool(TransitionParameter.Grounded.ToString(), runner.Grounded);
            animator.SetBool(TransitionParameter.LedgeGrabbed.ToString(), runner.LedgeGrabbed);
            animator.SetBool(TransitionParameter.WallJump.ToString(), runner.WallJump);
        }
    }
}
