using System;
using System.Collections.Generic;
using Assets.Scripts.Player;
using UnityEngine;
using AnimationState = Assets.Scripts.Player.AnimationState;

namespace StellarConquest.Presentation.Unity
{
    public class StateMachineBehaviorListener : StateMachineBehaviour
    {
        public event Action OnStateEnterEvent;
        public event Action<AnimatorStateInfo> OnStateUpateEvent;
        public event Action OnStateExitEvent;
        public AnimationState AnimationState;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            OnStateEnterEvent?.Invoke();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);
            OnStateUpateEvent?.Invoke(stateInfo);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            OnStateExitEvent?.Invoke();
        }
    }
}