using UnityEngine;

public class Enemy_BattleState : EnemyState
{
    public Enemy_BattleState(StateMachine stateMachine, string animBoolName, Enemy enemy) : base(stateMachine, animBoolName, enemy)
    {
    }
}
