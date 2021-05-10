using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace third_person_controller
{
    [CreateAssetMenu(fileName = "New State", menuName = "Character/AbilityData/MoveForward")]
    public class MoveForward : StateData
    {
        public float speed;
        public AnimationCurve speedGraph;
        public bool turning;
        public float smoothTurnSpeed;
        public float animationSmoothing;
        public float blockDistance;

        float smoothTurnVelocity;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo  stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if (control.Jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), true);
            }

                    animator.SetFloat(TransitionParameter.MoveSpeed.ToString(), Mathf.Max(Mathf.Abs(control.MoveX), Mathf.Abs(control.MoveY)),
                           animationSmoothing, Time.deltaTime);
            if(!control.Move)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                animator.SetFloat(TransitionParameter.MoveSpeed.ToString(), 0f);
                return;
            }


            if (control.Move)
            {
                Vector3 moveVector = new Vector3(control.MoveX, 0f, control.MoveY);
                moveVector = control.cameraMainTransform.forward * moveVector.z + control.cameraMainTransform.right * moveVector.x;
                moveVector.y = 0f;

                if (moveVector != Vector3.zero && turning)
                {
                    float targetAngle = Mathf.Atan2(moveVector.x, moveVector.z) * Mathf.Rad2Deg;
                    float angle = Mathf.SmoothDampAngle(control.transform.eulerAngles.y, targetAngle, ref smoothTurnVelocity, smoothTurnSpeed);
                    control.transform.rotation = Quaternion.Euler(0f, angle, 0f);
                }

                if (!CheckFront(control))
                {
                    Vector3 velocity = moveVector * speed * speedGraph.Evaluate(stateInfo.normalizedTime);
                    velocity.y = control.rb.velocity.y;
                    control.rb.velocity = velocity;
                }
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        bool CheckFront(CharacterControl control)
        {
            foreach (GameObject o in control.FrontSpheres)
            {
                Debug.DrawRay(o.transform.position, control.transform.forward * 0.3f, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, blockDistance))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
