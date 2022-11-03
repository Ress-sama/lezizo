using PlayEatRepeat.Player.Data;
using PlayEatRepeat.Player.PlayerStates.SuperState;
using UnityEditor.Rendering;
using UnityEngine;

namespace PlayEatRepeat.Player.PlayerStates.SubStates
{
    public class PlayerIdleLandState : PlayerGroundedState
    {
        private Vector2 colliderSize;
        private float colliderSizeUpdateSpeed;
        private Vector2 colliderOffset;
        private float colliderOffsetUpdateSpeed;

        bool isGrounded;

        public PlayerIdleLandState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData,
            string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.ColliderUpdater.SetParameters(new Vector2(1.61f, 5.14f), new Vector2(0.2f, 4.05f), 15);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            float stateTime = Time.time - startTime;
            if (stateTime < 0.2)
            {
                return;
            }

            if (xAxisInput != 0)
            {
                playerStateMachine.ChangeState(player.WalkState);
            }
            else if (JumpInput && isGrounded)
            {
                playerStateMachine.ChangeState(player.IdleJumpState);
            }
            else
            {
                playerStateMachine.ChangeState(player.IdleState);
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();
            isGrounded = player.GroundDetector.CheckGround();
        }
    }
}