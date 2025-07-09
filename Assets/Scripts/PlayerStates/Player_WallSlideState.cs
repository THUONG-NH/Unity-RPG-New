using UnityEditor.SceneManagement;
using UnityEngine;

public class Player_WallSlideState : EntityState
{
    public Player_WallSlideState(StateMachine stateMachine, string animBoolName, Player player) : base(stateMachine, animBoolName, player)
    {
    }

    public override void Update()
    {
        base.Update();

        HandleWallSlide();

        if (input.Player.Jump.WasPressedThisFrame())
        {
            stateMachine.ChangeState(player.WallJumpState);
        }


        if (!player.WallDetected)
        {
            stateMachine.ChangeState(player.FallState);
        }

        if (player.GroundDetected)
        {
            stateMachine.ChangeState(player.IdleState);
            player.Flip();
        }

    }

    private void HandleWallSlide()
    {
        if (player.MoveInput.y < 0)
        {
            player.SetVelocity(player.MoveInput.x, rb.linearVelocityY);
        }
        else
        {
            player.SetVelocity(player.MoveInput.x, rb.linearVelocityY * player.wallSlideSlowMultiplier);
        }
    }
}
