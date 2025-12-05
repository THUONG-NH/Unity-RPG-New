using UnityEngine;

public class Entity : MonoBehaviour
{
    public Animator Anim { get; private set; }
    public Rigidbody2D Rb { get; private set; }
    protected StateMachine stateMachine;



    private bool facingRight = true;
    public int FacingDir { get; private set; } = 1;


    [Header("Collision Detection")]
    [SerializeField] protected LayerMask whatIsGround;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform primaryWallCheck;
    [SerializeField] private Transform secondaryWallCheck;
    public bool GroundDetected { get; private set; }
    public bool WallDetected { get; private set; }

    protected virtual void Awake()
    {
        Anim = GetComponentInChildren<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        Rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        stateMachine = new StateMachine();
    }

    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
        stateMachine.UpdateActiveState();

        HandleCollisionDetection();
    }

 
    public void CurrentStateAnimationTrigger()
    {
        stateMachine.CurrentState.AnimationTrigger();
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        Rb.linearVelocity = new Vector2(xVelocity, yVelocity);

        HandleFlip(xVelocity);
    }

    public void HandleFlip(float xVelocity)
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

    public void Flip()
    {
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
        FacingDir *= -1;
    }

    private void HandleCollisionDetection()
    {
        GroundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        
        if (secondaryWallCheck != null)
        {
            WallDetected = Physics2D.Raycast(primaryWallCheck.position, Vector2.right * FacingDir, wallCheckDistance, whatIsGround)
                        && Physics2D.Raycast(secondaryWallCheck.position, Vector2.right * FacingDir, wallCheckDistance, whatIsGround);
        } 
        else
        {
            WallDetected = Physics2D.Raycast(primaryWallCheck.position, Vector2.right * FacingDir, wallCheckDistance, whatIsGround);
        }
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + new Vector3(0, -groundCheckDistance));
        Gizmos.DrawLine(primaryWallCheck.position, primaryWallCheck.position + new Vector3(wallCheckDistance * FacingDir, 0));
        
        if (secondaryWallCheck != null)
        {
            Gizmos.DrawLine(secondaryWallCheck.position, secondaryWallCheck.position + new Vector3(wallCheckDistance * FacingDir, 0));
        }
    }
}
 