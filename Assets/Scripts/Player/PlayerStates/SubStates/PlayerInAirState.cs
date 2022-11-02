using PlayEatRepeat.Player.Data;

namespace PlayEatRepeat.Player.PlayerStates.SubStates
{
    public class PlayerInAirState : PlayerState
    {
        public PlayerInAirState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData,
            string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
        {
        }
    }
}