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
                player.StateMachine.ChangeState(player.IdleState);
            }
        }

        public override void PhysicsUpdate()
        {
            float velocityX =
                Mathf.MoveTowards(player.Rigidbody2D.velocity.x, playerData.MoveSpeed * xAxisInput,
                    80 * Time.deltaTime);
            player.Rigidbody2D.velocity = new Vector2(velocityX, player.Rigidbody2D.velocity.y);
        }
    }
}