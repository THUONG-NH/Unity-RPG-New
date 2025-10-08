using UnityEngine;

public class Enemy : Entity
{
    public Enemy_IdleState idleState;
    public Enemy_MoveState moveState;

    [Header("Movement Details")]
    public float idleTime = 2;
    public float moveSpeed = 1.4f;
}
