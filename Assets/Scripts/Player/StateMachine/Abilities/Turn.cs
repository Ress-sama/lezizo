using Assets.Scripts.Utility;
using UnityEngine;

namespace Riyezu.Player.StateMachine.Abilities
{
    [CreateAssetMenu(fileName = "new Turn", menuName = "Abilities/Turn")]

    public class Turn : Ability
    {
        private Player player;
        public override void StateStart(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            player = animator.GetPlayer();
        }

        public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (player.PlayerInputs.Move>0)
            {
                player.rigidbody2D.transform.rotation =
                    Quaternion.Euler(0, 0, 0);
            }
            else if (player.PlayerInputs.Move<0)
            {
                player.rigidbody2D.transform.rotation =
                    Quaternion.Euler(0, 180, 0);
            }
        }

        public override void StateEnd(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        }
    }
}