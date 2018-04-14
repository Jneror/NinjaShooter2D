using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float smoothSpeed = 0.125f;
	public Vector2 offset;

	void LateUpdate()
	{
		Vector2 targetPosition = new Vector2(target.position.x, target.position.y);
		Vector3 smoothedPos = Vector2.Lerp(targetPosition, new Vector3(transform.position.x, transform.position.y), smoothSpeed);
		transform.position =  new Vector3(smoothedPos.x, smoothedPos.y, -1);
	}

}
