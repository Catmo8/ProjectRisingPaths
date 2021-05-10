using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace third_person_controller
{
    [CreateAssetMenu(fileName = "New State", menuName = "Character/AbilityData/Jump")]
    public class Jump : StateData
    {
        public float jumpForce;
        public AnimationCurve gravity;
        public AnimationCurve pull;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterState.GetCharacterControl(animator).rb.AddForce(Vector3.up * jumpForce);
            animator.SetBool(TransitionParameter.Grounded.ToString(), false);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            control.gravityMultiplier = gravity.Evaluate(stateInfo.normalizedTime);
            control.pullMultiplier = pull.Evaluate(stateInfo.normalizedTime);

            if (control.LedgeGrabbed)
            {
                animator.SetBool(TransitionParameter.LedgeGrabbed.ToString(), true);
            }
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }
}
