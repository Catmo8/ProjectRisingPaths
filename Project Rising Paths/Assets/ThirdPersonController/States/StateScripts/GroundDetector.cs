using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace third_person_controller
{
    [CreateAssetMenu(fileName = "New State", menuName = "Character/AbilityData/GroundDetector")]
    public class GroundDetector : StateData
    {
        [Range(0.01f, 1f)]
        public float checkTime;
        public float distance;
        //public LayerMask groundMask;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if (stateInfo.normalizedTime >= checkTime)
            {
                if(control.Grounded)
                {
                    //control.Grounded = true;
                    animator.SetBool(TransitionParameter.Grounded.ToString(), true);
                }
                else
                {
                    //control.Grounded = false;
                    animator.SetBool(TransitionParameter.Grounded.ToString(), false);
                }
            }
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        bool IsGrounded(CharacterControl control)
        {
            if (control.rb.velocity.y > -0.001f && control.rb.velocity.y <= 0f )
            {
                return true;
            }

            if (control.rb.velocity.y < 0f)
            {
                for (int i = 3; i < 5; i++)
                {
                    GameObject o = control.BottomSpheres[i];
                    Debug.DrawRay(o.transform.position, -Vector3.up * 0.7f, Color.yellow);
                    RaycastHit hit;
                    //if (Physics.Raycast(o.transform.position, -Vector3.up, out hit, distance))
                    if (Physics.CheckSphere(o.transform.position, distance))
                    {
                        return true;
                    }
                }
                /*
                if (Physics.CheckSphere(control.transform.position, 0.2f, groundMask))
                {
                    return true;
                }
                */
            }

            return false;
        }
    }
}
