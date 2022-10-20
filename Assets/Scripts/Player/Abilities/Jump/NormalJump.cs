using System;
using Assets.Scripts.Player.Helpers;
using StellarConquest.Presentation.Unity;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [Serializable]
    public class NormalJump : IJump
    {
        [Range(0, 1)] public float JumpTiming;
        public float JumpForce;

        [SerializeField] private LayerMask layerMask;
        [SerializeField] [Range(0, 1)] private float distance;
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody2D rigidbody2D;

        private StateMachineBehaviorListener startJumpListener;
        private StateMachineBehaviorListener loopJumpListener;
        private StateMachineBehaviorListener landingJumpListener;

        private bool jumped;


        public void Init()
        {
            startJumpListener =
                animator.GetStateMachineBehaviorListener(AnimationState.JUMP_START_IDLE);

            loopJumpListener =
                animator.GetStateMachineBehaviorListener(AnimationState.JUMP_LOOP_IDLE);

            landingJumpListener =
                animator.GetStateMachineBehaviorListener(AnimationState.JUMP_LANDING_IDLE);

            startJumpListener.OnStateUpateEvent += JumpStartUpdateState;
            landingJumpListener.OnStateExitEvent += JumpLandingExitState;
            loopJumpListener.OnStateUpateEvent += _ => GroundCheck();
        }


        public void Jump()
        {
            animator.SetBool("jumping", true);
        }

        private void ForceUp()
        {
            if (!jumped)
            {
                rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
                jumped = true;
            }
        }

        private void JumpStartUpdateState(AnimatorStateInfo animatorStateInfo)
        {
            if (JumpTiming <= animatorStateInfo.normalizedTime)
            {
                ForceUp();
            }
        }

        private void JumpLandingExitState()
        {
            animator.SetBool("jumping", false);
            jumped = false;
        }

        private void GroundCheck()
        {
            animator.SetBool("grounded",
                GroundDetector.CheckGround(rigidbody2D.GetComponent<CapsuleCollider2D>(), distance, layerMask));
        }
    }
}