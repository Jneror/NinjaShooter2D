using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
	public bool isFiring;

	public float bulletspeed;
	
	public float timeBetweenShots;
	private float shotCounter;

	public Transform firePoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
