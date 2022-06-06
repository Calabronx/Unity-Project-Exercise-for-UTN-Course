using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaDanio : MonoBehaviour
{
    public float atenuacion;
    public EnemyLife enemyLife;
    public LayerMask layer;
    public Collider collider;

    // Update is called once per frame
    void Update()
    {
        
    }

    void obtainDamage(float damage)
    {
        
            damage *= atenuacion;
            enemyLife.quantityLife -= damage;
        
            Debug.Log("Damage zone reach enemy");
            Debug.Log("Life enemy atuenuation: " + damage + " HP");
            Debug.Log("Life enemy: " + enemyLife.quantityLife + " HP");

    }

    
    }

