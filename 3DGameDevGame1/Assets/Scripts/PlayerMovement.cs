using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public GameObject player;
    public GameObject fire;
    private float gravity = 10.0f;
    private CharacterController controller;
    private float vertVelocity;
    public int fireval;
    public float jumpForce = 2.5f;
    //private Animator animator;
    private float Haxis;
    private Vector3 moveV;



    void Start()
    {
        controller = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        Quaternion shooting = Quaternion.Euler(new Vector3(fire.transform.rotation.x, player.transform.rotation.y, 0.0f));
        if (controller.isGrounded)
        {
            vertVelocity = -0.5f;
            if (Input.GetButtonDown("Jump"))
            {
                vertVelocity = jumpForce;
                //animator.SetBool("jumping", true);
                Invoke("stopJumping", 0.1f);
            }
        }
        else if (!controller.isGrounded) {
            vertVelocity -= gravity * Time.deltaTime;
        }          
        Haxis = Input.GetAxis("Horizontal");
		moveV = new Vector3(Haxis, vertVelocity, 0.0f);
        controller.Move(moveV * speed);
		Vector3 movement = new Vector3(Haxis, 0.0f, 0.0f);
        if (Haxis != 0) {
            transform.rotation = Quaternion.LookRotation(-movement);
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }


        if(Haxis < 0)
        {
            fireval = 1;
        }
        if (Haxis > 0)
        {
            fireval = 0;
        }

        if (Input.GetButtonDown("Fire1"))
        {
                Instantiate(fire, player.transform.position, shooting);
        }
			
    }

    void stopJumping()
    {
        //animator.SetBool("jumping", false);
    }

}
