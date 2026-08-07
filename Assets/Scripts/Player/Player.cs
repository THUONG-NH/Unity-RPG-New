using System;
using System.Collections;
using UnityEngine;

public class Player : Entity
{
    public static event Action OnPlayerDeath; 
    public PlayerInputSet Input { get; private set; }
    public Player_IdleState IdleState { get; private set; }
    public Player_MoveState MoveState { get; private set; }
    public Player_JumpState JumpState { get; private set; }
    public Player_FallState FallState { get; private set; }
    public Player_WallSlideState WallSlideState { get; private set; }
    public Player_WallJumpState WallJumpState { get; private set; }
    public Player_DashState DashState { get; private set; }
    public Player_BasicAttackState BasicAttackState { get; private set; }
    public Player_JumpAttackState JumpAttackState { get; private set; }
    public Player_DeadState DeadState { get; private set; }
    public Player_CounterAttackState CounterAttackState { get; private set; }

    [Header("Attack Details")]
    public Vector2[] attackVelocity;
    public Vector2 jumpAttackVelocity;
    public float attackVelocityDuration = 0.1f;
    public float comboResetTime = 1f;
    private Coroutine queuedAttackCo;

    [Header("Movement Details")]
    public float moveSpeed;
    public float jumpForce = 5f;
    public Vector2 wallJumpForce;
    [Range(0f, 1f)]
    public float inAirMoveMultiplier = 0.7f;
    [Range(0f, 1f)]
    public float wallSlideSlowMultiplier = 0.7f;
    [Space]
    public float dashDuration = 0.25f;
    public float dashSpeed = 20f;

    public Vector2 MoveInput { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        Input = new PlayerInputSet();
        IdleState = new Player_IdleState(stateMachine, "idle", this);
        MoveState = new Player_MoveState(stateMachine, "move", this);
        JumpState = new Player_JumpState(stateMachine, "jumpFall", this);
        FallState = new Player_FallState(stateMachine, "jumpFall", this);
        WallSlideState = new Player_WallSlideState(stateMachine, "wallSlide", this);
        WallJumpState = new Player_WallJumpState(stateMachine, "jumpFall", this);
        DashState = new Player_DashState(stateMachine, "dash", this);
        BasicAttackState = new Player_BasicAttackState(stateMachine, "basicAttack", this);
        JumpAttackState = new Player_JumpAttackState(stateMachine, "jumpAttack", this);
        DeadState = new Player_DeadState(stateMachine, "dead", this);
        CounterAttackState = new Player_CounterAttackState(stateMachine, "counterAttack", this);
    }

    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(IdleState);
    }

    public override void EntityDeath()
    {
        base.EntityDeath();

        OnPlayerDeath?.Invoke();
        stateMachine.ChangeState(DeadState);
    }

    public void EnterAttackStateWithDelay()
    {
        if (queuedAttackCo != null)
        {
            StopCoroutine(queuedAttackCo);
        }
        queuedAttackCo = StartCoroutine(EnterAttackStateWithDelayCo());
    }

    private IEnumerator EnterAttackStateWithDelayCo()
    {
        yield return new WaitForEndOfFrame();
        stateMachine.ChangeState(BasicAttackState);
    }

    private void OnEnable()
    {
        Input.Enable();

        Input.Player.Movement.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        Input.Player.Movement.canceled += ctx => MoveInput = Vector2.zero;
    }

    private void OnDisable()
    {
        Input.Disable();
    }
}
