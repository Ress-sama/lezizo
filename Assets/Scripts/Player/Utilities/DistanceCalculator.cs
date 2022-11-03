using UnityEngine;

namespace Assets.Scripts.Player.Detectors
{
    public class DistanceCalculator
    {
        private float maxRayDistance = 10;
        private CapsuleCollider2D capsuleCollider;

        public DistanceCalculator(CapsuleCollider2D capsuleCollider)
        {
            this.capsuleCollider = capsuleCollider;
        }

        public float GetDistance(Vector2 direction, LayerMask layer)
        {
            Vector2 raycastVector = capsuleCollider.bounds.center;
            RaycastHit2D raycastHit = Physics2D.Raycast(raycastVector, direction,
                maxRayDistance, layer);
            Debug.DrawRay(raycastVector, direction * maxRayDistance, Color.green);
            if (raycastHit.collider == null) return maxRayDistance;
            return raycastHit.distance;
        }
    }
}