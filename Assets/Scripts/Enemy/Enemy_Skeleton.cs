using UnityEngine;

public class Enemy_Skeleton : Enemy , ICounterable
{
    protected override void Awake()
    {
        base.Awake();

        idleState = new Enemy_IdleState(stateMachine, "idle", this);
        moveState = new Enemy_MoveState(stateMachine, "move", this);
        attackState = new Enemy_AttackState(stateMachine, "attack", this);
        battleState = new Enemy_BattleState(stateMachine, "battle", this);
        deadState = new Enemy_DeadState(stateMachine, "idle", this);
        stunnedState = new Enemy_StunnedState(stateMachine, "stunned", this);
    }

    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(idleState); 
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.F))
            HandleCounter();
    }

    public void HandleCounter()
    {
        if (!canBeStunned) return;

        stateMachine.ChangeState(stunnedState);
    }
}
