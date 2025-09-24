using UnityEngine;

public class Player_AirState : PlayerState
{
    public Player_AirState(StateMachine stateMachine, string animBoolName, Player player) : base(stateMachine, animBoolName, player)
    {
    }

    public override void Update()
    {
        base.Update();

        if (player.MoveInput.x != 0)
        {
            player.SetVelocity(player.MoveInput.x * (player.moveSpeed * player.inAirMoveMultiplier), rb.linearVelocityY);
        }

        if (input.Player.Attack.WasPressedThisFrame())
        {
            stateMachine.ChangeState(player.JumpAttackState);
        }
    }
}
