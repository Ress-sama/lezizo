using System.Collections.Generic;
using Assets.Scripts.Utility;
using Riyezu.Static;
using UnityEngine;

namespace Riyezu.Player.StateMachine.Abilities
{
    [CreateAssetMenu(fileName = "new_HeadCollisionDetector", menuName = "Abilities/HeadCollisionDetector")]
    public class HeadCollisionDetector : Ability
    {
        private Player player;

        private CapsuleCollider2D capsuleCollider;

        [SerializeField] private LayerMask layerMask;
        [SerializeField] [Range(0, 5)] private float detectDistance;

        private List<Vector3> rayStartVectors;

        public override void StateStart(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            player = animator.GetPlayer();
            capsuleCollider = animator.GetComponentInParent<CapsuleCollider2D>();
        }

        public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            UpdateRayVectors();
            animator.SetBool(AnimatorParams.HeadCollision.ToString(), CheckGround());
        }

        public override void StateEnd(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        }

        bool CheckGround()
        {
            Collider2D collider2D = null;
            foreach (var rayStartVector in rayStartVectors)
            {
                RaycastHit2D raycastHit = Physics2D.Raycast(rayStartVector, Vector2.up,
                    detectDistance, layerMask);
                Debug.DrawRay(rayStartVector, Vector2.up * detectDistance, Color.blue);
                if (raycastHit.collider != null)
                {
                    collider2D = raycastHit.collider;
                }
            }

            return collider2D != null;
        }

        void UpdateRayVectors()
        {
            rayStartVectors = new List<Vector3>()
            {
                new Vector3(capsuleCollider.bounds.min.x, capsuleCollider.bounds.max.y),
                new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.max.y),
                new Vector3(capsuleCollider.bounds.max.x, capsuleCollider.bounds.max.y),
            };
        }
    }
}