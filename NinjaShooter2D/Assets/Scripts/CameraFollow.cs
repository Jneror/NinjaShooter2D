﻿using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	void LateUpdate()
	{
		Vector3 pos = target.position + offset;
		Vector3 smoothedPos = Vector3.Lerp(target.position, pos, smoothSpeed);
		transform.position =  smoothedPos;
	}

}
