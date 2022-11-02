using PlayEatRepeat.Player.Data;
using PlayEatRepeat.Player.PlayerStates.SuperState;
using UnityEngine;

namespace PlayEatRepeat.Player.PlayerStates.SubStates
{
    public class PlayerIdleState : PlayerGroundedState
    {
        public PlayerIdleState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData,
            string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (xAxisInput != 0)
            {
                player.StateMachine.ChangeState(player.WalkState);
            }
            Debug.Log(JumpInput);
        }
    }
}