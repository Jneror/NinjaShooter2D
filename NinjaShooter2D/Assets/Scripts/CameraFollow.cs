﻿using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public GameObject player;
    public Transform target;
    private Vector3 offset;

    void Start () 
    {
        offset = transform.position - player.transform.position;
    }
    void LateUpdate () 
    {
        transform.position = player.transform.position + offset;
    }

}
