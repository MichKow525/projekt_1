using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class duch : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    [SerializeField] private float checkDistance = 0.05f;

    private Transform targetWaypoint;
    private int currentWaypointIndex = 0;


    void Start()
    {

        targetWaypoint = waypoints[1];
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, targetWaypoint.position) < checkDistance)
        {
            targetWaypoint = GetNextWaypoint();
        }
    }

    private Transform GetNextWaypoint()
    {
        currentWaypointIndex++;
         transform.localScale = new Vector3(1,1,1);
        if (currentWaypointIndex >= waypoints.Length)
        {   transform.localScale = new Vector3(-1,1,1);
            currentWaypointIndex = 0;
        }
        return waypoints[currentWaypointIndex];
    }
}