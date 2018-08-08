using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    public Light spotLight;
    public float viewDistance;
    public LayerMask viewMask;

    private Color originalColor;
    private float viewAngle;
    Transform player;
    NavMeshAgent agent;

	// Use this for initialization
	void Start ()
    {
        viewAngle = spotLight.spotAngle;

        agent = GetComponent<NavMeshAgent>();

        player = PlayerManager.instance.player.transform;
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        originalColor = spotLight.color;
	}

    bool CanSeePlayer()
    {
        if(Vector3.Distance(transform.position, player.position) < viewDistance)
        {
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            float angleBetweenEnemyAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
            if (angleBetweenEnemyAndPlayer < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, player.position, viewMask))
                {
                    return true;
                }
            }
        }
        return false;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(CanSeePlayer())
        {
            spotLight.color = Color.red;
            Attack();
        }
        else
        {
            spotLight.color = originalColor;
            Normal();
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
    }

    void Attack()
    {
        agent.speed = 20;
        agent.SetDestination(player.position);
    }

    void Normal()
    {
        agent.speed = 5f;
    }
}
