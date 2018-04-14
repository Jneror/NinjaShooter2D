using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float playerVelocity = 3f;
	public float acceleration = 9.8f;
	public float friction = 10f;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		Vector3 accel = Vector3.zero;
		if (Input.GetAxis("Horizontal") != 0)
			accel += acceleration*Vector3.right*Input.GetAxisRaw("Horizontal");
		
		if (Input.GetAxis("Vertical") != 0)
			accel += acceleration*Vector3.up*Input.GetAxisRaw("Vertical");

		accel = accel.normalized*acceleration;
		rb.AddForce(accel);
		Debug.Log(rb.velocity.magnitude);
	}
}
