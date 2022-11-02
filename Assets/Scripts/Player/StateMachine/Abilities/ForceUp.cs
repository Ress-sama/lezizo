using Assets.Scripts.Utility;
using UnityEngine;

namespace Riyezu.Player.StateMachine.Abilities
{
    [CreateAssetMenu(fileName = "new ForceUp", menuName = "Abilities/ForceUp")]
    public class ForceUp : Ability
    {
        [SerializeField] [Range(0, 1)] private float timing;
        [SerializeField] [Range(0, 2000)] private float upForce;
        [SerializeField] private Vector2 angle;
        private Player player;
        private bool jump;

        public override void StateStart(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            jump = false;
            player = animator.GetPlayer();
        }

        public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (stateInfo.normalizedTime >= timing && jump == false)
            {
                player.rigidbody2D.AddForce(new Vector2(angle.x * player.InputManager.Move, angle.y) * upForce,
                    ForceMode2D.Impulse);
                jump = true;
            }
        }

        public override void StateEnd(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            jump = false;
        }
    }
}