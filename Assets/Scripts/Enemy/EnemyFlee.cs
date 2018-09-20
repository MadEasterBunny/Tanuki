using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFlee : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;

    public float enemyRunDistance = 4.0f;
    public float fleeSpeed = 10f;

    public GameObject key;
    private AudioSource keySource;
    public AudioClip keyDropSound;

    private bool keyDropped;

	void Start ()
    {
        player = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        keySource = GetComponent<AudioSource>();
	}
	
	void Update ()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if(distance < enemyRunDistance)
        {
            Vector3 dirToPlayer = transform.position - player.position;
            Vector3 newPos = transform.position + dirToPlayer;
            agent.SetDestination(newPos);
            StartCoroutine("IncreaseSpeedPerSecond", 1f);
            if(agent.speed > fleeSpeed)
            {
                agent.speed = fleeSpeed;
            }

            if (agent.speed == fleeSpeed)
            {
                if (!keyDropped)
                {
                    keySource.PlayOneShot(keyDropSound);
                    Instantiate(key, transform.position, transform.rotation);
                    keyDropped = true;
                }
            }
        }
	}

    IEnumerator IncreaseSpeedPerSecond(float waitTime)
    {
        while(agent.speed < fleeSpeed)
        {
            yield return new WaitForSeconds(waitTime);
            agent.speed = agent.speed + 0.5f;
        }
    }
}
