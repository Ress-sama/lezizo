using PlayEatRepeat.Player.Data;
using PlayEatRepeat.Player.PlayerStates.SuperState;

namespace PlayEatRepeat.Player.PlayerStates.SubStates
{
    public class PlayerRunState : PlayerGroundedState
    {
        public PlayerRunState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData,
            string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            SprintInput = true;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (xInput == 0)
            {
                playerStateMachine.ChangeState(player.IdleState);
            }
            else if (!SprintInput && xInput != 0)
            {
                playerStateMachine.ChangeState(player.WalkState);
            }
            else if (JumpInput)
            {
                playerStateMachine.ChangeState(player.WalkJumpState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            player.SetVelocityX(playerData.MoveSpeed + playerData.MoveSpeed * 1.5f, xInput, 80);
        }
    }
}