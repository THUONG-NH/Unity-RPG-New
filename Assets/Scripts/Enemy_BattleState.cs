using UnityEngine;

public class Enemy_BattleState : EnemyState
{
    private Transform player;

    public Enemy_BattleState(StateMachine stateMachine, string animBoolName, Enemy enemy) : base(stateMachine, animBoolName, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if (player == null)
        {
            player = enemy.PlayerDetection().transform;
        }
    }

    public override void Update()
    {
        base.Update();

        if (WithinAttackRange())
        {
            stateMachine.ChangeState(enemy.attackState);
        }
        else
        {
            enemy.SetVelocity(enemy.battleMoveSpeed * DirectionToPlayer(), rb.linearVelocityY);
        }
    }

    private bool WithinAttackRange() => DistanceToPlayer() < enemy.attackDistance;

    private float DistanceToPlayer()
    {
        if (player == null)
        {
            return float.MaxValue;
        }

        return Mathf.Abs(player.position.x - enemy.transform.position.x);
    }

    private int DirectionToPlayer()
    {
        if (player == null) return 0;

        return player.position.x > enemy.transform.position.x ? 1 : -1;
    }
}
