using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform target;
    [Range(0, 1)]
    public float smoothFactor = 0.3f;
    private Vector3 offset;

    void Start () 
    {
        offset = transform.position - target.position;
    }
    void LateUpdate () 
    {
        Vector2 originPosition = Vector2.right * transform.position.x + Vector2.up * transform.position.y;
        Vector2 focusPosition = Vector2.right * target.position.x + Vector2.up * target.position.y;
        Vector2 finalPosition = Vector2.Lerp(originPosition, focusPosition, smoothFactor);
        transform.position = new Vector3(finalPosition.x, finalPosition.y, transform.position.z);
    }

}
