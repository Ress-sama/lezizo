using Riyezu.Static;
using UnityEngine;

namespace Riyezu.Player.StateMachine.Abilities
{
    [CreateAssetMenu(fileName = "new GroundDetect",menuName = "Abilities/GroundDetect")]
    public class GroundDetect : Ability
    {
        private CapsuleCollider2D capsuleCollider;

        [SerializeField] private LayerMask layerMask;
        [SerializeField] [Range(0, 1)] private float detectDistance;

        public override void StateStart(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            capsuleCollider = animator.GetComponentInParent<CapsuleCollider2D>();
        }

        public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool(AnimatorParams.Ground.ToString(), CheckGround());
        }

        public override void StateEnd(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        }

        bool CheckGround()
        {
            RaycastHit2D raycastHit = Physics2D.Raycast(capsuleCollider.bounds.center, Vector2.down,
                capsuleCollider.bounds.extents.y + detectDistance, layerMask);
            Debug.DrawRay(capsuleCollider.bounds.center, Vector2.down *
                                                         (capsuleCollider.bounds.extents.y + detectDistance),
                Color.blue);
            return raycastHit.collider != null;
        }
    }
}