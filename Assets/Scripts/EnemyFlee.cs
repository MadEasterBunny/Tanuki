using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFlee : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;

    public float enemyRunDistance = 4.0f;
    public float fleeSpeed = 8f;
	// Use this for initialization
	void Start ()
    {
        player = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if(distance < enemyRunDistance)
        {
            agent.speed = fleeSpeed;
            Vector3 dirToPlayer = transform.position - player.position;
            Vector3 newPos = transform.position + dirToPlayer;
            agent.SetDestination(newPos);
        }
	}
}
