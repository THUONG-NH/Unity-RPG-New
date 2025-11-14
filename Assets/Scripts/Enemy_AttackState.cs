using UnityEngine;

public class Enemy_AttackState : EnemyState
{
    public Enemy_AttackState(StateMachine stateMachine, string animBoolName, Enemy enemy) : base(stateMachine, animBoolName, enemy)
    {
    }
}
