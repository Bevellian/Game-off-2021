using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public int playerHealth = 10;
    public bool infected = false;
    public float infectionTimer;
    public float damageTime = 10;
    public SpriteRenderer playerSprite;
    // Start is called before the first frame update

    // Update is called once per frame
    public void isInfected(){
        infected = true;
        infectionTimer = 0;
        playerSprite.color = new Color(0, 255, 0, 255);
    }

    void Update()
    {
        infectionTimer = infectionTimer + Time.deltaTime;
        if (infected && infectionTimer > damageTime){
            playerHealth = playerHealth - 1;
            infectionTimer = 0;
        }
        if (playerHealth <= 5)
        {
            headBurst();
           playerSprite.color = new Color(255, 0, 0, 255);
        }
        if (playerHealth <= 0){
            playerDeath();
            playerSprite.color = new Color(0, 0, 255, 255);
        }
    }
    
    void headBurst()
    {

    }

    void playerDeath(){

    }
}
