using System.Collections.Generic;
using Riyezu.Static;
using UnityEngine;

namespace Riyezu.Player.StateMachine.Abilities
{
    [CreateAssetMenu(fileName = "new GroundDetect", menuName = "Abilities/GroundDetect")]
    public class GroundDetect : Ability
    {
        private CapsuleCollider2D capsuleCollider;

        [SerializeField] private LayerMask layerMask;
        [SerializeField] [Range(0, 5)] private float detectDistance;

        private List<Vector3> rayStartVectors;

        public override void StateStart(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            capsuleCollider = animator.GetComponentInParent<CapsuleCollider2D>();
            rayStartVectors = new List<Vector3>()
            {
                new Vector3(capsuleCollider.bounds.min.x, capsuleCollider.bounds.min.y),
                new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y),
                new Vector3(capsuleCollider.bounds.max.x, capsuleCollider.bounds.min.y),
            };
        }

        public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            rayStartVectors = new List<Vector3>()
            {
                new Vector3(capsuleCollider.bounds.min.x, capsuleCollider.bounds.min.y),
                new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y),
                new Vector3(capsuleCollider.bounds.max.x, capsuleCollider.bounds.min.y),
            };
            animator.SetBool(AnimatorParams.Ground.ToString(), CheckGround());
        }

        public override void StateEnd(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        }

        bool CheckGround()
        {
            Collider2D collider2D = null;
            foreach (var rayStartVector in rayStartVectors)
            {
                RaycastHit2D raycastHit = Physics2D.Raycast(rayStartVector, Vector2.down,
                    detectDistance, layerMask);
                Debug.DrawRay(rayStartVector, Vector2.down * detectDistance, Color.red);
                if (raycastHit.collider != null)
                {
                    collider2D = raycastHit.collider;
                }
            }
            return collider2D != null;
        }
    }
}