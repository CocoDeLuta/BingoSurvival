using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    public float attackRange = 1.5f;
    public float damage = 10f;
    public float cooldown = 1.2f;

    private float nextAttackTime;

    public void TryAttack(Transform target)
    {
        if (Time.time < nextAttackTime) return;

        float dist = Vector3.Distance(transform.position, target.position);
        if (dist > attackRange) return;

        nextAttackTime = Time.time + cooldown;

        // Aqui você pode animar
        if (target.TryGetComponent(out PlayerHealth health))
        {
            health.TakeDamage((int)damage);
        }
    }
}
