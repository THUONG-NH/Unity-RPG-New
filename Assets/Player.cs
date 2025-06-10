using UnityEngine;

public class Player : MonoBehaviour
{

    public Animator Anim {  get; private set; }
    public Rigidbody2D Rb { get; private set; }

    public PlayerInputSet Input {  get; private set; }
    private StateMachine stateMachine;

    public Player_IdleState IdleState { get; private set; }
    public Player_MoveState MoveState { get; private set; }
    public Player_JumpState JumpState { get; private set; }
    public Player_FallState FallState { get; private set; }


    [Header("Movement Details")]
    public float moveSpeed;
    public float jumpForce = 5f;
    private bool facingRight = true;
    public Vector2 MoveInput { get; private set; }

    private void Awake()
    {
        Anim = GetComponentInChildren<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        Rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        Input = new PlayerInputSet();   
        stateMachine = new StateMachine();

        IdleState = new Player_IdleState(stateMachine, "idle", this);
        MoveState = new Player_MoveState(stateMachine, "move", this);
        JumpState = new Player_JumpState(stateMachine, "jumpFall", this);
        FallState = new Player_FallState(stateMachine, "jumpFall", this);
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

    private void Start()
    {
        stateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        stateMachine.UpdateActiveState();
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        Rb.linearVelocity = new Vector2(xVelocity, yVelocity);

        HandleFlip(xVelocity);
    }

    private void HandleFlip(float xVelocity)
    {
        if (xVelocity < 0 && facingRight)
        {
            Flip();
        } 
        else if (xVelocity > 0 && !facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
    }
}
