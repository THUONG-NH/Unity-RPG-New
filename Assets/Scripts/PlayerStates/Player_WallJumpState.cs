using UnityEngine;

public class Player_WallJumpState : PlayerState
{
    public Player_WallJumpState(StateMachine stateMachine, string animBoolName, Player player) : base(stateMachine, animBoolName, player)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocity(player.wallJumpForce.x * -player.FacingDir, player.wallJumpForce.y);
    }

    public override void Update()
    {
        base.Update();

        if (rb.linearVelocityY < 0)
        {
            stateMachine.ChangeState(player.FallState);
        }

        if (player.WallDetected)
        {
            stateMachine.ChangeState(player.WallSlideState);
        }
    }
}
