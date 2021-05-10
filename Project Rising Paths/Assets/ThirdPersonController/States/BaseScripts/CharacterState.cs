using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace third_person_controller
{
    public class CharacterState : StateMachineBehaviour
    {
        public List<StateData> listAbilityData = new List<StateData>();

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach(StateData d in listAbilityData)
            {
                d.OnEnter(this, animator, stateInfo);
            }
        }
        public void UpdateAll(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            foreach(StateData d in listAbilityData)
            {
                d.UpdateAbility(characterState, animator, stateInfo);
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            UpdateAll(this, animator, stateInfo);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach(StateData d in listAbilityData)
            {
                d.OnExit(this, animator, stateInfo);
            }
        }

        private CharacterControl characterControl;

        public CharacterControl GetCharacterControl(Animator animator)
        {
            if (characterControl == null)
            {
                characterControl = animator.GetComponentInParent<CharacterControl>();
            }
            return characterControl;
        }
    }


}