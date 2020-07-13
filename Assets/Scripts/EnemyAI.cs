using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 10f, endChase = 15f, attackRange = 2.5f;
    NavMeshAgent agent;
    float distanceToTarget = Mathf.Infinity;
    bool chasing = false, isProvoked = false;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = attackRange;
    }
    private void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, this.transform.position);
        Chase();
        Provoked();
        PlayerIsVisible();
    }
    private void Provoked()
    {
        //! if attack 
        //! isProvoked = true;
        //? start Coroutine to set isProvoked back to false?
    }

    private void PlayerIsVisible()
    {
        if (distanceToTarget < chaseRange)
        {
            chasing = true;
        }
        else if (distanceToTarget > endChase)
        {
            chasing = false;
        }
    }

    private void Chase()
    {
        if (chasing || isProvoked)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
            if (distanceToTarget < attackRange)
            {
                print("Attacking");
            }
        }
        else
        {
            agent.isStopped = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, chaseRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, endChase);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, attackRange);
    }
}
