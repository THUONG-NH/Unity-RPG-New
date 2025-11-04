using UnityEngine;

public class Enemy_MoveState : EnemyState
{
    public Enemy_MoveState(StateMachine stateMachine, string animBoolName, Enemy enemy) : base(stateMachine, animBoolName, enemy)
    {
    }
    public override void Enter()
    {
        base.Enter();

        if (!enemy.GroundDetected || enemy.WallDetected)
        {
            enemy.Flip();
        }  
    }
    public override void Update()
    {
        base.Update();

        enemy.SetVelocity(enemy.moveSpeed * enemy.FacingDir, rb.linearVelocityY);

        if (!enemy.GroundDetected || enemy.WallDetected)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
