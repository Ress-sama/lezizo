using System;
using StellarConquest.Presentation.Unity;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

namespace Assets.Scripts.Player.Abilities.Move
{
    [Serializable]
    public class NormalMove : IMove
    {
        [SerializeField] private float moveSpeed;

        private Rigidbody2D rigidbody2D;
        private Animator animator;

        private Vector2 velocity;

        private StateMachineBehaviorListener walkStateListener;

        public void Init(Rigidbody2D rigidbody2D, Animator animator)
        {
            this.rigidbody2D = rigidbody2D;
            this.animator = animator;

            walkStateListener = animator.GetStateMachineBehaviorListener(AnimationState.WALK);
        }

        public void Move(float moveInput)
        {
            float velocityX =
                Mathf.MoveTowards(rigidbody2D.velocity.x, moveSpeed * moveInput, 20 * Time.deltaTime);
            rigidbody2D.velocity = new Vector2(velocityX, rigidbody2D.velocity.y);
            velocity = rigidbody2D.velocity;
            animator.SetFloat("walkAnimSpeed", MathF.Abs(velocityX) / moveSpeed);
            if (MathF.Abs(velocityX) <= 0.1f)
            {
                animator.SetBool("moving", false);
            }
            else
            {
                animator.SetBool("moving", true);
            }
        }
    }
}