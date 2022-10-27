using Assets.Scripts.Utility;
using UnityEngine;

namespace Riyezu.Player.StateMachine.Abilities
{
    [CreateAssetMenu(fileName = "new UpdateCollider", menuName = "Abilities/UpdateCollider")]
    public class UpdateCollider : Ability
    {
        [SerializeField] private Vector2 targetSize;
        [SerializeField] private float sizeUpdateSpeed;
        [SerializeField] private Vector2 targetOffset;
        [SerializeField] private float offSetUpdateSpeed;
        private Player player;

        public override void StateStart(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            player = animator.GetPlayer();
            player.ColliderController.UpdateCollider = true;
            player.ColliderController.TargetOffset = targetOffset;
            player.ColliderController.OffsetUpdateSpeed = offSetUpdateSpeed;
            player.ColliderController.TargetSize = targetSize;
            player.ColliderController.SizeUpdateSpeed = sizeUpdateSpeed;
        }

        public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        }

        public override void StateEnd(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        }
    }
}