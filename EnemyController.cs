using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Animator animator;

    private bool isWalking = false;
    private bool isStop = true;
    private int countStop = 0;
    public bool hitFlag = false;
    public bool hitPlayer = false;

    private float gravity;

    int countWalkTime = 0;
    int countShootTime = 0;
    int countWaitTime = 0;

    public PlayerLife playerLife = new PlayerLife();
    public EnemyLife enemy;

    //GameObject gameObject;

    //RunCommand run = new RunCommand();

    // Update is called once per frame
    void Start()
    {
        

        //InvokeRepeating("startWalk", 1.0f, 2.2f);
        if (!isWalking)
        {
            
            
                print("start section");
                InvokeRepeating("waitStill", 0.5f, 2.0f);
            
            //InvokeRepeating("shoot", 0.5f, 2.0f);

        }
       }
        

    void Update()
    {
        startWalk();

        if(isStop)
        {
            waitStill();
        }

        if (!isWalking)
        {
            while (countShootTime < 100)
            {
                shoot();
            }
         }

        //waitStill();
      }




    void waitStill()
    {
        
            print("waiting");
            animator.Play("Idle1");
            //isWalking = false;
            isStop = true;
       
            isStop = false;
        
            countWaitTime++;
        
        countWalkTime = 0;
        
    }

    void startWalk()
    {

        CharacterController cc = GetComponent<CharacterController>();
        //print("walking");
        Vector3 movement = new Vector3();
        gravity -= 5 * Time.deltaTime;
        movement.y = gravity;
        movement = Vector3.forward * Time.deltaTime * 3;

        if (countWalkTime <= 50)
        {
            print("walking");
            animator.Play("Walk");
            cc.Move(movement);

            isWalking = true;
        }
        else
        {
            print("end walk");
            isWalking = false;
        }
        countWalkTime++;
        countShootTime = 0;
        isStop = false;
        
        if(countStop >= 20)
        {
            countStop = 0;
        } 
    }

    void shoot()
    {

        LayerMask layer = LayerMask.GetMask("Player");

        hitPlayer = Physics.Raycast(transform.position, transform.forward, 1000, layer);
        RaycastHit hit;
        
            if (hitPlayer)
            {
                animator.Play("RifleAim");
                Debug.Log("Hit Player!");
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green);

                playerLife.takeDamage();

            }
            else
            {
                animator.Play("RifleAim");
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("MISS!");
                hitFlag = false;
            }
       
        countShootTime++;
        countWaitTime = 0;
        countStop++;

    }
}