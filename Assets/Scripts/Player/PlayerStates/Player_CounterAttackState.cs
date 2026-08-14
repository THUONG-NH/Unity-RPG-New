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

        counteredSomebody = false;
        anim.SetBool("counterAttackPerformed", false);
        stateTimer = combat.GetCounterDuration();
    }

    public override void Update()
    {
        base.Update();

        if (combat.CounterAttackPerformed())
        {
            counteredSomebody = true;   
            anim.SetBool("counterAttackPerformed", true);
        }

        if (triggerCalled) stateMachine.ChangeState(player.IdleState);

        if (stateTimer < 0 && !counteredSomebody) stateMachine.ChangeState(player.IdleState); 
    }
}
