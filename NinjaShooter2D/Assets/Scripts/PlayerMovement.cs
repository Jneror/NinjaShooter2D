using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float playerVelocity = 2f;
	public float dashVelIncrease = 0.4f;
	public float dashDuration = 1f;
	private float dashTime = 0;
	private Vector3 dashDirection;
	Animator anim;
	//private Rigidbody2D rb;

	void Start () {
		//rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	void Update () {

		bool movedHorizontal = Input.GetAxis("Horizontal") != 0;
		bool movedVertical = Input.GetAxis("Vertical") != 0;

		if (dashTime > 0)
		{
			dashTime -= Time.deltaTime;
			float realVelocity = playerVelocity + dashVelIncrease;
			transform.Translate(dashDirection * realVelocity * Time.deltaTime);
		}
		else if (movedHorizontal || movedVertical)
		{
			Vector3 mov = Vector3.zero;
			if (movedHorizontal)
				mov += Vector3.right * Input.GetAxisRaw("Horizontal");
			
			if (movedVertical)
				mov += Vector3.up * Input.GetAxisRaw("Vertical");

			anim.SetFloat("movX",mov.x);
			anim.SetFloat("movY",mov.y);
			mov = mov.normalized;

			if (Input.GetKeyDown(KeyCode.LeftShift))
			{
				dashTime = dashDuration;
				dashDirection = mov;
			}

			transform.Translate(mov * playerVelocity * Time.deltaTime);
		}
		
	}
}
