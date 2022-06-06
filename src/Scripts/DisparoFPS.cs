using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoFPS : MonoBehaviour
{
    EnemyLife enemy = new EnemyLife();
    public GameObject particlePrefab;
    public ParticleSystem pSys = new ParticleSystem();
    public ParticleSystem shootParticle;
    public ZonaDanioEnemy zoneHit = new ZonaDanioEnemy();
    public GameObject gameObject;

    public float damage = 5;

    public bool shootBox = false;

    private const int countParticles = 1000;

    private float shootTime = 10f;

    private bool isTargetHit = false;

    void Start()
    {
        
    }
    void Update()
    {
        int layerMask = 1 << 8;

        layerMask = ~layerMask;

        RaycastHit hit;
        

        if (Input.GetMouseButtonDown(0) && !Input.GetMouseButtonUp(0))
        {
            //if (!gameObject.GetComponent<ParticleSystem>().isPlaying)
            //{
                //gameObject.GetComponent<ParticleSystem>().Play();
                shootParticle.Play();
                shootParticle.Emit(countParticles);
                print("shooting ray");
            //}
            //else

              //  if (gameObject.GetComponent<ParticleSystem>().isPlaying)
            //{
              //  gameObject.GetComponent<ParticleSystem>().Stop();
            //}
            
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);

                
                Instantiate(pSys, hit.point, new Quaternion());
                Debug.Log("zone hit" + hit.transform);
                hitCheck();



            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.blue);
                Debug.Log("falso");
            }

           
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }


        
    }

    void hitCheck()
    {
        LayerMask mask = LayerMask.GetMask("Enemy");

        if(Physics.Raycast(transform.position, transform.forward, 20.0f, mask))
        {
            Debug.Log("Hit enemy!!!");
            zoneHit.isHit = true;
            zoneHit.damageTaken = damage;
        }
        else
        {
            Debug.Log("Miss enemy");
            
        }

    }

} 
