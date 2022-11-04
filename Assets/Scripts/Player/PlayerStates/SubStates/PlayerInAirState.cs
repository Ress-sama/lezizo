using PlayEatRepeat.Player.Data;
using UnityEngine;

namespace PlayEatRepeat.Player.PlayerStates.SubStates
{
    public class PlayerInAirState : PlayerState
    {
        private bool isGrounded;
        private float xInput;
        private float groundDistance;
        private bool flag;

        public PlayerInAirState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData,
            string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.ColliderUpdater.SetParameters(new Vector2(1.51f, 3.7f), new Vector2(0f, 1.43f), 15);
            player.ColliderUpdater.UpdateCollider = true;
            flag = false;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            xInput = player.InputSystem.Player.Movement.ReadValue<float>();

            if (isGrounded || groundDistance < 5)
            {
                playerStateMachine.ChangeState(player.IdleLandState);
            }

            Turn();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            float velocityX =
                Mathf.MoveTowards(Mathf.Abs(player.VelocityX), playerData.MoveSpeed / 2,
                    50 * Time.deltaTime);
            player.SetVelocityX(velocityX * xInput);
        }

        public override void DoChecks()
        {
            base.DoChecks();
            isGrounded = player.GroundDetector.CheckGround();
            groundDistance = player.DistanceCalculator.GetDistance(Vector2.down, LayerMask.GetMask("ground"));
        }

        private void Turn()
        {
            if (xInput > 0)
            {
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (xInput < 0)
            {
                player.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}