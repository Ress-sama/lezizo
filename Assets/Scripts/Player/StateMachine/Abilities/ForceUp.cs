using Assets.Scripts.Utility;
using UnityEngine;

namespace Riyezu.Player.StateMachine.Abilities
{
    [CreateAssetMenu(fileName = "new ForceUp", menuName = "Abilities/ForceUp")]
    public class ForceUp : Ability
    {
        [SerializeField] [Range(0, 1)] private float timing;
        [SerializeField] [Range(0, 500)] private float upForce;
        private Player player;
        private bool jump;

        public override void StateStart(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            player = animator.GetPlayer();
        }

        public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (stateInfo.normalizedTime >= timing && !jump)
            {
                player.rigidbody2D.AddForce(Vector2.up * upForce, ForceMode2D.Impulse);
                jump = true;
            }
        }

        public override void StateEnd(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            jump = false;
        }
    }
}