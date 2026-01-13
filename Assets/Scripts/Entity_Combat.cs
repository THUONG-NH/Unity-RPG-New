using System.Collections.Generic;
using UnityEngine;

public class Entity_Combat : MonoBehaviour
{
    private readonly Dictionary<Collider2D, IDamageable> cache = new();

    public float damage = 10;

    [Header("Target Detection")]
    [SerializeField] private Transform targetCheck;
    [SerializeField] private float targetCheckRadius = 1;
    [SerializeField] private LayerMask whatIsTarget;

    private IDamageable GetDamageable(Collider2D col)
    {
        if (!cache.TryGetValue(col, out var d)) 
        {
            col.TryGetComponent(out d);
            cache[col] = d;
        }
        return d;
    }

    public void PerformAttack()
    {
        foreach (var col in GetDetectedColliders())
        {

            //Entity_Health targetHealth = target.GetComponent<Entity_Health>(); //GetComponent always allocates
            //if (targetHealth != null) targetHealth.TakeDamage(damage, transform); //targetHealth?.TakeDamage(damage, transform);
            
            //if (target.TryGetComponent<IDamageable>(out var damageable)) damageable.TakeDamage(damage, transform);

            var dmg = GetDamageable(col);
            dmg?.TakeDamage(damage, transform);
        }
    }

    private Collider2D[] GetDetectedColliders()
    {
        return Physics2D.OverlapCircleAll(targetCheck.position, targetCheckRadius, whatIsTarget);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(targetCheck.position, targetCheckRadius);
    }
}
