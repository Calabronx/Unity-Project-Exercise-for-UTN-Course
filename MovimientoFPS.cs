using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFPS : MonoBehaviour
{
    private float gravity;
    private float angleY;
    private float angleX;

    public Vector3 moveDirection = Vector3.zero;
    public Animator anim;

    private int speed = 10;

    // Update is called once per frame
    void Update()
    {
        gravity -= 5 * Time.deltaTime;

        CharacterController cc = GetComponent<CharacterController>();
        Vector3 movement = new Vector3();
        movement.y = gravity;
        cc.Move(movement);

        if (cc.isGrounded)
        {
            gravity = 0.0F;
        }

        if (cc.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            
            gravity = 0.0F;

        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Run Mode");
            speed += 20;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Debug.Log("Walk Mode again");
            speed -= 20;
        }

        if (Input.GetKey(KeyCode.W))
        {
            //movement.z = 10 * Time.deltaTime;
            anim.Play("Run");
            movement = moveDirection * Time.deltaTime * speed;
            cc.Move(movement);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            //movement.y = 10 * Time.deltaTime;
            movement = moveDirection * Time.deltaTime * speed;
            cc.Move(movement);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //movement.x = 10 * Time.deltaTime;
            movement = moveDirection * Time.deltaTime * speed;
            cc.Move(movement);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //movement.x = 10 * Time.deltaTime;
            movement = moveDirection * Time.deltaTime * speed;
            cc.Move(movement);
        }

        if (Input.GetKey(KeyCode.Space) && cc.isGrounded == true)
        {
            gravity += 5 * Time.deltaTime;
            movement = Vector3.up * gravity * 10;
            cc.Move(movement);
        }

    }
}
