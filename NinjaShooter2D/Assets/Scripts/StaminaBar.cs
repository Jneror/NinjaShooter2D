using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour {

	// Use this for initialization
	public GameObject RedBull;
	public float spacing = 30;
	public PlayerController Player;
	void Start () {
		List<GameObject> redBulls = new List<GameObject>();
		for (int i = 0; i < Player.features.maxStamina/2; i++) {
			redBulls.Add(Instantiate(RedBull, new Vector3(spacing*i,-30,0), Quaternion.identity) as GameObject);
			redBulls[i].transform.SetParent(GameObject.FindGameObjectWithTag("heart").transform, false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
