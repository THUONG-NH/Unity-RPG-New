using UnityEngine;

public class Player_GroundedState : EntityState
{
    public Player_GroundedState(StateMachine stateMachine, string animBoolName, Player player) : base(stateMachine, animBoolName, player)
    {
    }

    public override void Update()
    {
        base.Update();

        if (rb.linearVelocityY < 0 && !player.GroundDetected)
        {
            stateMachine.ChangeState(player.FallState);
        }

        if (input.Player.Jump.WasPressedThisFrame())
        {
            stateMachine.ChangeState(player.JumpState);
        }

        if (input.Player.Attack.WasPressedThisFrame())
        {
            stateMachine.ChangeState(player.BasicAttackState);
        }
    }
}
