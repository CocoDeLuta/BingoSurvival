using UnityEngine;

public class EnemyAI_BasicZombie : MonoBehaviour
{
    public float chaseDistance = 20f;
    public float attackDistance = 1.5f;

    [SerializeField] private Transform player;
    private EnemyMovement movement;
    private EnemyMeleeAttack attack;
    private EnemyHealth health;
    private Animator animator;

    private void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        movement = GetComponent<EnemyMovement>();
        attack = GetComponent<EnemyMeleeAttack>();
        health = GetComponent<EnemyHealth>();
        animator = GetComponent<Animator>();

        health.OnDeath += OnDeath;
    }

    private void Update()
    {
        if (health.IsDead) return;

        float dist = Vector3.Distance(transform.position, player.position);

        if (dist > chaseDistance)
        {
            movement.Stop();
            //animator.SetBool("Walking", false);
            return;
        }

        if (dist > attackDistance)
        {
            movement.MoveTo(player.position);
            //animator.SetBool("Walking", true);
        }
        else
        {
            movement.Stop();
            //animator.SetBool("Walking", false);
            attack.TryAttack(player);
        }
    }

    private void OnDeath()
    {
        movement.Stop();
        //animator.SetTrigger("Die");

        // Desativa colisão física
        //GetComponent<Collider>().enabled = false;
    }
}
