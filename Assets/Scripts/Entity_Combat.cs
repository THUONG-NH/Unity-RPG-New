using UnityEngine;

public class Entity_Combat : MonoBehaviour
{
    public float damage = 10;

    [Header("Target Detection")]
    [SerializeField] private Transform targetCheck;
    [SerializeField] private float targetCheckRadius = 1;
    [SerializeField] private LayerMask whatIsTarget;

    public void PerformAttack()
    {
        foreach (var target in GetDetectedColliders())
        {

            //Entity_Health targetHealth = target.GetComponent<Entity_Health>(); //GetComponent always allocates
            //if (targetHealth != null) targetHealth.TakeDamage(damage, transform); //targetHealth?.TakeDamage(damage, transform);

            if (target.TryGetComponent<Entity_Health>(out var targetHealth)) targetHealth.TakeDamage(damage, transform);
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
