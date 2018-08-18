using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledWaypoints : MonoBehaviour
{
    [SerializeField]
    private float waypointRadius = 1f;
    [SerializeField]
    private float connectedRadius = 40f;

    List<ControlledWaypoints> connections;

	// Use this for initialization
	void Start ()
    {
        GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");

        connections = new List<ControlledWaypoints>();

        for(int i = 0; i < allWaypoints.Length; i++)
        {
            ControlledWaypoints nextWaypoint = allWaypoints[i].GetComponent<ControlledWaypoints>();

            if(nextWaypoint != null)
            {
                if (Vector3.Distance(this.transform.position, nextWaypoint.transform.position) <= connectedRadius && nextWaypoint != this)
                {
                    connections.Add(nextWaypoint);
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, waypointRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, connectedRadius);

    }

    public ControlledWaypoints NextWaypoint(ControlledWaypoints previousWaypoint)
    {
        if(connections.Count == 0)
        {
            Debug.LogError("Insufficient waypoint count.");
            return null;
        }
        else if(connections.Count == 1 && connections.Contains(previousWaypoint))
        {
            return previousWaypoint;
        }
        else
        {
            ControlledWaypoints nextWaypoint;
            int nextIndex = 0;

            do
            {
                nextIndex = UnityEngine.Random.Range(0, connections.Count);
                nextWaypoint = connections[nextIndex];
            }
            while (nextWaypoint == previousWaypoint);
            {
                return nextWaypoint;
            }
        }
    }
}
