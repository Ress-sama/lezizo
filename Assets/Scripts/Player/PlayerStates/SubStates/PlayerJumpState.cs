using PlayEatRepeat.Player.Data;
using PlayEatRepeat.Player.PlayerStates.SuperState;

namespace PlayEatRepeat.Player.PlayerStates.SubStates
{
    public class PlayerJumpState : PlayerAbilityState
    {
        public PlayerJumpState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData,
            string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
        {
        }
    }
}