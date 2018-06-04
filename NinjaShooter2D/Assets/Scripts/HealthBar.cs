using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	// Use this for initialization
	public GameObject Heart;
	void Start () {
		GameObject newHeart = Instantiate(Heart, new Vector3(0,0,0), Quaternion.identity) as GameObject;
		newHeart.transform.SetParent(GameObject.FindGameObjectWithTag("heart").transform, false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
