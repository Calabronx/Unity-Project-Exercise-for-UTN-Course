using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaDanioEnemy : MonoBehaviour
{
    public float atenuacion;
    public EnemyLife enemyLife;
    public Collider collider;

    public float damageTaken;

    public bool isHit = false;
    public GameObject gameEnemy;

    // Update is called once per frame
    void Update()
    {
        receive();
    }

    public void obtainDamage(float damage)
    {
        if(enemyLife.lifeBar <=0 )
        {
            enemyLife.lifeBar = 1000;
            enemyLife.quantityLife--;
            Debug.Log("Enemy kill, lifes left: " + enemyLife.quantityLife);
        }
        if(enemyLife.quantityLife <=0)
        {
            Debug.Log("Enemy has stop regenerating, 0 lives left");
            //Destroy(gameEnemy);
        }
        damage *= atenuacion;
        enemyLife.lifeBar -= damage;

        Debug.Log("Damage zone reach enemy");
        Debug.Log("Life enemy atuenuation: " + damage + " HP");
        Debug.Log("Life enemy: " + enemyLife.lifeBar + " HP");

    }

    void receive()
    {

        if (isHit)
        {
            Debug.Log("Got Hit!");
            obtainDamage(damageTaken);
            
        }
        else
        {
            Debug.Log("Nothing");
            isHit = false;
        }
    }

    
}
