using Assets.Scripts.Utility;
using Riyezu.Static;
using UnityEngine;

namespace Riyezu.Player.StateMachine.Abilities
{
    [CreateAssetMenu(fileName = "new Move", menuName = "Abilities/Move")]
    public class Move : Ability
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float smooth;
        private Player player;

        public override void StateStart(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            player = animator.GetPlayer();
        }

        public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            float velocityX =
                Mathf.MoveTowards(player.rigidbody2D.velocity.x, moveSpeed * player.InputManager.Move,
                    smooth * Time.deltaTime);
            animator.SetFloat(AnimatorParams.Velocity.ToString(), Mathf.Abs(velocityX / moveSpeed+0.1f));
            player.rigidbody2D.velocity = new Vector2(velocityX, player.rigidbody2D.velocity.y);
        }

        public override void StateEnd(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        }
    }
}