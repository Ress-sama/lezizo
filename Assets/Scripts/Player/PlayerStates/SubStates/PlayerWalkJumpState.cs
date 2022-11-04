using PlayEatRepeat.Player.Data;
using PlayEatRepeat.Player.PlayerStates.SuperState;
using UnityEngine;

namespace PlayEatRepeat.Player.PlayerStates.SubStates
{
    public class PlayerWalkJumpState : PlayerAbilityState
    {
        private bool isJump;
        private bool colliderUpdated;

        private float addForceTime;
        private float abilityDoneTime;
        private float colliderUpdateTime;

        public PlayerWalkJumpState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData,
            string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            isJump = false;
            colliderUpdated = false;
            addForceTime = 0.18f;
            abilityDoneTime = 0.4f;
            colliderUpdateTime = 0.22f;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            float stateTime = Time.time - startTime;
            CheckAddForceByTime(stateTime);
            CheckAbilityDoneByTime(stateTime);
            //CheckUpdateColliderByTime(stateTime);
        }

        public override void Exit()
        {
            base.Exit();
            player.ColliderUpdater.UpdateCollider = false;
        }

        private void CheckAddForceByTime(float time)
        {
            if (time > addForceTime && !isJump)
            {
                player.SetVelocityY(playerData.JumpForce);
                player.SetVelocityX(5 * xInput);
                isJump = true;
            }
        }

        private void CheckAbilityDoneByTime(float time)
        {
            if (time > abilityDoneTime)
            {
                isAbilityDone = true;
            }
        }
    }
}