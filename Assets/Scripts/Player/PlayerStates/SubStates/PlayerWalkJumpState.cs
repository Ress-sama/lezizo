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
            CheckUpdateColliderByTime(stateTime);
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
                Debug.Log(xInput);
                player.AddForce(new Vector2(xInput * 0.3f, 1), playerData.JumpForce);
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

        private void CheckUpdateColliderByTime(float time)
        {
            if (time > colliderUpdateTime && !colliderUpdated)
            {
                colliderUpdated = true;
                player.ColliderUpdater.SetParameters(new Vector2(1.72f, 5.14f), new Vector2(0.26f, 3.14f), 15);
                player.ColliderUpdater.UpdateCollider = true;
            }
        }
    }
}