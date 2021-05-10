using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace third_person_controller
{
    [CreateAssetMenu(fileName = "New State", menuName = "Character/AbilityData/ToggleGravity")]
    public class ToggleGravity : StateData
    {
        public bool on;
        public bool onStart;
        public bool onEnd;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (onStart)
            {
                CharacterControl control = characterState.GetCharacterControl(animator);
                ToggleGrav(control);
            }
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (onEnd)
            {
                CharacterControl control = characterState.GetCharacterControl(animator);
                ToggleGrav(control);
            }
        }
        
        private void ToggleGrav(CharacterControl control)
        {
            control.rb.velocity = Vector3.zero;
            control.rb.useGravity = on;
        }
    }
}