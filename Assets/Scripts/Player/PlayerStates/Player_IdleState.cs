using UnityEngine;

public class Player_IdleState : Player_GroundedState
{
    public Player_IdleState(StateMachine stateMachine, string stateName, Player player) : base(stateMachine, stateName, player)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocity(0, rb.linearVelocityY);
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(0, rb.linearVelocityY);

        if (player.MoveInput.x == player.FacingDir && player.WallDetected) return;

        if (player.MoveInput.x != 0)
            stateMachine.ChangeState(player.MoveState);
    }
}
    
