using UnityEngine;

public class Player_FallState : EntityState
{
    public Player_FallState(StateMachine stateMachine, string animBoolName, Player player) : base(stateMachine, animBoolName, player)
    {
    }

    public override void Update()
    {
        base.Update();

    }
}
