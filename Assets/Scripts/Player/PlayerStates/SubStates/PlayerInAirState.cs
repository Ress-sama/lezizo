using PlayEatRepeat.Player.Data;
using UnityEngine;

namespace PlayEatRepeat.Player.PlayerStates.SubStates
{
    public class PlayerInAirState : PlayerState
    {
        private bool isGrounded;
        private float groundDistance;
        private bool flag;

        public PlayerInAirState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData,
            string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.ColliderUpdater.SetParameters(new Vector2(1.65f, 4.3f), new Vector2(0.4f, 3.7f), 15);
            player.ColliderUpdater.UpdateCollider = true;
            flag = false;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (isGrounded)
            {
                playerStateMachine.ChangeState(player.IdleLandState);
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();
            isGrounded = player.GroundDetector.CheckGround();
            groundDistance = player.DistanceCalculator.GetDistance(Vector2.down, LayerMask.GetMask("ground"));
        }
    }
}