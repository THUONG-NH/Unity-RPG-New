using UnityEngine;

public class Player_JumpState : Player_AirState
{
    public Player_JumpState(StateMachine stateMachine, string animBoolName, Player player) : base(stateMachine, animBoolName, player)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocity(rb.linearVelocityX, player.jumpForce);
    }

    public override void Update()
    {
        base.Update();

        if (rb.linearVelocityY < 0)
        {
            stateMachine.ChangeState(player.FallState);
        }
    }
}
