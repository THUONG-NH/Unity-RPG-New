using UnityEngine;

public class Player_JumpAttackState : EntityState
{
    private bool touchedGround;

    public Player_JumpAttackState(StateMachine stateMachine, string animBoolName, Player player) : base(stateMachine, animBoolName, player)
    {
    }

    public override void Enter()
    {
        base.Enter();

        touchedGround = false;

        player.SetVelocity(player.jumpAttackVelocity.x * player.FacingDir, player.jumpAttackVelocity.y);
    }

    public override void Update()
    {
        base.Update();

        if (player.GroundDetected && !touchedGround)
        {
            touchedGround = true;
            anim.SetTrigger("jumpAttackTrigger");
            player.SetVelocity(0, rb.linearVelocityY);
        }

        if (triggerCalled && player.GroundDetected)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }
}
