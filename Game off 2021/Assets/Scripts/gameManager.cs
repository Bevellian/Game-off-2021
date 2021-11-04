using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{   public List<GameObject> infectedplayers = new List<GameObject>();
    public static gameManager instance = null;
    public int character;
    public GameObject currentPlayer;
    public GameObject nextPlayer;
    public GameObject firstPlayer;
    public GameObject mainCamera;
    
void Awake(){

    addInfected(firstPlayer);
    currentPlayer = infectedplayers[0];
    if (instance == null)
    {
        instance = this;
    }
    else if (instance != this){
        Destroy(gameObject);
    }
}

    public void addInfected(GameObject newinfect){
        if (!infectedplayers.Contains(newinfect)){
        infectedplayers.Add(newinfect);}
    }

    void changeCharacter(){
        if(character < infectedplayers.Count -1){
        Debug.Log("space key");
        currentPlayer.GetComponent<playerMovement>().enabled = false;
        currentPlayer.GetComponent<playerAttack>().enabled = false;
        character = character + 1;
        currentPlayer = infectedplayers[character];
        currentPlayer.GetComponent<playerMovement>().enabled = true;
        currentPlayer.GetComponent<playerAttack>().enabled = true;
        mainCamera.GetComponent<CameraFollow>().targetSwitch(currentPlayer);
        }
    }

    void Update(){
        if (Input.GetKeyDown("space")){
        changeCharacter();
    }
    }
}

