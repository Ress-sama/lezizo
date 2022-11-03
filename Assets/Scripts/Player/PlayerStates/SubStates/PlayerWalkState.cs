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
            if (xInput == 0)
            {
                playerStateMachine.ChangeState(player.IdleState);
            }

            if (JumpInput)
            {
                playerStateMachine.ChangeState(player.WalkJumpState);
            }

            if (SprintInput)
            {
                playerStateMachine.ChangeState(player.RunState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            player.SetVelocityX(playerData.MoveSpeed, xInput, 80);
        }
    }
}