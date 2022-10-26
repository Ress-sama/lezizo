using Assets.Scripts.Utility;
using Riyezu.Static;
using UnityEngine;

namespace Riyezu.Player.StateMachine.Abilities
{
    [CreateAssetMenu(fileName = "IdleJumpCheck", menuName = "Abilities/Checkers/IdleJumpCheck")]
    public class IdleJumpCheck : Ability
    {
        private Player player;
        public override void StateStart(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            player = animator.GetPlayer();
            //player.inputSystem.Player.Jump.started += _ => animator.SetBool(AnimatorParams.Jump.ToString(), true);
            //player.inputSystem.Player.Jump.canceled += _ => animator.SetBool(AnimatorParams.Jump.ToString(), false);
        }

        public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        }

        public override void StateEnd(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        }
    }
}