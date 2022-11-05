using PlayEatRepeat.Player.Data;
using PlayEatRepeat.Player.PlayerStates.SuperState;
using UnityEngine;

namespace PlayEatRepeat.Player.PlayerStates.SubStates
{
    public class PlayerRunState : PlayerGroundedState
    {
        private float timeElapsed;
        private float lerpDuration;

        public PlayerRunState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData,
            string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            lerpDuration = 0.9f;
            timeElapsed = 0;
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
                playerStateMachine.ChangeState(player.RunJumpState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            /*
            float velocityX =
                Mathf.Lerp(player.VelocityX, playerData.MoveSpeed * xInput,
                    35 * Time.deltaTime);
            player.SetVelocityX(velocityX);
        */
            float target = playerData.MoveSpeed * 2f * xInput;
            float differenceVelocity = target - player.VelocityX;
            player.AddVelocityX(differenceVelocity * 0.4f);
        }
    }
}