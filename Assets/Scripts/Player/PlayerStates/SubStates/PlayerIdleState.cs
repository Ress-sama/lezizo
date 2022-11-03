using PlayEatRepeat.Player.Data;
using PlayEatRepeat.Player.PlayerStates.SuperState;
using UnityEngine;

namespace PlayEatRepeat.Player.PlayerStates.SubStates
{
    public class PlayerIdleState : PlayerGroundedState
    {
        private Vector2 colliderSize;
        private float colliderSizeUpdateSpeed;
        private Vector2 colliderOffset;
        private float colliderOffsetUpdateSpeed;

        private float colliderUpdateTime;

        public PlayerIdleState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData,
            string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
           // player.ColliderUpdater.SetParameters(new Vector2(1.51f, 5.14f), new Vector2(0, 1.43f), 15);
            player.ColliderUpdater.UpdateCollider = true;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (xInput != 0)
            {
                playerStateMachine.ChangeState(player.WalkState);
            }

            if (JumpInput)
            {
                playerStateMachine.ChangeState(player.IdleJumpState);
            }
        }
    }
}