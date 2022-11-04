using PlayEatRepeat.Player.Data;
using UnityEngine;

namespace PlayEatRepeat.Player.PlayerStates.SuperState
{
    public class PlayerAbilityState : PlayerState
    {
        protected bool isGrounded;
        protected bool isAbilityDone;

        protected float xInput;

        public PlayerAbilityState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData,
            string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            isAbilityDone = false;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            isGrounded = player.GroundDetector.CheckGround();
            xInput = player.InputSystem.Player.Movement.ReadValue<float>();

            if (isAbilityDone)
            {
                Debug.Log(isGrounded);

                if (isGrounded)
                {
                    playerStateMachine.ChangeState(player.IdleState);
                }
                else
                {
                    playerStateMachine.ChangeState(player.InAirState);
                }
            }

            player.Animator.SetFloat("MoveThreshold", Mathf.Abs(player.VelocityX));
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }
    }
}