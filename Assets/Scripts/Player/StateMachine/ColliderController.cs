using UnityEngine;

namespace Riyezu.Player.StateMachine
{
    public class ColliderController
    {
        private CapsuleCollider2D collider { get; set; }
        public bool UpdateCollider { get; set; }
        public Vector2 TargetSize { get; set; }
        public float SizeUpdateSpeed { get; set; }
        public Vector2 TargetOffset { get; set; }
        public float OffsetUpdateSpeed { get; set; }

        public ColliderController(CapsuleCollider2D capsuleCollider)
        {
            collider = capsuleCollider;
        }


        public void UpdateColliderSize()
        {
            if (UpdateCollider == false) return;
            if (Vector2.SqrMagnitude(collider.size - TargetSize) > 0.01)
            {
                collider.size = new Vector2(collider.size.x,
                    Mathf.Lerp(collider.size.y, TargetSize.y, Time.deltaTime * SizeUpdateSpeed));
            }
        }


        public void UpdateColliderOffset()
        {
            if (UpdateCollider == false) return;
            if (Vector2.SqrMagnitude(collider.offset - TargetOffset) > 0.01)
            {
                collider.offset = Vector2.Lerp(collider.offset, TargetOffset, Time.deltaTime * OffsetUpdateSpeed);
            }
        }
    }
}