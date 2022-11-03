using PlayEatRepeat.Player.Data;
using PlayEatRepeat.Player.PlayerStates.SuperState;
using UnityEngine;

namespace PlayEatRepeat.Player.PlayerStates.SubStates
{
    public class PlayerWalkState : PlayerGroundedState
    {
        public PlayerWalkState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData,
            string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (xAxisInput == 0)
            {
                playerStateMachine.ChangeState(player.IdleState);
            }

            if (JumpInput)
            {
                playerStateMachine.ChangeState(player.WalkJumpState);
            }
        }

        public override void PhysicsUpdate()
        {
            player.SetVelocityX(playerData.MoveSpeed, xAxisInput, 80);
        }
    }
}