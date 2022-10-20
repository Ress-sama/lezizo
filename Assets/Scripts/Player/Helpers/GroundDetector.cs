using UnityEngine;

namespace Assets.Scripts.Player.Helpers
{
    public static class GroundDetector
    {
        public static bool CheckGround(CapsuleCollider2D capsuleCollider, float distance, int layerMak)
        {
            RaycastHit2D raycastHit = Physics2D.Raycast(capsuleCollider.bounds.center, Vector2.down,
                capsuleCollider.bounds.extents.y + distance, layerMak);
            Debug.DrawRay(capsuleCollider.bounds.center, Vector2.down *
                                                         (capsuleCollider.bounds.extents.y + distance), Color.blue);
            Debug.Log(raycastHit.collider);
            return raycastHit.collider != null;
            //animator.SetBool(AnimationParams.GROUNDED,);
        }
    }
}