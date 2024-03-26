using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float viewAngle;
    public float damage = 30;
    public Animator animator;
    public float attackDistance = 1;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private PlayerHealth _playerHealth;
    private EnemyHealth _enemyHealth;

    public bool IsAlive()
    { 
        return _enemyHealth.IsAlive();
    }       

    public void AttackDamage()
    {
        Debug.Log("AttackDamage");
        if (!_isPlayerNoticed) return;
        if ((player.transform.position - transform.position).magnitude > (_navMeshAgent.stoppingDistance + attackDistance)) return;
        _playerHealth.DealDamage(damage);
    }

    // Start is called before the first frame update
    private void Start()
    {
       InitComponentLinks();        
        PickNewPatrolPoint();
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
        _enemyHealth = this.GetComponent<EnemyHealth>();

        /*if (_navMeshAgent == null) Debug.LogError("NavMeshAgent not found on " + gameObject.name);
        if (_playerHealth == null) Debug.LogError("PlayerHealth not found on " + player.gameObject.name);
        if (_enemyHealth == null) Debug.LogError("EnemyHealth not found on " + gameObject.name);*/
    }

    // Update is called once per frame
    private void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        AttackUpdate();
        PatrolUpdate();
    }

    private void AttackUpdate()
    {
        Debug.Log("AttackUpdate");
        if (_isPlayerNoticed)
        {
            Debug.Log("_isPlayerNoticed");
            if ((player.transform.position - transform.position).magnitude <= _navMeshAgent.stoppingDistance)
            //if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                Debug.Log("SetTrigger attack");
                animator.SetTrigger("attack");
                //_playerHealth.DealDamage(damage * Time.deltaTime);
            }
        }
    }

    private void NoticePlayerUpdate() 
    {
        
        _isPlayerNoticed = false;
        if (!_playerHealth.IsAlive()) return;
        var direction = player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }

    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }
    }

    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
}
