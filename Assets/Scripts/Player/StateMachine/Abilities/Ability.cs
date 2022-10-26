using UnityEngine;

namespace Riyezu.Player.StateMachine.Abilities
{
    public abstract class Ability : ScriptableObject
    {
        public abstract void StateStart(Animator animator, AnimatorStateInfo stateInfo, int layerIndex);
        public abstract void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex);
        public abstract void StateEnd(Animator animator, AnimatorStateInfo stateInfo, int layerIndex);
    }
}