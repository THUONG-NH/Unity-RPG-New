using UnityEngine;

public abstract class PlayerState : EntityState
{
    protected Player player;
    protected PlayerInputSet input;



    public PlayerState(StateMachine stateMachine, string animBoolName, Player player) : base(stateMachine, animBoolName)
    {
        this.player = player;

        anim = player.Anim;
        rb = player.Rb;
        input = player.Input;
    }

    public override void Update()
    {
        base.Update();

        if (input.Player.Dash.WasPressedThisFrame() && CanDash())
        {
            stateMachine.ChangeState(player.DashState);
        }
    }

    public override void UpdateAnimationParameters()
    {
        base.UpdateAnimationParameters();

        anim.SetFloat("yVelocity", rb.linearVelocityY);
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
