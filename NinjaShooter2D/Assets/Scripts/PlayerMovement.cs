using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public bool useForce = false;
	public float playerVelocity = 2f;
	public float acceleration = 30f;
	public float friction = 10f;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
			useForce = !useForce;
			
		//version 2
		if (useForce)
		{
			Vector3 accel = Vector3.zero;
			if (Input.GetAxis("Horizontal") != 0)
			accel += acceleration*Vector3.right*Input.GetAxisRaw("Horizontal");
		
			if (Input.GetAxis("Vertical") != 0)
				accel += acceleration*Vector3.up*Input.GetAxisRaw("Vertical");

			accel = accel.normalized*acceleration;
			rb.AddForce(accel);
			Debug.Log(rb.velocity.magnitude);
		}
		else
		{
			Vector3 mov = Vector3.zero;
			if (Input.GetAxis("Horizontal") != 0)
				mov += Vector3.right*Input.GetAxisRaw("Horizontal");
			
			if (Input.GetAxis("Vertical") != 0)
				mov += Vector3.up*Input.GetAxisRaw("Vertical");
			
			mov = mov.normalized*playerVelocity*Time.deltaTime;
			transform.Translate(mov);
		}
	}
}
