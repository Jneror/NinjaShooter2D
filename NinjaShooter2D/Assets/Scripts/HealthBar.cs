using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	// Use this for initialization
	public GameObject Heart;
	public float spacing = 30;

	private List<GameObject> hearts;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetMaxHealth(int maxHealth)
	{
		hearts = new List<GameObject>();
		for (int i = 0; i < maxHealth/4; i++) {
			hearts.Add(Instantiate(Heart, new Vector3(spacing*i,0,0), Quaternion.identity) as GameObject);
			hearts[i].transform.SetParent(GameObject.FindGameObjectWithTag("heart").transform, false);
		}
	}

	public void UpdateHealth(int currentHealth)
	{
		
	}
}
