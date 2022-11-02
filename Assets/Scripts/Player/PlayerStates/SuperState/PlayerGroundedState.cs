using PlayEatRepeat.Player.Data;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace PlayEatRepeat.Player.PlayerStates.SuperState
{
    public abstract class PlayerGroundedState : PlayerState
    {
        protected float xAxisInput;
        protected bool JumpInput;

        public PlayerGroundedState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData,
            string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
        {
        }

        public override void LogicUpdate()
        {
            xAxisInput = player.InputSystem.Player.Movement.ReadValue<float>();
            player.InputSystem.Player.Jump.started += _ => JumpInput = true;
            player.InputSystem.Player.Jump.canceled += _ => JumpInput = false;
            Turn();
        }

        private void Turn()
        {
            if (xAxisInput > 0)
            {
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (xAxisInput < 0)
            {
                player.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}