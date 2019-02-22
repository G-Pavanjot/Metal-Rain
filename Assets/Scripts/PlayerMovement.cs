using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	/**
	 * Script which moves the player by taking the inputs either from the controller left joystick or wasd keys
	 * */

	public float speed = 6f;
	
	Vector3 movement;
	Animator animator;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;
	
	void Awake()
	{
		floorMask = LayerMask.GetMask ("Floor");
		animator = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
	}
	
	void FixedUpdate()
	{
		float horizontal = Input.GetAxisRaw ("Horizontal");
		float vertical = Input.GetAxisRaw ("Vertical");
		
		Move (horizontal, vertical);
		Animating (horizontal, vertical);
		
	}
	
	void Move(float h, float v)
	{
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		
		playerRigidbody.MovePosition (transform.position + movement);

	}
	

	
	void Animating(float h, float v)
	{
		bool walking = false;
	
		if (h != 0 || v != 0) {
			walking = true;
		} else {
			walking = false;
		}
		animator.SetBool("IsWalking", walking);
	}
	
	
}