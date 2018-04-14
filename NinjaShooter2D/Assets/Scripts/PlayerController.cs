using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public GameObject rightBullet;
	Transform firePos;

	// Use this for initialization
	void Start () {
		firePos = transform.Find("firePos");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			Fire();
		}
	}
	void Fire(){
		Instantiate(rightBullet,firePos.position,Quaternion.identity);
	}
}
