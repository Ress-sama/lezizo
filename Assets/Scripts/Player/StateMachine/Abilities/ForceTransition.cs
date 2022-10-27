using Riyezu.Static;
using UnityEngine;

namespace Riyezu.Player.StateMachine.Abilities
{
    [CreateAssetMenu(fileName = "new ForceTransition",menuName = "Abilities/ForceTransition")]
    public class ForceTransition : Ability
    {
        [SerializeField] private float forceTransitionTiming;

        public override void StateStart(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        }

        public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (stateInfo.normalizedTime >= forceTransitionTiming)
            {
                animator.SetBool(AnimatorParams.ForceTransition.ToString(), true);
            }
        }

        public override void StateEnd(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool(AnimatorParams.ForceTransition.ToString(), false);
        }
    }
}