using Riyezu.Static;
using UnityEngine;

namespace Riyezu.Player
{
    public class AnimatorController
    {
        private Animator animator;

        public AnimatorController(Animator animator)
        {
            this.animator = animator;
        }

        public void SetMove(bool value)
        {
            animator.SetBool(AnimatorParams.Move.ToString(), value);
        }

        public void SetJump(bool value)
        {
            animator.SetBool(AnimatorParams.Jump.ToString(), value);
        }

        public void SetCrouch(bool value)
        {
            animator.SetBool(AnimatorParams.Crouch.ToString(), value);
        }

        public void SetSprint(bool value)
        {
            animator.SetBool(AnimatorParams.Sprint.ToString(), value);
        }
        
        public void SetPickUp(bool value)
        {
            animator.SetBool(AnimatorParams.PickUp.ToString(), value);
        }
    }
}