using Riyezu.Player.StateMachine;
using UnityEngine;

namespace Riyezu.Player
{
    public class Player : MonoBehaviour
    {
        private InputSystem inputSystem;
        public InputManager InputManager { get; set; }
        private AnimatorController animatorController;
        public ColliderController ColliderController { get; set; }
        public Rigidbody2D rigidbody2D { get; private set; }

        private void Awake()
        {
            inputSystem = new InputSystem();
            InputManager = new InputManager();
            animatorController = new AnimatorController(GetComponentInChildren<Animator>());
            ColliderController = new ColliderController(GetComponent<CapsuleCollider2D>());
            inputSystem.Player.Enable();
            inputSystem.Player.Jump.canceled += _ => animatorController.SetJump(false);
            inputSystem.Player.Jump.started += _ => animatorController.SetJump(true);
            inputSystem.Player.Movement.started += _ => animatorController.SetMove(true);
            inputSystem.Player.Movement.canceled += _ => animatorController.SetMove(false);
            inputSystem.Player.Crouch.started += _ => animatorController.SetCrouch(true);
            inputSystem.Player.Crouch.canceled += _ => animatorController.SetCrouch(false);
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            ColliderController.UpdateColliderSize();
            ColliderController.UpdateColliderOffset();
            InputManager.Move = inputSystem.Player.Movement.ReadValue<float>();
        }
    }
}