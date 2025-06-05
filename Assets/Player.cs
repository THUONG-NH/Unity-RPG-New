using UnityEngine;

public class Player : MonoBehaviour
{

    public Animator Anim {  get; private set; }
    public Rigidbody2D Rb { get; private set; }

    private PlayerInputSet input;
    private StateMachine stateMachine;

    public Player_IdleState IdleState { get; private set; }
    public Player_MoveState MoveState { get; private set; }

    public Vector2 MoveInput { get; private set; }

    [Header("Movement Details")]
    public float moveSpeed;

    private void Awake()
    {
        Anim = GetComponentInChildren<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        Rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        input = new PlayerInputSet();   
        stateMachine = new StateMachine();

        IdleState = new Player_IdleState(stateMachine, "idle", this);
        MoveState = new Player_MoveState(stateMachine, "move", this);
    }

    private void OnEnable()
    {
        input.Enable();

        input.Player.Movement.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        input.Player.Movement.canceled += ctx => MoveInput = Vector2.zero;
    }

    private void OnDisable()
    {
        input.Disable();    
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
    }
}
