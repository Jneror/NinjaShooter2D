using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalyerController : MonoBehaviour {
	public BulletCtrl rightBullet;
	Transform firePos;
	private float norma;
	private float x;
	private float y;

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
		BulletCtrl newBullet = Instantiate(rightBullet,firePos.position,Quaternion.identity);
		norma = ;
		newBullet.speed = new Vector2(Input.mousePosition.x/norma,Input.mousePosition.y/norma); 
	}
}
