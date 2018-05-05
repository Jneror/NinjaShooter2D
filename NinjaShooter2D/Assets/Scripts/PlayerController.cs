using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public BulletCtrl bullet;
	public float bulletVelocity = 5f;
	public float rango = 2f;
	
	public float playerVelocity = 3f;
	
	Animator anim;
	Rigidbody2D rb2d;
	Vector2 mov;
	
	Transform firePos;
	Vector2 dir;

	// Use this for initialization
	void Start () {
		firePos = transform.Find("firePos");
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		mov = new Vector2(
			Input.GetAxisRaw("Horizontal"),
			Input.GetAxisRaw("Vertical")
		);
		if (mov != Vector2.zero){
			anim.SetFloat("movX",mov.x);
			anim.SetFloat("movY",mov.y);
			anim.SetBool("walking",true);
		} else {
			anim.SetBool("walking",false);
		}
		if(Input.GetMouseButtonDown(0)){
			Fire();
		}
	}

	void FixedUpdate()
	{
		rb2d.MovePosition(rb2d.position + mov * playerVelocity * Time.deltaTime);
	}
	
	void Fire(){
		dir = new Vector2(
			Camera.main.ScreenToWorldPoint (Input.mousePosition).x-firePos.position.x,
			Camera.main.ScreenToWorldPoint (Input.mousePosition).y-firePos.position.y
			);
		dir = dir.normalized;
		Vector3 pos = new Vector3(
			firePos.position.x + rango*dir.x,
			firePos.position.y + rango*dir.y,
			0
			);
		BulletCtrl newBullet = Instantiate(bullet,pos,Quaternion.identity);
		newBullet.speed = bulletVelocity * dir.normalized;
	}
}
