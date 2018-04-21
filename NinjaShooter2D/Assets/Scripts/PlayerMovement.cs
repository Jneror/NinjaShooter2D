using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float playerVelocity = 2f;
	public float dashVelIncrease = 0.4f;
	//private Rigidbody2D rb;

	void Start () {
		//rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {

		bool movedHorizontal = Input.GetAxis("Horizontal") != 0;
		bool movedVertical = Input.GetAxis("Vertical") != 0;

		if (movedHorizontal || movedVertical)
		{
			Vector3 mov = Vector3.zero;
			if (movedHorizontal)
				mov += Vector3.right * Input.GetAxisRaw("Horizontal");
			
			if (movedVertical)
				mov += Vector3.up * Input.GetAxisRaw("Vertical");
			
			mov = mov.normalized * playerVelocity * Time.deltaTime;
			transform.Translate(mov);
		}
	}
}
