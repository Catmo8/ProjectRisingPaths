using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace third_person_controller
{
    [CreateAssetMenu(fileName = "New State", menuName = "Character/AbilityData/ForceTransition")]
    public class ForceTransition : StateData
    {
        [Range(0.01f, 1f)]
        public float transitionTiming;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= transitionTiming)
            {
                animator.SetBool(TransitionParameter.ForceTransition.ToString(), true);
            }
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.ForceTransition.ToString(), false);
        }
    }
}
