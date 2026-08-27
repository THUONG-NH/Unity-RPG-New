using UnityEngine;

public class Player_CounterAttackState : PlayerState
{
    private Player_Combat combat;
    private bool counteredSomebody;

    public Player_CounterAttackState(StateMachine stateMachine, string animBoolName, Player player) : base(stateMachine, animBoolName, player)
    {
        combat = player.GetComponent<Player_Combat>();
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = combat.GetCounterRecoveryDuration();
        counteredSomebody = combat.CounterAttackPerformed();
        
        anim.SetBool("counterAttackPerformed", counteredSomebody);
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(0, rb.linearVelocityY);

        if (triggerCalled) stateMachine.ChangeState(player.IdleState);

        if (stateTimer < 0 && !counteredSomebody) stateMachine.ChangeState(player.IdleState); 
    }
}
