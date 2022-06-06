using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float lifeBar = 1000;
    public float quantityLife = 3;
    public bool damaged;
    public ParticleSystem system;
    
    public GameObject player;
    public GameObject damageZone;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        Debug.Log("ENEMY LIFE: " + lifeBar);

    }

}