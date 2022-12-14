using Assets.Scripts.Player.Detectors;
using PlayEatRepeat.Player.Data;
using PlayEatRepeat.Player.PlayerStates.SubStates;
using UnityEngine;

namespace PlayEatRepeat.Player
{
    public class Player : MonoBehaviour
    {
        public float VelocityX
        {
            get => Rigidbody2D.velocity.x;
        }

        public float VelocityY
        {
            get => Rigidbody2D.velocity.y;
        }

        public PlayerStateMachine StateMachine { get; private set; }
        public InputSystem InputSystem { get; private set; }

        #region SerializeFields

        [SerializeField] private LayerMask groundLayer;
        [SerializeField] [Range(0, 1)] private float groundDetectDistance;
        [SerializeField] private PlayerData playerData;

        #endregion

        #region Components

        public Animator Animator { get; private set; }
        public Rigidbody2D Rigidbody2D { get; private set; }
        public CapsuleCollider2D CapsuleCollider { get; private set; }

        #endregion

        #region States

        public PlayerIdleState IdleState { get; private set; }
        public PlayerWalkState WalkState { get; private set; }
        public PlayerIdleJumpState IdleJumpState { get; private set; }
        public PlayerInAirState InAirState { get; private set; }
        public PlayerIdleLandState IdleLandState { get; private set; }
        public PlayerWalkJumpState WalkJumpState { get; private set; }
        public PlayerRunState RunState { get; private set; }
        public PlayerRunJumpState RunJumpState { get; private set; }

        #endregion

        #region Utilities

        public GroundDetector GroundDetector { get; private set; }
        public DistanceCalculator DistanceCalculator { get; private set; }
        public ColliderUpdater ColliderUpdater { get; private set; }

        #endregion

        private void Awake()
        {
            InputSystem = new InputSystem();
            InputSystem.Player.Enable();
            StateMachine = new PlayerStateMachine();
            Animator = GetComponentInChildren<Animator>();
            Rigidbody2D = GetComponent<Rigidbody2D>();
            CapsuleCollider = GetComponent<CapsuleCollider2D>();
            GroundDetector = new GroundDetector(CapsuleCollider);
            GroundDetector.LayerMask = groundLayer;
            ColliderUpdater = new ColliderUpdater(CapsuleCollider);
            DistanceCalculator = new DistanceCalculator(CapsuleCollider);
            IdleState = new PlayerIdleState(this, StateMachine, playerData, "Idle");
            WalkState = new PlayerWalkState(this, StateMachine, playerData, "Move");
            IdleJumpState = new PlayerIdleJumpState(this, StateMachine, playerData, "IdleJump");
            InAirState = new PlayerInAirState(this, StateMachine, playerData, "InAir");
            IdleLandState = new PlayerIdleLandState(this, StateMachine, playerData, "Land");
            WalkJumpState = new PlayerWalkJumpState(this, StateMachine, playerData, "IdleJump");
            RunState = new PlayerRunState(this, StateMachine, playerData, "Move");
            RunJumpState = new PlayerRunJumpState(this, StateMachine, playerData, "RunJump");
        }

        private void Start()
        {
            StateMachine.Initialize(IdleState);
        }

        public void Update()
        {
            StateMachine.CurrentState.LogicUpdate();
            ColliderUpdater.UpdateColliderSize();
            ColliderUpdater.UpdateColliderOffset();
        }

        public void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }

        public void SetVelocityX(float value)
        {
            Rigidbody2D.velocity = new Vector2(value, Rigidbody2D.velocity.y);
        }

        public void AddVelocityX(float value)
        {
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x + value, Rigidbody2D.velocity.y);
        }

        public void SetVelocityY(float value)
        {
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, value);
        }

        public void AddForce(Vector2 direction, float jumpForce)
        {
            Rigidbody2D.AddForce(direction * jumpForce * 100,
                ForceMode2D.Force);
        }
    }
}