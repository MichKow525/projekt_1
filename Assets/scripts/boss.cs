using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class boss : MonoBehaviour
{   private int hitpoint;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    [SerializeField] private float checkDistance = 0.05f;
    private int NIesmiertelny;

    private Transform targetWaypoint;
    private int currentWaypointIndex = 0;


    void Start()
    {
       hitpoint = 3; 
        targetWaypoint = waypoints[1];
    }
    private void Update()
    {
        if (hitpoint ==0)
        {
            Destroy(gameObject);
            Invoke("przejsciedowyniku", 2);
        }    
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, targetWaypoint.position) < checkDistance)
        {
            targetWaypoint = GetNextWaypoint();
        }
    }

    public void przejsciedowyniku()
    {
        SceneManager.LoadScene(3);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (NIesmiertelny == 0)
        {
            if (collision.gameObject.tag == "Player")
            {
                hitpoint--;
                
            }
        }
    }
    public void invunurable()
    {
        NIesmiertelny = 1;
        Invoke("koniecinvunurable", 1);
    }

    public void koniecinvunurable()
    {
        NIesmiertelny = 0;
    }
    private Transform GetNextWaypoint()
    {
        currentWaypointIndex++;
        transform.localScale = new Vector3(1, 1, 1);
        if (currentWaypointIndex >= waypoints.Length)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            currentWaypointIndex = 0;
        }
        return waypoints[currentWaypointIndex];
    }
}