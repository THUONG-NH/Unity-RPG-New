using UnityEngine;

public class EnemyState : EntityState
{
    protected Enemy enemy;

    public EnemyState(StateMachine stateMachine, string animBoolName, Enemy enemy) : base(stateMachine, animBoolName)
    {
        this.enemy = enemy;

        rb = enemy.Rb;
        anim = enemy.Anim;
    }

    public override void Update()
    {
        base.Update();

        anim.SetFloat("moveAnimSpeedMultiplier", enemy.moveAnimSpeedMultiplier);
    }
}
