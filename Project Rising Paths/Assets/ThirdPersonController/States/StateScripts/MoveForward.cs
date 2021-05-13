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

            if (!CheckUpperFront(control))
            {
                control.WallJump = false;
                animator.SetBool(TransitionParameter.WallJump.ToString(), false);
            }
            else
            {
                control.WallJump = true;
                animator.SetBool(TransitionParameter.WallJump.ToString(), true);
            }

            if(!control.Move)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);

                control.MoveSpeed = 0f;
                animator.SetFloat(TransitionParameter.MoveSpeed.ToString(), 0f);
                return;
            }


            if (control.Move)
            {
                control.MoveSpeed = Mathf.Max(Mathf.Abs(control.MoveX), Mathf.Abs(control.MoveY));
                animator.SetFloat(TransitionParameter.MoveSpeed.ToString(), Mathf.Max(Mathf.Abs(control.MoveX), Mathf.Abs(control.MoveY)),
                    animationSmoothing, Time.deltaTime);
                
                Vector3 moveVector = new Vector3(control.MoveX, 0f, control.MoveY);
                moveVector = control.cameraMainTransform.forward * moveVector.z + control.cameraMainTransform.right * moveVector.x;
                moveVector.y = -2f;

                    float targetAngle = Mathf.Atan2(moveVector.x, moveVector.z) * Mathf.Rad2Deg;
                    float angle = Mathf.SmoothDampAngle(control.transform.eulerAngles.y, targetAngle, ref smoothTurnVelocity, smoothTurnSpeed);
                if (moveVector != Vector3.zero && turning)
                {
                    control.transform.rotation = Quaternion.Euler(0f, angle, 0f);
                }


                if (!CheckFront(control))
                {
                    Vector3 velocity = moveVector * speed * speedGraph.Evaluate(stateInfo.normalizedTime);
                    velocity.y = control.rb.velocity.y;
                    control.rb.velocity = velocity;
                }
                else
                {
                    Debug.Log("in front of wall");
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
        
        bool CheckUpperFront(CharacterControl control)
        {
            for (int i = 5; i < 11; i++)
            {
                GameObject o = control.FrontSpheres[i];
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, blockDistance))
                {
                    return true;
                }
            }

            return false;
        }
        /*
        void stepClimb(CharacterControl control)
        {
            RaycastHit hitLower;
            if (Physics.Raycast(control.stepRayLower.transform.position, control.transform.TransformDirection(Vector3.forward), out hitLower, 0.1f))
            {
                RaycastHit hitUpper;
                if (!Physics.Raycast(control.stepRayUpper.transform.position, control.transform.TransformDirection(Vector3.forward), out hitUpper, 0.2f))
                {
                    control.rb.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
                }
            }

            RaycastHit hitLower45;
            if (Physics.Raycast(control.stepRayLower.transform.position, control.transform.TransformDirection(1.5f, 0, 1), out hitLower45, 0.1f))
            {

                RaycastHit hitUpper45;
                if (!Physics.Raycast(control.stepRayUpper.transform.position, control.transform.TransformDirection(1.5f, 0, 1), out hitUpper45, 0.2f))
                {
                    control.rb.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
                }
            }

            RaycastHit hitLowerMinus45;
            if (Physics.Raycast(control.stepRayLower.transform.position, control.transform.TransformDirection(-1.5f, 0, 1), out hitLowerMinus45, 0.1f))
            {

                RaycastHit hitUpperMinus45;
                if (!Physics.Raycast(control.stepRayUpper.transform.position, control.transform.TransformDirection(-1.5f, 0, 1), out hitUpperMinus45, 0.2f))
                {
                    control.rb.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
                }
            }
        }
        */


    }
}
