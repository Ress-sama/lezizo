using System.Collections.Generic;
using PlayEatRepeat.Player.Data;
using PlayEatRepeat.Player.PlayerStates.SubStates;
using UnityEngine;

namespace PlayEatRepeat.Player
{
    public class Player : MonoBehaviour
    {
        public PlayerStateMachine StateMachine { get; private set; }
        public Animator Animator { get; private set; }
        public Rigidbody2D Rigidbody2D { get; private set; }
        public CapsuleCollider2D CapsuleCollider { get; private set; }
        public InputSystem InputSystem { get; private set; }

        //States
        public PlayerIdleState IdleState { get; private set; }
        public PlayerWalkState WalkState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerInAirState InAirState { get; private set; }
        public PlayerLandState LandState { get; private set; }


        [SerializeField] private PlayerData playerData;


        private void Awake()
        {
            InputSystem = new InputSystem();
            InputSystem.Player.Enable();
            StateMachine = new PlayerStateMachine();
            Animator = GetComponentInChildren<Animator>();
            Rigidbody2D = GetComponent<Rigidbody2D>();
            CapsuleCollider = GetComponent<CapsuleCollider2D>();
            IdleState = new PlayerIdleState(this, StateMachine, playerData, "Idle");
            WalkState = new PlayerWalkState(this, StateMachine, playerData, "Walk");
            JumpState = new PlayerJumpState(this, StateMachine, playerData, "Walk");
            InAirState = new PlayerInAirState(this, StateMachine, playerData, "Walk");
            LandState = new PlayerLandState(this, StateMachine, playerData, "Walk");
        }

        private void Start()
        {
            StateMachine.Initialize(IdleState);
        }

        public void Update()
        {
            StateMachine.CurrentState.LogicUpdate();
        }

        public void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }

        public void CheckGround()
        {
            List<Vector3> rayStartVectors = new List<Vector3>()
            {
                new Vector3(CapsuleCollider.bounds.min.x, CapsuleCollider.bounds.min.y),
                new Vector3(CapsuleCollider.bounds.center.x, CapsuleCollider.bounds.min.y),
                new Vector3(CapsuleCollider.bounds.max.x, CapsuleCollider.bounds.min.y),
            };

            Collider2D collider2D = null;
            foreach (var rayStartVector in rayStartVectors)
            {
                /*
                RaycastHit2D raycastHit = Physics2D.Raycast(rayStartVector, Vector2.down,
                    detectDistance, layerMask);
                Debug.DrawRay(rayStartVector, Vector2.down * detectDistance, Color.red);
                if (raycastHit.collider != null)
                {
                    collider2D = raycastHit.collider;
                }
            */
            }

            //return collider2D != null;
        }
    }
}