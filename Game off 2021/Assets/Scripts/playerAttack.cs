using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

    public float attackRange;
    public LayerMask enemyLayers;
    public Transform attackPoint;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)){
            infectAttack();
        }
        if (Input.GetKeyDown(KeyCode.E)){
            strongAttack();
        }

    }

    void infectAttack(){
        Debug.Log("attacking");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies){
        enemy.GetComponent<health>().takeDamage(1);
        enemy.GetComponent<health>().isInfected();
        }
    }

      void strongAttack(){
        Debug.Log("attacking");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies){
        enemy.GetComponent<health>().takeDamage(3);
        }
        }
}
