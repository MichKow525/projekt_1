using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class platforma : MonoBehaviour
{   
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    [SerializeField] private float checkDistance = 0.05f;
    
    private Transform targetWaypoint;
    private int currentWaypointIndex = 0;


    void Start()
    {
       
        targetWaypoint = waypoints[0];
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, speed*Time.deltaTime);
        if (Vector2.Distance(transform.position, targetWaypoint.position) < checkDistance)
        {
            targetWaypoint = GetNextWaypoint();
        }
    }

    private    Transform GetNextWaypoint()
    {
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0;
        }
        return waypoints[currentWaypointIndex];
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var platforMovement = other.collider.GetComponent<movement>();
        if (platforMovement != null)
        {
            platforMovement.SetParent(transform);
        }
    }

    private void OnCollisionExit2D (Collision2D other)
    {
        var platforMovement = other.collider.GetComponent<movement>();
        if (platforMovement != null)
        {
            platforMovement.ResetParent();
        }
    }
}
