using UnityEngine;

public class Player_BasicAttackState : EntityState
{
    private float attackVelocityTimer;

    public Player_BasicAttackState(StateMachine stateMachine, string animBoolName, Player player) : base(stateMachine, animBoolName, player)
    {
    }

    public override void Enter()
    {
        base.Enter();

        GenerateAttackVelocity();
    }

    public override void Update()
    {
        base.Update();

        HandleAttackVelocity();

        if (triggerCalled)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    private void HandleAttackVelocity()
    {

        attackVelocityTimer -= Time.deltaTime;

        if (attackVelocityTimer < 0)
        {
            player.SetVelocity(0, rb.linearVelocityY);
        }
    }

    private void GenerateAttackVelocity()
    {
        attackVelocityTimer = player.attackVelocityDuration;
        player.SetVelocity(player.attackVelocity.x * player.FacingDir, player.attackVelocity.y);
    }
}
