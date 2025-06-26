using UnityEngine;

public class Player_MoveState : Player_GroundedState
{
    public Player_MoveState(StateMachine stateMachine, string stateName, Player player) : base(stateMachine, stateName, player)
    {
    }

    public override void Update()
    {
        base.Update();

        if (player.MoveInput.x == 0 || player.WallDetected) 
            stateMachine.ChangeState(player.IdleState);

        player.SetVelocity(player.MoveInput.x * player.moveSpeed, rb.linearVelocityY);
    }
}
