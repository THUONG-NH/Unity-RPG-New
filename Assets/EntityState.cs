using UnityEngine;

public abstract class EntityState
{
    protected StateMachine stateMachine;
    protected string animBoolName;
    protected Player player;

    protected Animator anim;
    protected Rigidbody2D rb;
    protected PlayerInputSet input;

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
        anim.SetFloat("yVelocity", rb.linearVelocityY);
    }

    public virtual void Exit()
    {
        anim.SetBool(animBoolName, false);
    }
}
