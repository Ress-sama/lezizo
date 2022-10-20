using UnityEngine;

namespace Assets.Scripts.Player.Abilities.Move
{
    public interface IMove
    {
        void Init(Rigidbody2D rigidbody2D, Animator animator);
        void Move(float moveInput);
    }
}