using System.Collections.Generic;
using Assets.Scripts.Utility;
using Riyezu.Player.StateMachine.Abilities;
using UnityEngine;

namespace Riyezu.Player.StateMachine
{
    public class PlayerStateMachine : StateMachineBehaviour
    {
        [SerializeField] private List<Ability> abilities = new List<Ability>();
        private Player player;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            foreach (var detector in abilities)
            {
                detector.StateStart(animator, stateInfo, layerIndex);
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);
            foreach (var detector in abilities)
            {
                detector.StateUpdate(animator, stateInfo, layerIndex);
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            foreach (var detector in abilities)
            {
                detector.StateEnd(animator, stateInfo, layerIndex);
            }
        }
    }
}