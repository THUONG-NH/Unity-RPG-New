using UnityEngine;

public abstract class EntityState
{
    protected StateMachine stateMachine;
    protected string stateName;
    protected Player player;

    public EntityState(StateMachine stateMachine, string stateName, Player player)
    {
        this.stateMachine = stateMachine;
        this.stateName = stateName;
        this.player = player;
    }

    public virtual void Enter()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {

    }
}
