using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float playerVelocity = 3f;
	public float acceleration = 9.8f;
	public float friction = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 move = Vector3.zero;
		if (Input.GetAxis("Horizontal") != 0)
			move += Vector3.right*Input.GetAxisRaw("Horizontal")*playerVelocity*Time.deltaTime;
		
		if (Input.GetAxis("Vertical") != 0)
			move += Vector3.up*Input.GetAxisRaw("Vertical")*playerVelocity*Time.deltaTime;

		transform.Translate(move);
	}
}
