using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public GameObject bullet;

    //patrol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttack;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInsightRange, playerInAttacRange;

    private void Awake()
    {
        player = GameObject.Find("mainplayer").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInsightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttacRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if(!playerInsightRange && !playerInAttacRange) Patrolling();
        if(playerInsightRange && !playerInAttacRange) ChasePlayer();
        if(playerInAttacRange && playerInsightRange) AttackPlayer();
    }


    //patrolling
    private void Patrolling()
    {
        if(!walkPointSet) SearchWalkPoint();

        if(walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }

    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y,transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }
    //chaseplayer
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    //attackplayer
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);


        //attack


        if(!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 4f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttack);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
