using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	private Transform target;
	// Use this for initialization
	void Start () {
		target = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		transform.position = new Vector3(target.position.x,target.position.y,transform.position.z);	
	}
}
