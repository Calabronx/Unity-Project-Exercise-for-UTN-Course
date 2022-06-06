using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public float lifeBar = 100;
    public float quantity;
    public GameObject player;
    private bool isDead = false;
    public bool damaged = false;
    public EnemyController enemy;

    void Update()
    {
        if (lifeBar <= 0)
        {
            Debug.Log("You are Dead");
            lifeBar = 0;
        }
    }

    public void takeDamage()
    {
        lifeBar--;
        Debug.Log("DAMAGED 1HP " + lifeBar);
    }

}
   

