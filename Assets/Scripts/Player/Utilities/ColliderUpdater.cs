using UnityEngine;

namespace Assets.Scripts.Player.Detectors
{
    public class ColliderUpdater
    {
        private CapsuleCollider2D capsuleCollider { get; set; }

        private Vector2 targetSize;
        private Vector2 targetOffset;
        private float updateSpeed { get; set; }
        public bool UpdateCollider { get; set; }


        public ColliderUpdater(CapsuleCollider2D capsuleCollider)
        {
            this.capsuleCollider = capsuleCollider;
        }

        public void UpdateColliderSize()
        {
            if (UpdateCollider == false) return;
            if (Vector2.SqrMagnitude(capsuleCollider.size - targetSize) > 0.01)
            {
                capsuleCollider.size = Vector2.Lerp(capsuleCollider.size, targetSize, Time.deltaTime * updateSpeed);
            }
        }

        public void UpdateColliderOffset()
        {
            if (UpdateCollider == false) return;
            if (Vector2.SqrMagnitude(capsuleCollider.offset - targetOffset) > 0.01)
            {
                capsuleCollider.offset =
                    Vector2.Lerp(capsuleCollider.offset, targetOffset, Time.deltaTime * updateSpeed);
            }
        }

        public void SetParameters(Vector2 targetSize, Vector2 targetOffset, float updateSpeed)
        {
            this.targetSize = targetSize;
            this.targetOffset = targetOffset;
            this.updateSpeed = updateSpeed;
        }
    }
}