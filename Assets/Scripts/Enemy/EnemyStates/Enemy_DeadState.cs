using UnityEngine;

public class Enemy_DeadState : EnemyState
{


    public Enemy_DeadState(StateMachine stateMachine, string animBoolName, Enemy enemy) : base(stateMachine, animBoolName, enemy)
    {
    }

    public override void Enter()
    {
        anim.enabled = false;

        rb.gravityScale = 12;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 15);

        enemy.GetComponent<Collider2D>().enabled = false;

        stateMachine.SwitchOffStateMachine();
    }
}
