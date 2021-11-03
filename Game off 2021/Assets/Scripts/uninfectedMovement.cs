using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uninfectedMovement : MonoBehaviour
{   public Vector3 target;
    public int maxWander;
    public int minWander;
    public Rigidbody2D rb;
    public int moveSpeed;
    float distance;
    public bool infected;
    public GameObject thisguy;
    public GameObject gameManager;

    void FixedUpdate() 
    {   rb.MovePosition(rb.transform.position + target * moveSpeed * Time.deltaTime);
        distance = (Vector3.Distance(target,transform.position));
        if(distance < 3){
            Invoke("Wander",2.0f);
    }
    }

    void Wander()
    {
        target = new Vector3(Random.Range(minWander, maxWander), Random.Range(minWander, maxWander), 0);
     }

    void OnCollisionEnter2D(Collision2D other) 
    {
        infected = true;
        onInfection();
    }

    void onInfection(){
        gameManager.GetComponent<gameManager>().addInfected(thisguy);
     }
}