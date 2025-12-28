using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveTo(Vector3 target)
    {
        if (!agent.enabled) return;
        agent.isStopped = false;
        agent.SetDestination(target);
    }

    public void Stop()
    {
        if (!agent.enabled) return;
        agent.isStopped = true;
    }
}
