using Riyezu.Player;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public static class AnimatorExtensions
    {
        public static Player GetPlayer(this Animator animator)
        {
            return animator.GetComponentInParent<Player>();
        }
    }
}