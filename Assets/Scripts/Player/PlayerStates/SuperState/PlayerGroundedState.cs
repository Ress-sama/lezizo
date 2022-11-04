using PlayEatRepeat.Player.Data;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace PlayEatRepeat.Player.PlayerStates.SuperState
{
    public abstract class PlayerGroundedState : PlayerState
    {
        protected float xInput;
        protected bool JumpInput;
        protected bool SprintInput;

        protected bool IsGrounded;

        public PlayerGroundedState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData,
            string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            xInput = player.InputSystem.Player.Movement.ReadValue<float>();
            player.InputSystem.Player.Jump.started += _ => JumpInput = true;
            player.InputSystem.Player.Jump.canceled += _ => JumpInput = false;
            player.InputSystem.Player.Sprint.started += _ => SprintInput = true;
            player.InputSystem.Player.Sprint.canceled += _ => SprintInput = false;
            player.Animator.SetFloat("MoveThreshold", Mathf.Abs(player.VelocityX));
            Turn();
        }

        public override void DoChecks()
        {
            base.DoChecks();
            IsGrounded = player.GroundDetector.CheckGround();
        }

        private void Turn()
        {
            if (xInput > 0)
            {
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (xInput < 0)
            {
                player.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}