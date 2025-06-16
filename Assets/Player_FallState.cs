using UnityEngine;

public class Player_FallState : Player_AirState
{
    public Player_FallState(StateMachine stateMachine, string animBoolName, Player player) : base(stateMachine, animBoolName, player)
    {
    }

    public override void Update()
    {
        base.Update();

        if (player.GroundDetected)
        {
            stateMachine.ChangeState(player.IdleState);
        }

        if (player.WallDetected)
        {
            stateMachine.ChangeState(player.WallSlideState);
        }
    }
}
