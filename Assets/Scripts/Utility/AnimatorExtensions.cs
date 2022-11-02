using Riyezu.Player;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public static class AnimatorExtensions
    {
        public static Riyezu.Player.Player GetPlayer(this Animator animator)
        {
            return animator.GetComponentInParent<Riyezu.Player.Player>();
        }
    }
}