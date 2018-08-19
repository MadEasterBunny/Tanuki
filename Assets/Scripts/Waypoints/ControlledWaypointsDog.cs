using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledWaypointsDog : MonoBehaviour
{
    [SerializeField]
    private float waypointRadius = 1f;
    [SerializeField]
    private float connectedRadius = 10f;

    List<ControlledWaypointsDog> connections;

    // Use this for initialization
    void Start()
    {
        GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Dog Waypoint");

        connections = new List<ControlledWaypointsDog>();

        for (int i = 0; i < allWaypoints.Length; i++)
        {
            ControlledWaypointsDog nextWaypoint = allWaypoints[i].GetComponent<ControlledWaypointsDog>();

            if (nextWaypoint != null)
            {
                if (Vector3.Distance(this.transform.position, nextWaypoint.transform.position) <= connectedRadius && nextWaypoint != this)
                {
                    connections.Add(nextWaypoint);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, waypointRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, connectedRadius);

    }

    public ControlledWaypointsDog NextWaypoint(ControlledWaypointsDog previousWaypoint)
    {
        if (connections.Count == 0)
        {
            Debug.LogError("Insufficient waypoint count.");
            return null;
        }
        else if (connections.Count == 1 && connections.Contains(previousWaypoint))
        {
            return previousWaypoint;
        }
        else
        {
            ControlledWaypointsDog nextWaypoint;
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
