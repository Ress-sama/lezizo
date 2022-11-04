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

            float velocityX =
                Mathf.MoveTowards(Mathf.Abs(player.VelocityX), playerData.MoveSpeed,
                    35 * Time.deltaTime);

            player.SetVelocityX(velocityX* xInput);
        }
    }
}