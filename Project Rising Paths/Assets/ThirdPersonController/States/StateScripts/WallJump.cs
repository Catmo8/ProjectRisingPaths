using UnityEngine;

namespace third_person_controller
{
    [CreateAssetMenu(fileName = "New State", menuName = "Character/AbilityData/WallJump")]
    public class WallJump : StateData
    {
        public float jumpForce;
        public float wallJumpForce;
        public AnimationCurve gravity;
        public AnimationCurve pull;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            animator.SetBool(TransitionParameter.Grounded.ToString(), false);

            Vector3 finalJump = Vector3.up + control.lastWallJumpContact;
            control.transform.forward = control.lastWallJumpContact;
            finalJump.x *= wallJumpForce;
            finalJump.y *= jumpForce;
            finalJump.z *= wallJumpForce;
            control.rb.AddForce(finalJump);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            control.gravityMultiplier = gravity.Evaluate(stateInfo.normalizedTime);
            control.pullMultiplier = pull.Evaluate(stateInfo.normalizedTime);
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }
}