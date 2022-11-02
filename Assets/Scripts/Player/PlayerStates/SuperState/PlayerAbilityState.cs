using PlayEatRepeat.Player.Data;

namespace PlayEatRepeat.Player.PlayerStates.SuperState
{
    public class PlayerAbilityState : PlayerState
    {
        public PlayerAbilityState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData,
            string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
        {
        }
    }
}