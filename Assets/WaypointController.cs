using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour {

    //References
    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int targetWaypointIndex = 0;
    private float minDistance = 0.1f; //If the distance between the enemy and the Waypoint is less than this, then it has reacehd the waypoint
    private int lastWaypointIndex;

    private float movementSpeed = 20.0f;

    // Starts after first frame update
    void Start() {
        lastWaypointIndex = waypoints.Count - 1;
        targetWaypoint = waypoints[targetWaypointIndex];
    }

    // Updates once per frame
    void Update() {
        float movementStep = movementSpeed * Time.deltaTime;

        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWaypoint(distance);

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);

    }

    //Checks the distance if the wall is within the distance of the Waypoint.
    void CheckDistanceToWaypoint(float currentDistance)
    {
        if (currentDistance <= minDistance)
        {
            targetWaypointIndex++;
            UpdateTargetWaypoint();
        }
    }
    void UpdateTargetWaypoint()
    {
        // resets the targetWaypointIndex to the first Waypoint in the list which creates a loot for the wall.
        if (targetWaypointIndex > lastWaypointIndex)
        {
            targetWaypointIndex = 0;
        }

        targetWaypoint = waypoints[targetWaypointIndex];
    }

}

