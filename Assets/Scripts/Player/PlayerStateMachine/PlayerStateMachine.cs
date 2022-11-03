using UnityEngine;

namespace PlayEatRepeat.Player
{
    public class PlayerStateMachine
    {
        public PlayerState CurrentState { get; set; }

        public void Initialize(PlayerState startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }

        public void ChangeState(PlayerState playerState)
        {
            CurrentState.Exit();
            CurrentState = playerState;
            CurrentState.Enter();
        }
    }
}