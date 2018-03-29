using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public Rigidbody rb;
    private float speed = 5.0f;
    public PlayerMovement pm;
    public GameObject player;

	void Start () {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
        pm = player.GetComponent<PlayerMovement>();
        if (pm.fireval == 0)
        {
            rb.velocity = (Vector3.right * speed);
        }
        if (pm.fireval == 1)
        {
            rb.velocity = (Vector3.left * speed);
        }
       
	}
	
	void Update () {
        Object.Destroy(gameObject,5.0f);
	}
}
