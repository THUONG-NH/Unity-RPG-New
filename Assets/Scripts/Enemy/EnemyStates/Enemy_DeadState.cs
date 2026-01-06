using UnityEngine;

public class Enemy_DeadState : EnemyState
{


    public Enemy_DeadState(StateMachine stateMachine, string animBoolName, Enemy enemy) : base(stateMachine, animBoolName, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Debug.LogWarning("Entered dead state!");
    }
}
