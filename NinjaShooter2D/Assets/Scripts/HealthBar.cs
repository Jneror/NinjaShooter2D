using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	// Use this for initialization
	public GameObject Heart;
	public float spacing = 30;
	public PlayerController Player;
	void Start () {
		List<GameObject> hearts = new List<GameObject>();
		for (int i = 0; i < Player.features.maxHealth; i++) {
			hearts.Add(Instantiate(Heart, new Vector3(spacing*i,0,0), Quaternion.identity) as GameObject);
			hearts[i].transform.SetParent(GameObject.FindGameObjectWithTag("heart").transform, false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
