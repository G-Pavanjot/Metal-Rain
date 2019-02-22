using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	/**
	 * Simple script for the camera to follow the player
	 * */

	public Transform target;
	public float smoothing = 5f;
	
	Vector3 offset;


	void Start()
	{
		offset = transform.position - target.position;
	}
	
	void FixedUpdate()
	{
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}