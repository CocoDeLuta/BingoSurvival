using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public float damageMultiplier = 1f;
    public EnemyHealth enemyHealth;

    public void ApplyDamage(float baseDamage)
    {
        print("Hit enemy for damage: " + (baseDamage * damageMultiplier));
        enemyHealth.TakeDamage(baseDamage * damageMultiplier);
    }
}
