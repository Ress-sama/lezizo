using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player.Detectors
{
    public class GroundDetector
    {
        private CapsuleCollider2D capsuleCollider;

        public LayerMask LayerMask { get; set; }
        public float DetectDistance { get; }

        public GroundDetector(CapsuleCollider2D capsuleCollider)
        {
            this.capsuleCollider = capsuleCollider;
            LayerMask = 8;
            DetectDistance = 0.2f;
        }

        public bool CheckGround()
        {
            List<Vector3> rayStartVectors = new List<Vector3>()
            {
                new(capsuleCollider.bounds.min.x, capsuleCollider.bounds.min.y),
                new(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y),
                new(capsuleCollider.bounds.max.x, capsuleCollider.bounds.min.y),
            };

            Collider2D collider2D = null;
            foreach (var rayStartVector in rayStartVectors)
            {
                RaycastHit2D raycastHit = Physics2D.Raycast(rayStartVector, Vector2.down,
                    DetectDistance, LayerMask);
                Debug.DrawRay(rayStartVector, Vector2.down * DetectDistance, Color.red);
                if (raycastHit.collider != null)
                {
                    collider2D = raycastHit.collider;
                }
            }

            capsuleCollider.GetComponentInChildren<Animator>().SetBool("Grounded", collider2D != null);

            return collider2D != null;
        }

        public bool CheckGround(float distance)
        {
            List<Vector3> rayStartVectors = new List<Vector3>()
            {
                new(capsuleCollider.bounds.min.x, capsuleCollider.bounds.min.y),
                new(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y),
                new(capsuleCollider.bounds.max.x, capsuleCollider.bounds.min.y),
            };

            Collider2D collider2D = null;
            foreach (var rayStartVector in rayStartVectors)
            {
                RaycastHit2D raycastHit = Physics2D.Raycast(rayStartVector, Vector2.down,
                    distance, LayerMask);
                Debug.DrawRay(rayStartVector, Vector2.down * distance, Color.red);
                if (raycastHit.collider != null)
                {
                    collider2D = raycastHit.collider;
                }
            }

            capsuleCollider.GetComponentInChildren<Animator>().SetBool("Grounded", collider2D != null);

            return collider2D != null;
        }
    }
}