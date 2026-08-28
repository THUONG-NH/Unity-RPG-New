using System.Collections.Generic;
using UnityEngine;

public class Entity_Combat : MonoBehaviour
{
    private readonly Dictionary<(Collider2D col, System.Type type), object> cache = new();
    private Entity_VFX vfx;
    public float damage = 10;

    [Header("Target Detection")]
    [SerializeField] private Transform targetCheck;
    [SerializeField] private float targetCheckRadius = 1;
    [SerializeField] private LayerMask whatIsTarget;

    private void Awake()
    {
        vfx = GetComponent<Entity_VFX>();
    }

    protected T GetTargetInterface<T>(Collider2D col) where T : class
    {
        if (col == null) return null;

        var key = (col, typeof(T));

        if (!cache.TryGetValue(key, out var cachedValue))
        {
            col.TryGetComponent<T>(out var target);
            cachedValue = target;
            cache[key] = cachedValue; // Cache cả khi target == null
        }

        return cachedValue as T;
    }

    public void PerformAttack()
    {
        foreach (var col in GetDetectedColliders())
        {
            var dmg = GetTargetInterface<IDamageable>(col);
            
            if (dmg == null) continue;
            
            dmg.TakeDamage(damage, transform);
            vfx.CreateOnHitVFX(col.transform);
        }
    }

    protected Collider2D[] GetDetectedColliders()
    {
        return Physics2D.OverlapCircleAll(targetCheck.position, targetCheckRadius, whatIsTarget);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(targetCheck.position, targetCheckRadius);
    }
}
