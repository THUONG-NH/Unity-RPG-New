using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class Enemy_Health : Entity_Health
{
    private Enemy Enemy => GetComponent<Enemy>();

    public override void TakeDamage(float damage, Transform damageDealer)
    {
        base.TakeDamage(damage, damageDealer);

        if (isDead) return;

        if (damageDealer.GetComponent<Player>() != null)    // (damageDealer.CompareTag("Player"))
        {
            Enemy.TryEnterBattleState(damageDealer);
        }
    }

}
