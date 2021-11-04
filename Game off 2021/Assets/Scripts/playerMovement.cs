using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 moves;
    public SpriteRenderer playerSprite;
    public GameObject thisguy;
    public GameObject gameManager;
 
    
   void OnEnable(){
       onInfection();
   }

 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)){
           playerSprite.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.D)){
            playerSprite.flipX = false;
        }
        
        moves.x = Input.GetAxis("Horizontal");
        moves.y = Input.GetAxis("Vertical");
        
    }


    void FixedUpdate()
    {  
     
        rb.MovePosition(rb.position + moves * moveSpeed * Time.deltaTime);
        }
    
    void onInfection(){
        gameManager.GetComponent<gameManager>().addInfected(thisguy);
        thisguy.GetComponent<health>().isInfected();
     }
}
