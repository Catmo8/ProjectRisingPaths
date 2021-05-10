using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace third_person_controller
{
    public enum TransitionConditionType
    {
        JUMP,
        GRABBING_LEDGE,
    }

    [CreateAssetMenu(fileName = "New State", menuName = "Character/AbilityData/TransitionIndexer")]
    public class TransitionIndexer : StateData
    {
        public int Index;
        public List<TransitionConditionType> transitionConditions = new List<TransitionConditionType>();

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.Jump.ToString(), false);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        private bool MakeTransition(CharacterControl control)
        {
            foreach(TransitionConditionType c in transitionConditions)
            {
                switch(c)
                {
                    case TransitionConditionType.JUMP:
                        {

                        }
                        break;
                    case TransitionConditionType.GRABBING_LEDGE:
                        {

                        }
                        break;
                }
            }
            return true;
        }
    }
}
