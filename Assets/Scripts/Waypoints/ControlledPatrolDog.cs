using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControlledPatrolDog : MonoBehaviour
{
    [SerializeField]
    float totalWaitTime = 3f;

    //[SerializeField]
    //float switchProbability = 0.2f;

    [SerializeField]
    bool patrolWaiting;

    NavMeshAgent navMeshAgent;
    ControlledWaypointsDog currentWaypoint;
    ControlledWaypointsDog previousWaypoint;

    bool travelling;
    bool waiting;
    float waitTimer;
    int waypointsVisited;

    // Use this for initialization
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attahced to " + gameObject.name);
        }
        else
        {
            if (currentWaypoint == null)
            {
                GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Dog Waypoint");

                if (allWaypoints.Length > 0)
                {
                    while (currentWaypoint == null)
                    {
                        int random = UnityEngine.Random.Range(0, allWaypoints.Length);
                        ControlledWaypointsDog startingWaypoint = allWaypoints[random].GetComponent<ControlledWaypointsDog>();

                        if (startingWaypoint != null)
                        {
                            currentWaypoint = startingWaypoint;
                        }
                    }
                }
                else
                {
                    Debug.LogError("Failed to find any waypoints for use in the scene.");
                }
            }
        }

        SetDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (travelling && navMeshAgent.remainingDistance <= 1.0f)
        {
            travelling = false;
            waypointsVisited++;

            if (patrolWaiting)
            {
                waiting = true;
                waitTimer = 0f;
            }
            else
            {
                SetDestination();
            }
        }

        if (waiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= totalWaitTime)
            {
                waiting = false;

                SetDestination();
            }
        }
    }

    private void SetDestination()
    {
        if (waypointsVisited > 0)
        {
            ControlledWaypointsDog nextWaypoint = currentWaypoint.NextWaypoint(previousWaypoint);
            previousWaypoint = currentWaypoint;
            currentWaypoint = nextWaypoint;
        }

        Vector3 targetVector = currentWaypoint.transform.position;
        navMeshAgent.SetDestination(targetVector);
        travelling = true;
    }
}
