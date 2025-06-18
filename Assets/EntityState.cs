using UnityEngine;

public abstract class EntityState
{
    protected StateMachine stateMachine;
    protected string animBoolName;
    protected Player player;

    protected Animator anim;
    protected Rigidbody2D rb;
    protected PlayerInputSet input;

    protected float stateTimer;

    public EntityState(StateMachine stateMachine, string animBoolName, Player player)
    {
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
        this.player = player;

        anim = player.Anim;
        rb = player.Rb;
        input = player.Input;
    }
      
    public virtual void Enter()
    {
        anim.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;   

        anim.SetFloat("yVelocity", rb.linearVelocityY);

        if (input.Player.Dash.WasPressedThisFrame() && CanDash())
        {
            stateMachine.ChangeState(player.DashState);
        }
    }

    public virtual void Exit()
    {
        anim.SetBool(animBoolName, false);
    }

    private bool CanDash()
    {
        if (player.WallDetected || stateMachine.CurrentState == player.DashState)
        {
            return false;
        }

        return true;
    }
}
