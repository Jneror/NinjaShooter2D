using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public BulletCtrl bullet;
	public float bulletVelocity;
	public float rango;
	
	public float playerVelocity;

	public float dashVelocity;
	private float dashTime;
	public float startDashTime;
	private bool dash;
	private float velocity;
	
	private Animator anim;
	private Rigidbody2D rb2d;
	private Vector2 mov;
	
	private Transform firePos;
	private Vector2 dir;
	public GameObject smoke;

	// Use this for initialization
	void Start () {
		firePos = transform.Find("firePos");
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		dash = false;
		velocity = playerVelocity;
		dashTime = startDashTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (!dash){
			mov = new Vector2(
				Input.GetAxisRaw("Horizontal"),
				Input.GetAxisRaw("Vertical")
			).normalized;
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
			if (Input.GetKeyDown(KeyCode.LeftShift)){
				dash = true;
				velocity = dashVelocity;
				Instantiate(smoke,transform.position,Quaternion.identity);
			}
		} else {
			if (dashTime <= 0){
				dash = false;
				velocity = playerVelocity;
				dashTime = startDashTime;
			} else {
				dashTime -= Time.deltaTime;
			}
		}
	}

	void FixedUpdate()
	{
		rb2d.MovePosition(rb2d.position + mov * velocity * Time.deltaTime);
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
