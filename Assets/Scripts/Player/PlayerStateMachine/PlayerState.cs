using PlayEatRepeat.Player.Data;
using UnityEngine;

namespace PlayEatRepeat.Player
{
    public abstract class PlayerState
    {
        protected Player player;
        protected PlayerData playerData;
        protected PlayerStateMachine playerStateMachine;

        protected float startTime;

        private string animationBoolName;

        public PlayerState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData,
            string animationBoolName)
        {
            this.player = player;
            this.playerStateMachine = playerStateMachine;
            this.playerData = playerData;
            this.animationBoolName = animationBoolName;
        }


        public virtual void Enter()
        {
            DoChecks();
            player.Animator.SetBool(animationBoolName, true);
            startTime = Time.time;
        }

        public virtual void Exit()
        {
            player.Animator.SetBool(animationBoolName, false);
        }

        public virtual void LogicUpdate()
        {
        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks()
        {
        }
    }
}