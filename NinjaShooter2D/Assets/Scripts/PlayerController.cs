using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public BulletCtrl rightBullet;
	public float bulletvelocity;
	public float rango = 1;
	Transform firePos;
	Vector2 dir;

	// Use this for initialization
	void Start () {
		firePos = transform.Find("firePos");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Fire();
		}
	}
	void Fire(){
		dir = new Vector2(Camera.main.ScreenToWorldPoint (Input.mousePosition).x-firePos.position.x,Camera.main.ScreenToWorldPoint (Input.mousePosition).y-firePos.position.y);
		dir = dir.normalized;
		Vector3 pos = new Vector3(firePos.position.x + rango*dir.x,firePos.position.y + rango*dir.y ,0);
		BulletCtrl newBullet = Instantiate(rightBullet,pos,Quaternion.identity);
		newBullet.speed = bulletvelocity * dir.normalized;
	}
}
