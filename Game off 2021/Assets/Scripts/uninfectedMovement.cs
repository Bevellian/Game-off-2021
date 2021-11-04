using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class uninfectedMovement : MonoBehaviour
{   public Transform target;
    public Vector2 randomTarget;
    public float maxWander;
    public float minWander;
    public Rigidbody2D rb;
    public int moveSpeed;
    public bool infected;
    public GameObject thisguy;
    public GameObject gameManager;
    public float nextWaypointDistance;
    Path path;
    public int currentWaypoint = 0;
    bool reachedEnd = false;
    Seeker seeker;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        randomTarget = new Vector2(Random.Range(minWander,maxWander),Random.Range(minWander,maxWander));
        seeker.StartPath(rb.position, randomTarget, wander);;
    }

    void FixedUpdate() 
    {   if(path == null)
            return; 
        if(Vector2.Distance(rb.position,randomTarget) < 2){
            reachedEnd = true;
            UpdatePath();
            return;
        }
        else{
            reachedEnd = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * moveSpeed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance){
            currentWaypoint++;
        }
    }
    
    void UpdatePath()
    {   
            randomTarget = new Vector2(Random.Range(minWander,maxWander),Random.Range(minWander,maxWander));
            seeker.StartPath(rb.position, randomTarget, wander);
    }


    void wander(Path p)
    {
        if(!p.error){
            path = p;
            currentWaypoint = 0;
        }
     }

    // void OnCollisionEnter2D(Collision2D other) 
    // {
    //     onInfection();
    // }

    void onInfection(){
        gameManager.GetComponent<gameManager>().addInfected(thisguy);
        thisguy.GetComponent<health>().isInfected();
     }
}