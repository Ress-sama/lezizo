using PlayEatRepeat.Player.Data;
using PlayEatRepeat.Player.PlayerStates.SuperState;
using UnityEngine;

namespace PlayEatRepeat.Player.PlayerStates.SubStates
{
    public class PlayerWalkState : PlayerGroundedState
    {
        private float timeElapsed;
        private float lerpDuration;

        public PlayerWalkState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData,
            string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            lerpDuration = 0.2f;
            timeElapsed = 0;
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
            /*float velocityX = playerData.MoveSpeed;
            if (lerpDuration > timeElapsed)
            {
                velocityX = Mathf.Lerp(Mathf.Abs(player.VelocityX), playerData.MoveSpeed, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
            }*/

            //current 0

            //target 6 * xInput

            // difference = target - target 6 * xInput ( 6 )

            float target = playerData.MoveSpeed * xInput;
            float differenceVelocity = target - player.VelocityX;
            player.AddVelocityX(differenceVelocity * 0.4f);
        }
    }
}