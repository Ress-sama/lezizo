using Assets.Scripts.Utility;
using UnityEngine;

namespace Riyezu.Player.StateMachine.Abilities
{
    [CreateAssetMenu(fileName = "new Move", menuName = "Abilities/Move")]
    public class Move : Ability
    {
        [SerializeField] private float moveSpeed;
        private Player player;

        public override void StateStart(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            player = animator.GetPlayer();
        }

        public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            float velocityX =
                Mathf.MoveTowards(player.rigidbody2D.velocity.x, moveSpeed * player.InputManager.Move,
                    100 * Time.deltaTime);
            player.rigidbody2D.velocity = new Vector2(velocityX, player.rigidbody2D.velocity.y);
        }

        public override void StateEnd(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        }
    }
}