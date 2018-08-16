using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    public Light spotLight;
    public float viewDistance;
    public LayerMask viewMask;
    public float normalSpeed = 5f;
    public float chaseSpeed = 12f;
    public float enemyDistanceRun = 4.0f;

    private Color originalColor;
    private float viewAngle;
    GameObject player;
    NavMeshAgent agent;

    PlayerHealth playerHealth;

	// Use this for initialization
	void Start ()
    {
        viewAngle = spotLight.spotAngle;

        agent = GetComponent<NavMeshAgent>();

        player = PlayerManager.instance.player.gameObject;
        
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        originalColor = spotLight.color;
	}

    bool CanSeePlayer()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < viewDistance)
        {
            Vector3 dirToPlayer = (player.transform.position - transform.position).normalized;
            float angleBetweenEnemyAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
            if (angleBetweenEnemyAndPlayer < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, player.transform.position, viewMask))
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
            ChaseTarget();
            FacePlayer();
        }
        else
        {
            spotLight.color = originalColor;
            NormalPatrol();
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
    }

    void ChaseTarget()
    {
        agent.speed = chaseSpeed;
        agent.SetDestination(player.transform.position);
    }

    void FacePlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }

    void NormalPatrol()
    {
        agent.speed = normalSpeed;
    }
}
