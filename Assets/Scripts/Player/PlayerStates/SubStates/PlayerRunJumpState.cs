using PlayEatRepeat.Player.Data;
using PlayEatRepeat.Player.PlayerStates.SuperState;
using UnityEngine;

namespace PlayEatRepeat.Player.PlayerStates.SubStates
{
    public class PlayerRunJumpState : PlayerAbilityState
    {
        private bool isJump;

        private float addForceTime;
        private float abilityDoneTime;

        public PlayerRunJumpState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData,
            string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            isJump = false;
            addForceTime = 0.01f;
            abilityDoneTime = 0.4f;
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
                player.SetVelocityX(Mathf.Abs(player.VelocityX) * 1.5f * xInput);
                //player.SetVelocityX(playerData.MoveSpeed*10,xInput,500);
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