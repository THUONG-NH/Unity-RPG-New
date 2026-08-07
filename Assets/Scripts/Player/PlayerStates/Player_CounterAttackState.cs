using UnityEngine;

public class Player_CounterAttackState : PlayerState
{
    public Player_CounterAttackState(StateMachine stateMachine, string animBoolName, Player player) : base(stateMachine, animBoolName, player)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = 1;
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0) stateMachine.ChangeState(player.IdleState); 
    }
}
