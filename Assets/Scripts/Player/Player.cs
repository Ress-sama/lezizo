using UnityEngine;

namespace Riyezu.Player
{
    public class Player : MonoBehaviour
    {
        private InputSystem inputSystem;
        public PlayerInputs PlayerInputs { get; set; }
        private AnimatorController animatorController;
        public Rigidbody2D rigidbody2D { get; private set; }

        private void Awake()
        {
            inputSystem = new InputSystem();
            PlayerInputs = new PlayerInputs();
            animatorController = new AnimatorController(GetComponentInChildren<Animator>());
            inputSystem.Player.Enable();
            inputSystem.Player.Jump.canceled += _ => animatorController.SetJump(false);
            inputSystem.Player.Jump.started += _ => animatorController.SetJump(true);
            inputSystem.Player.Movement.started += _ => animatorController.SetMove(true);
            inputSystem.Player.Movement.canceled += _ => animatorController.SetMove(false);
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            PlayerInputs.Move = inputSystem.Player.Movement.ReadValue<float>();
        }
    }
}