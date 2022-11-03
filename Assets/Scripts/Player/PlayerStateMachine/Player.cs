using Assets.Scripts.Player.Detectors;
using PlayEatRepeat.Player.Data;
using PlayEatRepeat.Player.PlayerStates.SubStates;
using UnityEngine;

namespace PlayEatRepeat.Player
{
    public class Player : MonoBehaviour
    {
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
            WalkState = new PlayerWalkState(this, StateMachine, playerData, "Walk");
            IdleJumpState = new PlayerIdleJumpState(this, StateMachine, playerData, "IdleJump");
            InAirState = new PlayerInAirState(this, StateMachine, playerData, "InAir");
            IdleLandState = new PlayerIdleLandState(this, StateMachine, playerData, "Land");
            WalkJumpState = new PlayerWalkJumpState(this, StateMachine, playerData, "IdleJump");
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

        public void SetVelocityX(float moveForce, float direction, float smooth)
        {
            float velocityX =
                Mathf.MoveTowards(Rigidbody2D.velocity.x, moveForce * direction,
                    smooth * Time.deltaTime);
            Rigidbody2D.velocity = new Vector2(velocityX, Rigidbody2D.velocity.y);
        }

        public void AddForce(Vector2 direction, float jumpForce)
        {
            Rigidbody2D.AddForce(direction * jumpForce,
                ForceMode2D.Impulse);
        }
    }
}