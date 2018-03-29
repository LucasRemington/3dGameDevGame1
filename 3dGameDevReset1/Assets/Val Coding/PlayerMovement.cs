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
    private float jumpForce = 2.5f;
    //private Animator animator;
    private float Haxis;
    private Vector3 moveV;
	Animator anim;
	private bool fireCooldown;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
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
                anim.SetBool("jumping", true);
                Invoke("stopJumping", 0.1f);
            }
        }
        else if (!controller.isGrounded) {
            vertVelocity -= gravity * Time.deltaTime;
        }          
        Haxis = Input.GetAxis("Horizontal");
        moveV = new Vector3(0.0f, vertVelocity, Haxis);
		if (moveV.z != 0) {
			anim.SetBool ("walking", true);
		} else {
			anim.SetBool ("walking", false);
		}
        controller.Move(moveV * speed);
        Vector3 movement = new Vector3(0.0f, 0.0f, Haxis);
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

			if (fireCooldown == false) {
				anim.SetTrigger ("fire");
				fireCooldown = true;
				StartCoroutine (FireCooldown());
			}
				
        }
    }

	IEnumerator FireCooldown() {
		yield return new WaitForSeconds(1.033f);
		fireCooldown = false;
	}

    void stopJumping()
    {
        anim.SetBool("jumping", false);
    }

}
