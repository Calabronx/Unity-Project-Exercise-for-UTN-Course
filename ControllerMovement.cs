using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMovement : MonoBehaviour
{
    public Animator animator;
    private float gravity;

    // Update is called once per frame
    void Update()
    {
        gravity -= 5 * Time.deltaTime;
        CharacterController cc = GetComponent<CharacterController>();
        Vector3 movement = new Vector3();
        //movement.y = gravity;
        //animator.Play("Walk");
        //movement = Vector3.forward * Time.deltaTime * 2;
        //cc.Move(movement);
        //cc.Move(movement);




        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.Play("Run");
            movement = Vector3.forward * Time.deltaTime * 2;
            cc.Move(movement);
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("RifleAim 0");
        }

    }
}
