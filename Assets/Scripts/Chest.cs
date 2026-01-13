using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Entity_VFX))]
public class Chest : MonoBehaviour , IDamageable
{
    private Animator Anim;
    private Rigidbody2D Rb;
    private Entity_VFX Vfx;

    [Header("Open Details")]
    [SerializeField] private Vector2 knockback;

    private void Awake()
    {
        Anim = GetComponentInChildren<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        Vfx = GetComponent<Entity_VFX>();
    }

    public void TakeDamage(float damage, Transform damageDealer)
    {
        Vfx.PlayOnDamageVfx();
        Anim.SetBool("chestOpen", true);
        Rb.linearVelocity = knockback;
        Rb.angularVelocity = Random.Range(-200f, 200f);
    }
}
